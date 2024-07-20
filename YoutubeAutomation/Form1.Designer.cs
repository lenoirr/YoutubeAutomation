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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ThumbnailPicture = new PictureBox();
            tabControl1 = new TabControl();
            MainPage = new TabPage();
            ThumbnailLoadingAnimation = new PictureBox();
            label3 = new Label();
            StartButton = new Button();
            label4 = new Label();
            LinkInput = new TextBox();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPicture).BeginInit();
            tabControl1.SuspendLayout();
            MainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailLoadingAnimation).BeginInit();
            SuspendLayout();
            // 
            // ThumbnailPicture
            // 
            ThumbnailPicture.InitialImage = null;
            ThumbnailPicture.Location = new Point(35, 102);
            ThumbnailPicture.Name = "ThumbnailPicture";
            ThumbnailPicture.Size = new Size(400, 200);
            ThumbnailPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            ThumbnailPicture.TabIndex = 9;
            ThumbnailPicture.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(MainPage);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(619, 336);
            tabControl1.TabIndex = 5;
            // 
            // MainPage
            // 
            MainPage.BackColor = Color.White;
            MainPage.Controls.Add(ThumbnailPicture);
            MainPage.Controls.Add(ThumbnailLoadingAnimation);
            MainPage.Controls.Add(label3);
            MainPage.Controls.Add(StartButton);
            MainPage.Controls.Add(label4);
            MainPage.Controls.Add(LinkInput);
            MainPage.Location = new Point(4, 24);
            MainPage.Name = "MainPage";
            MainPage.Padding = new Padding(3);
            MainPage.Size = new Size(611, 308);
            MainPage.TabIndex = 0;
            MainPage.Text = "Main";
            // 
            // ThumbnailLoadingAnimation
            // 
            ThumbnailLoadingAnimation.Image = Properties.Resources.loadingAnimation_ezgif_com_optimize__1_;
            ThumbnailLoadingAnimation.Location = new Point(188, 147);
            ThumbnailLoadingAnimation.Name = "ThumbnailLoadingAnimation";
            ThumbnailLoadingAnimation.Size = new Size(95, 96);
            ThumbnailLoadingAnimation.TabIndex = 10;
            ThumbnailLoadingAnimation.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 10);
            label3.Name = "label3";
            label3.Size = new Size(543, 45);
            label3.TabIndex = 8;
            label3.Text = "Welcome to MM's Youtube Automation Application!\r\nChoose a Youtube video and we will create you a Youtube Short! Will that short be good? Lets find out\r\n\r\n";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(443, 73);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(85, 23);
            StartButton.TabIndex = 7;
            StartButton.Text = "Enter";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 55);
            label4.Name = "label4";
            label4.Size = new Size(142, 15);
            label4.TabIndex = 6;
            label4.Text = "Input Youtube Link Below";
            // 
            // LinkInput
            // 
            LinkInput.Location = new Point(35, 73);
            LinkInput.Name = "LinkInput";
            LinkInput.Size = new Size(400, 23);
            LinkInput.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(611, 308);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(619, 336);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube Automation - MM Reboot";
            ((System.ComponentModel.ISupportInitialize)ThumbnailPicture).EndInit();
            tabControl1.ResumeLayout(false);
            MainPage.ResumeLayout(false);
            MainPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailLoadingAnimation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox LinkInput;
        private Label label1;
        private Button StartButton;
        private Label label2;
        private TabControl tabControl1;
        private TabPage MainPage;
        private TabPage tabPage2;
        private PictureBox ThumbnailPicture;
        private Label label3;
        private Button button1;
        private Label label4;
        private TextBox textBox1;
        private PictureBox ThumbnailLoadingAnimation;
    }
}
