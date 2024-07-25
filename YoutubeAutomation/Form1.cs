using YoutubeExplode.Videos;

namespace YoutubeAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormLoad();

        }
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
            LoadingAnimation();

            Video video = new Video(LinkInput.Text);
            video.TitleNotFound += VideoTitleNotFound_EventHandlerMethod;
            video.InvalidLink += VideoInvalidLink_EventHandlerMethod;

            await video.ExecutePipline();
            DisplayThumbnail(video.Thumbnail);
        }

        #region EventHandlers

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
