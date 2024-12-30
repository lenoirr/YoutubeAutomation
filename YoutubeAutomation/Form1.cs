using System.Diagnostics;
using System.Threading;
using YoutubeExplode.Videos;

namespace YoutubeAutomation
{
    public partial class Form1 : Form
    {

        public IProgress<double> DownloadProgress;
        public Form1()
        {
            InitializeComponent();
            FormLoad();
        }

        private CancellationTokenSource cancellationTokenSource;
            
        public bool isDownloading = false;
        private void FormLoad()
        {
            //ThumbnailPicture.Visible = true;
            Image test = Properties.Resources.youtube_ninja__2_;
            ThumbnailPicture.Image = Properties.Resources.youtube_ninja__2_;
            ThumbnailLoadingAnimation.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                StartButton_Click(this, EventArgs.Empty);
            }
            else
            {
                return false;
            }
            return true;
        }

        private void SubscribeToEvents()
        {

        }

        private void LoadingAnimation()
        {
            ThumbnailPicture.Visible = false;
            ThumbnailLoadingAnimation.Visible = true;
        }
        private void DisplayThumbnail(Image thumbnail)
        {
            ThumbnailLoadingAnimation.Visible = false;
            ThumbnailPicture.Visible = true;
            ThumbnailPicture.Image = thumbnail;
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                // Cancel the download
                cancellationTokenSource.Cancel();
                isDownloading = false;
                StartButton.Text = "Download";
            }
            else
            {
                // Start the download
                LoadingAnimation();

                Video video = new Video(LinkInput.Text);

                video.TitleNotFound += VideoTitleNotFound_EventHandlerMethod;
                video.InvalidLink += VideoInvalidLink_EventHandlerMethod;
                video.downloadProgress.ProgressChanged += DownloadProgressChanged;

                cancellationTokenSource = new CancellationTokenSource();
                isDownloading = true;
                StartButton.Text = "Cancel";

                try
                {
                    await video.ExecutePipline(cancellationTokenSource.Token);
                    DisplayThumbnail(video.Thumbnail);
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Download canceled.");
                }
                finally
                {
                    isDownloading = false;
                    StartButton.Text = "Download";
                }
            }
        }


        #region EventHandlers
        private void DownloadProgressChanged(object sender, double percent)
        {
            int roundedProgress = (int)Math.Round(percent * 100);
            downloadProgressBar.Value = roundedProgress;
            progressBarText.Text = $"{roundedProgress}%";
        }
        private void VideoTitleNotFound_EventHandlerMethod(object sender, EventArgs e)
        {
            MessageBox.Show("The video title wasn't found - sorry");
        }

        private void VideoInvalidLink_EventHandlerMethod(object sender, EventArgs e)
        {
            MessageBox.Show("That wasn't a link...... Unless it was, then whoops");
        }
        #endregion

    }
}
