﻿namespace PictureSlideShow
{
    partial class fFullScreen
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
            this.PBFullScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBFullScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // PBFullScreen
            // 
            this.PBFullScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBFullScreen.Location = new System.Drawing.Point(0, 0);
            this.PBFullScreen.Name = "PBFullScreen";
            this.PBFullScreen.Size = new System.Drawing.Size(800, 450);
            this.PBFullScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBFullScreen.TabIndex = 0;
            this.PBFullScreen.TabStop = false;
            this.PBFullScreen.Click += new System.EventHandler(this.PBFullScreen_Click);
            // 
            // fFullScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PBFullScreen);
            this.Name = "fFullScreen";
            this.Text = "fFullScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fFullScreen_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PBFullScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBFullScreen;
    }
}