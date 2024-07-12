using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace YoutubeAutomation
{
    internal class Video
    {
        private string title = string.Empty;
        private string id = string.Empty;
        private string author = string.Empty;
        private dynamic duration;

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
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);
            this.title = video.Title;
            this.id = video.Id;
            this.author = video.Author.ToString();
            this.duration = video.Duration;

            System.Diagnostics.Debug.WriteLine($"{video.Title}, {video.Author}, {video.Duration}, {video.Id}");

        }


    }


}
