namespace SkribblBot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawingProgressBar = new System.Windows.Forms.ProgressBar();
            this.StartButton = new System.Windows.Forms.Button();
            this.ConfigureButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.filePathText = new System.Windows.Forms.Label();
            this.pictureBoxOrigin = new System.Windows.Forms.PictureBox();
            this.pictureBoxGray = new System.Windows.Forms.PictureBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingProgressBar
            // 
            this.DrawingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DrawingProgressBar.Location = new System.Drawing.Point(112, 87);
            this.DrawingProgressBar.Name = "DrawingProgressBar";
            this.DrawingProgressBar.Size = new System.Drawing.Size(211, 23);
            this.DrawingProgressBar.TabIndex = 3;
            this.DrawingProgressBar.Click += new System.EventHandler(this.DrawingProgressBar_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(276, 115);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 25);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start (y)";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ConfigureButton
            // 
            this.ConfigureButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfigureButton.Location = new System.Drawing.Point(170, 115);
            this.ConfigureButton.Name = "ConfigureButton";
            this.ConfigureButton.Size = new System.Drawing.Size(100, 25);
            this.ConfigureButton.TabIndex = 1;
            this.ConfigureButton.Text = "Configure (u)";
            this.ConfigureButton.UseVisualStyleBackColor = true;
            this.ConfigureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitButton.Location = new System.Drawing.Point(64, 115);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 25);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit (i)";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // filePathText
            // 
            this.filePathText.AutoSize = true;
            this.filePathText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePathText.Location = new System.Drawing.Point(0, 0);
            this.filePathText.Name = "filePathText";
            this.filePathText.Size = new System.Drawing.Size(10, 16);
            this.filePathText.TabIndex = 4;
            this.filePathText.Text = " ";
            this.filePathText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxOrigin
            // 
            this.pictureBoxOrigin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxOrigin.Location = new System.Drawing.Point(112, 25);
            this.pictureBoxOrigin.Name = "pictureBoxOrigin";
            this.pictureBoxOrigin.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxOrigin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOrigin.TabIndex = 5;
            this.pictureBoxOrigin.TabStop = false;
            // 
            // pictureBoxGray
            // 
            this.pictureBoxGray.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxGray.Location = new System.Drawing.Point(223, 25);
            this.pictureBoxGray.Name = "pictureBoxGray";
            this.pictureBoxGray.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGray.TabIndex = 6;
            this.pictureBoxGray.TabStop = false;
            // 
            // SizeLabel
            // 
            this.SizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(3, 180);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(10, 16);
            this.SizeLabel.TabIndex = 7;
            this.SizeLabel.Text = " ";
            // 
            // TimerLabel
            // 
            this.TimerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Location = new System.Drawing.Point(329, 94);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(0, 16);
            this.TimerLabel.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(453, 201);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.pictureBoxGray);
            this.Controls.Add(this.pictureBoxOrigin);
            this.Controls.Add(this.filePathText);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ConfigureButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.DrawingProgressBar);
            this.Name = "Form1";
            this.Text = "SkribblBot";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar DrawingProgressBar;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ConfigureButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label filePathText;
        private System.Windows.Forms.PictureBox pictureBoxOrigin;
        private System.Windows.Forms.PictureBox pictureBoxGray;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label TimerLabel;
    }
}

