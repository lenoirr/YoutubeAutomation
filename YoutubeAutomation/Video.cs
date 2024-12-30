using System.Diagnostics;
using System.Text.RegularExpressions;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;


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


        public Progress<double> downloadProgress = new Progress<double>();
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
        public async Task ExecutePipline(CancellationToken cancellationToken)
        {
             bool metaDataSuccess = await GetMetaData();
            if (metaDataSuccess == false)
            {
                return; // some failure occured and has already been handled.
            }

            // Start both tasks without awaiting immediately
            var thumbnailTask= LoadThumbnailAsync();
            var transcriptionTask = CreateTranscription(cancellationToken);
            var downloadVideoTask = DownloadVideoAsync(cancellationToken);
            // download video async - cancel if the transcript is not found, then the operation can not be completed at all womp womp


            // Now await both tasks to complete
            //await Task.WhenAll(/*transcriptionTask, thumbnailTask, downloadVideoTask*/);
            
            await Task.WhenAll(transcriptionTask,downloadVideoTask,thumbnailTask);

            Debug.WriteLine(transcriptionTask.Result);

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

        private async Task<string> CreateTranscription(CancellationToken cancellationToken)
        {
            try
            {
                var transcript = await Transcript.GetTranscription(this.url, cancellationToken);
                return transcript;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Could not find transcription: " + ex);
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
                Debug.WriteLine("Error loading thumbnail");
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

        private string SanatizeTitleName(string videoTitle)
        {
            // Define a regex pattern for invalid characters
            string invalidChars = new string(Path.GetInvalidFileNameChars());
            string invalidRegex = string.Format("[{0}]", Regex.Escape(invalidChars));

            // Replace invalid characters with an underscore
            return Regex.Replace(videoTitle, invalidRegex, "_") + ".mp4";
            
        }

        public async Task DownloadVideoAsync(CancellationToken cancellationToken) // TODO: Implement Cancelation Token if Transcript is not found. 
        {
            try
            {
                string ffmpegPath = _config.FfmpegLocalPath;
                string outputDirectory = "C:\\YoutubeDownloads";                    // TODO: Make this a user defined path
                Utilities.CreateDirectoryIfNotExists(outputDirectory);
                string videoTitle = SanatizeTitleName(this.title);
                string outputPath = Path.Combine(outputDirectory, videoTitle);    // TODO: Use Title as a dynamic video, need to create method to sanitize title for file name

                await youtubeClient.Videos.DownloadAsync(id, outputPath, o => o
                    .SetFFmpegPath(ffmpegPath)
                    .SetContainer("mp4"),
                     downloadProgress, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Download HTTP Request Failed: {ex.Message}");
                throw;
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show($"Download Cancelled.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unknown Error Occured During Download Attempt: {ex}");
            }
        }
    }
    #endregion
 }



