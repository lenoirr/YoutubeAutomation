namespace YoutubeAutomation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ThumbnailPicture = new PictureBox();
            tabControl1 = new TabControl();
            Download = new TabPage();
            progressBarText = new TextBox();
            downloadProgressBar = new ProgressBar();
            ThumbnailLoadingAnimation = new PictureBox();
            label3 = new Label();
            StartButton = new Button();
            label4 = new Label();
            LinkInput = new TextBox();
            tabPage2 = new TabPage();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)ThumbnailPicture).BeginInit();
            tabControl1.SuspendLayout();
            Download.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailLoadingAnimation).BeginInit();
            SuspendLayout();
            // 
            // ThumbnailPicture
            // 
            ThumbnailPicture.InitialImage = null;
            ThumbnailPicture.Location = new Point(40, 136);
            ThumbnailPicture.Margin = new Padding(3, 4, 3, 4);
            ThumbnailPicture.Name = "ThumbnailPicture";
            ThumbnailPicture.Size = new Size(457, 231);
            ThumbnailPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            ThumbnailPicture.TabIndex = 9;
            ThumbnailPicture.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Download);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(707, 448);
            tabControl1.TabIndex = 5;
            // 
            // Download
            // 
            Download.BackColor = Color.White;
            Download.Controls.Add(progressBarText);
            Download.Controls.Add(downloadProgressBar);
            Download.Controls.Add(ThumbnailPicture);
            Download.Controls.Add(ThumbnailLoadingAnimation);
            Download.Controls.Add(label3);
            Download.Controls.Add(StartButton);
            Download.Controls.Add(label4);
            Download.Controls.Add(LinkInput);
            Download.Location = new Point(4, 29);
            Download.Margin = new Padding(3, 4, 3, 4);
            Download.Name = "Download";
            Download.Padding = new Padding(3, 4, 3, 4);
            Download.Size = new Size(699, 415);
            Download.TabIndex = 0;
            Download.Text = "Download Videos";
            // 
            // progressBarText
            // 
            progressBarText.BorderStyle = BorderStyle.None;
            progressBarText.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            progressBarText.Location = new Point(503, 376);
            progressBarText.Name = "progressBarText";
            progressBarText.Size = new Size(60, 27);
            progressBarText.TabIndex = 12;
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Location = new Point(40, 374);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(457, 29);
            downloadProgressBar.TabIndex = 11;
            // 
            // ThumbnailLoadingAnimation
            // 
            ThumbnailLoadingAnimation.Image = Properties.Resources.loadingAnimation_ezgif_com_optimize__1_;
            ThumbnailLoadingAnimation.Location = new Point(215, 196);
            ThumbnailLoadingAnimation.Margin = new Padding(3, 4, 3, 4);
            ThumbnailLoadingAnimation.Name = "ThumbnailLoadingAnimation";
            ThumbnailLoadingAnimation.Size = new Size(109, 128);
            ThumbnailLoadingAnimation.TabIndex = 10;
            ThumbnailLoadingAnimation.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 13);
            label3.Name = "label3";
            label3.Size = new Size(354, 60);
            label3.TabIndex = 8;
            label3.Text = "Welcome to MM's Youtube Automation Application!\r\n\r\n\r\n";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(506, 97);
            StartButton.Margin = new Padding(3, 4, 3, 4);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(97, 31);
            StartButton.TabIndex = 7;
            StartButton.Text = "Enter";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 73);
            label4.Name = "label4";
            label4.Size = new Size(176, 20);
            label4.TabIndex = 6;
            label4.Text = "Input Youtube Link Below";
            // 
            // LinkInput
            // 
            LinkInput.Location = new Point(40, 97);
            LinkInput.Margin = new Padding(3, 4, 3, 4);
            LinkInput.Name = "LinkInput";
            LinkInput.Size = new Size(457, 27);
            LinkInput.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(699, 415);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(707, 448);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube Automation";
            ((System.ComponentModel.ISupportInitialize)ThumbnailPicture).EndInit();
            tabControl1.ResumeLayout(false);
            Download.ResumeLayout(false);
            Download.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailLoadingAnimation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox LinkInput;
        private Label label1;
        private Button StartButton;
        private Label label2;
        private TabControl tabControl1;
        private TabPage Download;
        private TabPage tabPage2;
        private PictureBox ThumbnailPicture;
        private Label label3;
        private Button button1;
        private Label label4;
        private TextBox textBox1;
        private PictureBox ThumbnailLoadingAnimation;
        public ProgressBar downloadProgressBar;
        private TextBox progressBarText;
        private ContextMenuStrip contextMenuStrip1;
    }
}
