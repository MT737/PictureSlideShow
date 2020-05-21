namespace PictureSlideShow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.NextFolder = new System.Windows.Forms.Button();
            this.NextImage = new System.Windows.Forms.Button();
            this.PreviousImage = new System.Windows.Forms.Button();
            this.BtnPreviousFolder = new System.Windows.Forms.Button();
            this.BtnPauseShow = new System.Windows.Forms.Button();
            this.BtnStopSlide = new System.Windows.Forms.Button();
            this.BtnStartSlide = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnFullScreen = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnFullScreen, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 649);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.NextFolder);
            this.flowLayoutPanel1.Controls.Add(this.NextImage);
            this.flowLayoutPanel1.Controls.Add(this.PreviousImage);
            this.flowLayoutPanel1.Controls.Add(this.BtnPreviousFolder);
            this.flowLayoutPanel1.Controls.Add(this.BtnPauseShow);
            this.flowLayoutPanel1.Controls.Add(this.BtnStopSlide);
            this.flowLayoutPanel1.Controls.Add(this.BtnStartSlide);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(83, 622);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(519, 24);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // NextFolder
            // 
            this.NextFolder.AutoSize = true;
            this.NextFolder.Location = new System.Drawing.Point(466, 3);
            this.NextFolder.Name = "NextFolder";
            this.NextFolder.Size = new System.Drawing.Size(50, 23);
            this.NextFolder.TabIndex = 0;
            this.NextFolder.Text = ">>";
            this.NextFolder.UseVisualStyleBackColor = true;
            this.NextFolder.Click += new System.EventHandler(this.NextFolder_Click);
            // 
            // NextImage
            // 
            this.NextImage.AutoSize = true;
            this.NextImage.Location = new System.Drawing.Point(410, 3);
            this.NextImage.Name = "NextImage";
            this.NextImage.Size = new System.Drawing.Size(50, 23);
            this.NextImage.TabIndex = 1;
            this.NextImage.Text = ">";
            this.NextImage.UseVisualStyleBackColor = true;
            this.NextImage.Click += new System.EventHandler(this.NextImage_Click);
            // 
            // PreviousImage
            // 
            this.PreviousImage.AutoSize = true;
            this.PreviousImage.Location = new System.Drawing.Point(354, 3);
            this.PreviousImage.Name = "PreviousImage";
            this.PreviousImage.Size = new System.Drawing.Size(50, 23);
            this.PreviousImage.TabIndex = 2;
            this.PreviousImage.Text = "<";
            this.PreviousImage.UseVisualStyleBackColor = true;
            this.PreviousImage.Click += new System.EventHandler(this.PreviousImage_Click);
            // 
            // BtnPreviousFolder
            // 
            this.BtnPreviousFolder.AutoSize = true;
            this.BtnPreviousFolder.Location = new System.Drawing.Point(298, 3);
            this.BtnPreviousFolder.Name = "BtnPreviousFolder";
            this.BtnPreviousFolder.Size = new System.Drawing.Size(50, 23);
            this.BtnPreviousFolder.TabIndex = 3;
            this.BtnPreviousFolder.Text = "<<";
            this.BtnPreviousFolder.UseVisualStyleBackColor = true;
            this.BtnPreviousFolder.Click += new System.EventHandler(this.BtnPreviousFolder_Click);
            // 
            // BtnPauseShow
            // 
            this.BtnPauseShow.AutoSize = true;
            this.BtnPauseShow.Location = new System.Drawing.Point(215, 3);
            this.BtnPauseShow.Name = "BtnPauseShow";
            this.BtnPauseShow.Size = new System.Drawing.Size(77, 23);
            this.BtnPauseShow.TabIndex = 6;
            this.BtnPauseShow.Text = "| |";
            this.BtnPauseShow.UseVisualStyleBackColor = true;
            this.BtnPauseShow.Click += new System.EventHandler(this.BtnPauseShow_Click);
            // 
            // BtnStopSlide
            // 
            this.BtnStopSlide.AutoSize = true;
            this.BtnStopSlide.Location = new System.Drawing.Point(134, 3);
            this.BtnStopSlide.Name = "BtnStopSlide";
            this.BtnStopSlide.Size = new System.Drawing.Size(75, 23);
            this.BtnStopSlide.TabIndex = 4;
            this.BtnStopSlide.Text = "Stop Show";
            this.BtnStopSlide.UseVisualStyleBackColor = true;
            this.BtnStopSlide.Click += new System.EventHandler(this.BtnStopSlide_Click);
            // 
            // BtnStartSlide
            // 
            this.BtnStartSlide.AutoSize = true;
            this.BtnStartSlide.Location = new System.Drawing.Point(53, 3);
            this.BtnStartSlide.Name = "BtnStartSlide";
            this.BtnStartSlide.Size = new System.Drawing.Size(75, 23);
            this.BtnStartSlide.TabIndex = 5;
            this.BtnStartSlide.Text = "New Show";
            this.BtnStartSlide.UseVisualStyleBackColor = true;
            this.BtnStartSlide.Click += new System.EventHandler(this.BtnStartSlide_Click);
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 613);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // BtnFullScreen
            // 
            this.BtnFullScreen.Location = new System.Drawing.Point(3, 622);
            this.BtnFullScreen.Name = "BtnFullScreen";
            this.BtnFullScreen.Size = new System.Drawing.Size(74, 23);
            this.BtnFullScreen.TabIndex = 2;
            this.BtnFullScreen.Text = "Full Screen";
            this.BtnFullScreen.UseVisualStyleBackColor = true;
            this.BtnFullScreen.Click += new System.EventHandler(this.BtnFullScreen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 649);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Picture Slide Show";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button NextFolder;
        private System.Windows.Forms.Button NextImage;
        private System.Windows.Forms.Button PreviousImage;
        private System.Windows.Forms.Button BtnPreviousFolder;
        private System.Windows.Forms.Button BtnStopSlide;
        private System.Windows.Forms.Button BtnStartSlide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnFullScreen;
        private System.Windows.Forms.Button BtnPauseShow;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

