using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeAutomation
{
    internal class Video
    {

        #region Variables

        private string title = string.Empty;
        private string url = string.Empty;
        private string id = string.Empty;
        private string author = string.Empty;
        private dynamic duration;
        private string transcript;
        private YoutubeExplode.Videos.Video explode;
        private Image thumbnail;
        private YoutubeClient youtubeClient = new YoutubeClient();

        private readonly AppConfig _config;
        #endregion


        #region Events
        // input not valid link event here

        public delegate void InvalidLinkEventHandler(object sender, EventArgs e);
        public event InvalidLinkEventHandler InvalidLink;

        public delegate void TitleNotFoundEventHandler(object sender, EventArgs e);
        public event TitleNotFoundEventHandler TitleNotFound; 


        #endregion


        #region Properties

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    TitleNotFound?.Invoke(this, EventArgs.Empty);

                }
                else title = value;
            }
        }
        public string Id { get; set; }
        public string Author { get; set; }
        public dynamic Duration
        {
            get { return duration; }
            set { duration = value ?? 0; }  //possible if input url is an active livestream
        }
        public Image Thumbnail { get; private set; }

        #endregion

        #region Constructor
        public Video(string url)
        {
            this.url = url;

            _config = ConfigurationLoader.LoadConfiguration();           

        }
        #endregion

        #region Methods
        /*
         * ExecutePipline() is the main method that will be called to start the process of getting the video's metadata, transcription, and thumbnail.
         */
        public async Task ExecutePipline()
        {
             bool metaDataSuccess = await GetMetaData();
            if (metaDataSuccess == false)
            {
                return; // some failure occured and has already been handled.
            }

            // Start both tasks without awaiting immediately
            var thumbnailTask= LoadThumbnailAsync();
            var transcriptionTask = CreateTranscription();
            var downloadVideoTask = DownloadVideoAsync();
            // download video async - cancel if the transcript is not found, then the operation can not be completed at all womp womp


            // Now await both tasks to complete
            await Task.WhenAll(transcriptionTask, thumbnailTask, downloadVideoTask);
            DisplayDetails();
        }

        private async Task<bool> GetMetaData()
        {

            try
            {
                var video = await youtubeClient.Videos.GetAsync(url);
                this.explode = video;
                this.title = video.Title;
                this.id = video.Id;
                this.duration = video.Duration;
                return true;
            }
            catch (System.ArgumentException ex) when (ex.Message.Contains("Invalid YouTube video ID or URL"))
            {
                InvalidLink?.Invoke(this, EventArgs.Empty);
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions if necessary
                return false;
                throw; // Rethrow the exception if it's not the one we're specifically handling
            }
        }

        private async Task<string> CreateTranscription()
        {
            try
            {
                var transcript = await Transcript.GetTranscription(this.url);
                return transcript;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Could not find transcription: " + ex.Message);
                return string.Empty;   
            }
        }

        private async Task LoadThumbnailAsync()
        {
            // grab thumbnail url
            try
            {
                    var thumbnailUrl = this.explode.Thumbnails.GetWithHighestResolution().Url;

                    using (HttpClient client = new HttpClient())
                    {
                    var response = await client.GetAsync(thumbnailUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            if (IsImageFormatCompatible(response))
                            {
                                var stream = await response.Content.ReadAsStreamAsync();
                                this.Thumbnail = Image.FromStream(stream);
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("Received Thumbnail was not a compatible format");
                                this.Thumbnail = Properties.Resources.youtube_ninja__2_;
                            }
                        }

                    }                
            }
            catch (Exception)
            {
                this.Thumbnail = Properties.Resources.youtube_ninja__2_;
            }
        }
    
 
        private bool IsImageFormatCompatible(HttpResponseMessage response)
        {
            string ContentType = response.Content.Headers.ContentType.MediaType;

            string[] supportedFormats = new string[]
            {
                "image/bmp",
                "image/gif",
                "image/jpeg",
                "image/png",
                "image/tiff"
            };

            // Check if the content type is in the list of supported formats
            if (Array.Exists(supportedFormats, format => format.Equals(ContentType, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            else // webp is not supported by Image.FromStream
            {
                return false;
            }
        }

        public void DisplayDetails()
        {
            System.Diagnostics.Debug.WriteLine($"{this.Title}, {this.Author}, {this.Duration}, {this.Id}");
        }

        public async Task DownloadVideoAsync() // TODO: Implement Cancelation Token if Transcript is not found. 
        {
            try
            {
                string ffmpegPath = _config.FfmpegLocalPath;
                string outputDirectory = "C:\\YoutubeDownloads";    // TODO: Make this a user defined path
                Utilities.CreateDirectoryIfNotExists(outputDirectory);
                string outputPath = Path.Combine(outputDirectory, $"TestVideo.mp4");    // TODO: Use Title as a dynamic video, need to create method to sanitize title for file name


                await youtubeClient.Videos.DownloadAsync(id, outputPath, o => o
                    .SetFFmpegPath(ffmpegPath)
                    .SetContainer("mp4"));

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Download HTTP Request Failed: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unknown Error Occured During Download Attempt: {ex.Message}");
                
            }

        }
    }
        #endregion
 }



