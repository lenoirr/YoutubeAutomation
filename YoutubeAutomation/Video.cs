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
        private string title = string.Empty;
        private string url = string.Empty;
        private string id = string.Empty;
        private string author = string.Empty;
        private dynamic duration;
        private string transcript;
        private YoutubeExplode.Videos.Video explode;


        public string Title { get; set; }
        public string Id { get; set; }
        public string Author { get; set; }
        public dynamic Duration
        {
            get { return duration; }
            set { duration = value ?? 0; }  //possible if input url is an active livestream
        }

        public Video()
        {
            // Nothing. Call the CreateVideo Method to populate object homie!
        }
        public async Task CreateVideo(string videoUrl)
        {
            // grab youtube Metadata

            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);
            this.explode = video;
            this.url = videoUrl;
            this.title = video.Title;
            this.id = video.Id;
            this.author = video.Author.ToString();
            this.duration = video.Duration;

            //System.Diagnostics.Debug.WriteLine($"{video.Title}, {video.Author}, {video.Duration}, {video.Id}");
        }

        public async Task CreateTranscription()
        {
            this.transcript = await Transcript.GetTranscription(this.url);
        }

        public async Task<Image> LoadThumbnailAsync()   // let look at this more in depth next. 
        {
            // grab thumbnail url

            var thumbnailUrl = this.explode.Thumbnails.GetWithHighestResolution().Url;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(thumbnailUrl);
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    var image = Image.FromStream(stream);
                    return image;
                }
                else return null;
            }

        }

        public void DisplayDetails()
        {
            System.Diagnostics.Debug.WriteLine($"{this.Title}, {this.Author}, {this.Duration}, {this.Id}");
        }


    }


}
