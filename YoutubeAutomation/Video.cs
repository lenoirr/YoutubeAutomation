using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos;

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
            var thumbnailTask = LoadThumbnailAsync();
            var transcriptionTask = CreateTranscription();
            //await LoadThumbnailAsync();
            //await CreateTranscription();


            // Now await both tasks to complete
            await Task.WhenAll(transcriptionTask, thumbnailTask);
            DisplayDetails();
        }
        public async Task<bool> GetMetaData()
        {

            try
            {
                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(url);
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

        public async Task CreateTranscription()
        {
            this.transcript = await Transcript.GetTranscription(this.url);
        }

        public async Task LoadThumbnailAsync()   // let look at this more in depth next. 
        {
            // grab thumbnail url

            var thumbnailUrl = this.explode.Thumbnails.GetWithHighestResolution().Url;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(thumbnailUrl);
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    this.Thumbnail = Image.FromStream(stream);
                }
            }

        }

        public void DisplayDetails()
        {
            System.Diagnostics.Debug.WriteLine($"{this.Title}, {this.Author}, {this.Duration}, {this.Id}");
        }

        #endregion

    }


}
