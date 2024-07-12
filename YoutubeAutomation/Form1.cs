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
            if (string.IsNullOrEmpty(LinkInput.Text))
            {
                MessageBox.Show("Please enter a valid link");
                return;
            }
            
            Video video = new Video();
            await video.CreateVideo(LinkInput.Text);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
