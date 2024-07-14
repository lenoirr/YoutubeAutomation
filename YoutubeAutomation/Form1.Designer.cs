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
            LinkInput = new TextBox();
            label1 = new Label();
            StartButton = new Button();
            label2 = new Label();
            thumbnailImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)thumbnailImage).BeginInit();
            SuspendLayout();
            // 
            // LinkInput
            // 
            LinkInput.Location = new Point(10, 95);
            LinkInput.Name = "LinkInput";
            LinkInput.Size = new Size(403, 23);
            LinkInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 77);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 1;
            label1.Text = "Input Youtube Link Below";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(418, 95);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(85, 20);
            StartButton.TabIndex = 2;
            StartButton.Text = "Enter";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 7);
            label2.Name = "label2";
            label2.Size = new Size(543, 45);
            label2.TabIndex = 3;
            label2.Text = "Welcome to MM's Youtube Automation Application!\r\nChoose a Youtube video and we will create you a Youtube Short! Will that short be good? Lets find out\r\n\r\n";
            // 
            // thumbnailImage
            // 
            thumbnailImage.Location = new Point(12, 124);
            thumbnailImage.Name = "thumbnailImage";
            thumbnailImage.Size = new Size(401, 192);
            thumbnailImage.SizeMode = PictureBoxSizeMode.StretchImage;
            thumbnailImage.TabIndex = 4;
            thumbnailImage.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(618, 328);
            Controls.Add(thumbnailImage);
            Controls.Add(label2);
            Controls.Add(StartButton);
            Controls.Add(label1);
            Controls.Add(LinkInput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Youtube Automation - MM Reboot";
            ((System.ComponentModel.ISupportInitialize)thumbnailImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LinkInput;
        private Label label1;
        private Button StartButton;
        private Label label2;
        private PictureBox thumbnailImage;
    }
}
