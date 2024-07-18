namespace YoutubeAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LinkInput.Text) || string.IsNullOrWhiteSpace(LinkInput.Text))
            {
                MessageBox.Show("That isn't a link......");
                return;
            }

            Video video = new Video(LinkInput.Text);
            video.TitleNotFound += VideoTitleNotFound_EventHandlerMethod;
            video.InvalidLink += VideoInvalidLink_EventHandlerMethod;

            await video.ExecutePipline();
            ThumbnailPicture.Image = video.Thumbnail;
        }

        private void VideoTitleNotFound_EventHandlerMethod(object sender, EventArgs e)
        {
            MessageBox.Show("The video title wasn't found - sorry");
        }

        private void VideoInvalidLink_EventHandlerMethod(object sender, EventArgs e)
        {
            MessageBox.Show("That wasn't a link...... Unless it was, then whoops");
        }

    }
}
