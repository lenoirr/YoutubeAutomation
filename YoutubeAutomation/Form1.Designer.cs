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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            ThumbnailPicture = new PictureBox();
            label3 = new Label();
            StartButton = new Button();
            label4 = new Label();
            LinkInput = new TextBox();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPicture).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(620, 328);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ThumbnailPicture);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(StartButton);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(LinkInput);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(612, 300);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ThumbnailPicture
            // 
            ThumbnailPicture.Location = new Point(37, 102);
            ThumbnailPicture.Name = "ThumbnailPicture";
            ThumbnailPicture.Size = new Size(401, 192);
            ThumbnailPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            ThumbnailPicture.TabIndex = 9;
            ThumbnailPicture.TabStop = false;
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
            LinkInput.Size = new Size(403, 23);
            LinkInput.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(612, 300);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(619, 328);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Youtube Automation - MM Reboot";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox LinkInput;
        private Label label1;
        private Button StartButton;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private PictureBox ThumbnailPicture;
        private Label label3;
        private Button button1;
        private Label label4;
        private TextBox textBox1;
    }
}
