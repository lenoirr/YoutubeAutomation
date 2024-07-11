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
            LinkInput = new TextBox();
            label1 = new Label();
            StartButton = new Button();
            SuspendLayout();
            // 
            // LinkInput
            // 
            LinkInput.Location = new Point(211, 214);
            LinkInput.Name = "LinkInput";
            LinkInput.Size = new Size(300, 23);
            LinkInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 196);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 1;
            label1.Text = "Input Youtube Link Below";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(211, 253);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(94, 23);
            StartButton.TabIndex = 2;
            StartButton.Text = "button1";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartButton);
            Controls.Add(label1);
            Controls.Add(LinkInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LinkInput;
        private Label label1;
        private Button StartButton;
    }
}
