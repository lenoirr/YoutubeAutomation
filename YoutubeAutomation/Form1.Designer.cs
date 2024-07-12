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
            SuspendLayout();
            // 
            // LinkInput
            // 
            LinkInput.Location = new Point(12, 127);
            LinkInput.Margin = new Padding(3, 4, 3, 4);
            LinkInput.Name = "LinkInput";
            LinkInput.Size = new Size(460, 27);
            LinkInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(176, 20);
            label1.TabIndex = 1;
            label1.Text = "Input Youtube Link Below";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(478, 127);
            StartButton.Margin = new Padding(3, 4, 3, 4);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(97, 27);
            StartButton.TabIndex = 2;
            StartButton.Text = "Enter";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(685, 60);
            label2.TabIndex = 3;
            label2.Text = "Welcome to MM's Youtube Automation Application!\r\nChoose a Youtube video and we will create you a Youtube Short! Will that short be good? Lets find out\r\n\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(706, 251);
            Controls.Add(label2);
            Controls.Add(StartButton);
            Controls.Add(label1);
            Controls.Add(LinkInput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Youtube Automation - MM Reboot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LinkInput;
        private Label label1;
        private Button StartButton;
        private Label label2;
    }
}
