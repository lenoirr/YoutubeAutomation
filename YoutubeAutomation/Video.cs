using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace YoutubeAutomation
{
    internal class Youtube
    {
        private async Task CreateVideo(string videoUrl)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);

            System.Diagnostics.Debug.WriteLine(video.Title, video.Author, video.Duration, video.Id);
        }


    }


}
