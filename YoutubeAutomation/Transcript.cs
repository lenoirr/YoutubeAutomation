using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.ClosedCaptions;

namespace YoutubeAutomation
{
    internal class Transcript
    {

        private string url = String.Empty;

        public Transcript(string url)
        {
            this.url = url;
        }

        public static async Task<string> GetTranscription(string videoUrl)
        {
            
            string videoId = VideoId.Parse(videoUrl);

            var youtube = new YoutubeClient();

            var trackManifest = await youtube.Videos.ClosedCaptions.GetManifestAsync(videoId);

            var trackInfo = trackManifest.Tracks.FirstOrDefault(t => t.Language.Code == "en");

            if (trackInfo != null)
            {
                var captions = await youtube.Videos.ClosedCaptions.GetAsync(trackInfo);

                StringBuilder transcription = new StringBuilder();

                foreach (var caption in captions.Captions)
                {
                    string timestamp = TimeSpan.FromMilliseconds(caption.Offset.TotalMilliseconds).ToString(@"hh\:mm\:ss");
                    transcription.AppendLine($"{timestamp}: {caption.Text}");
                }
                System.Diagnostics.Debug.WriteLine(transcription);
                return transcription.ToString();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No English captions available");
            }
            return string.Empty;
        }

    }

    
}
