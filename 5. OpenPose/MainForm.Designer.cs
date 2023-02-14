namespace WebCameraKinematics2
{
    partial class MainForm
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
            this.label_History = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.TextBox();
            this.label_LocationW = new System.Windows.Forms.Label();
            this.label_Location = new System.Windows.Forms.Label();
            this.calculate = new System.Windows.Forms.Button();
            this.video = new System.Windows.Forms.PictureBox();
            this.label_video = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.label_TotalFiles = new System.Windows.Forms.Label();
            this.label_TotalFilesV = new System.Windows.Forms.Label();
            this.label_CurrentFileV = new System.Windows.Forms.Label();
            this.label_CurrentFile = new System.Windows.Forms.Label();
            this.label_Frame = new System.Windows.Forms.Label();
            this.label_CurrentFrameV = new System.Windows.Forms.Label();
            this.label_FPSV = new System.Windows.Forms.Label();
            this.label_FPS = new System.Windows.Forms.Label();
            this.label_TotalFramesV = new System.Windows.Forms.Label();
            this.label_TotalFrames = new System.Windows.Forms.Label();
            this.label_Load = new System.Windows.Forms.Label();
            this.label_Calculate = new System.Windows.Forms.Label();
            this.label_Save = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.video)).BeginInit();
            this.SuspendLayout();
            // 
            // label_History
            // 
            this.label_History.AutoSize = true;
            this.label_History.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_History.Location = new System.Drawing.Point(409, 29);
            this.label_History.Name = "label_History";
            this.label_History.Size = new System.Drawing.Size(53, 19);
            this.label_History.TabIndex = 97;
            this.label_History.Text = "History";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(413, 49);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(357, 332);
            this.logBox.TabIndex = 96;
            // 
            // label_LocationW
            // 
            this.label_LocationW.AutoSize = true;
            this.label_LocationW.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LocationW.Location = new System.Drawing.Point(152, 397);
            this.label_LocationW.Name = "label_LocationW";
            this.label_LocationW.Size = new System.Drawing.Size(17, 19);
            this.label_LocationW.TabIndex = 95;
            this.label_LocationW.Text = "..";
            // 
            // label_Location
            // 
            this.label_Location.AutoSize = true;
            this.label_Location.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Location.Location = new System.Drawing.Point(34, 397);
            this.label_Location.Name = "label_Location";
            this.label_Location.Size = new System.Drawing.Size(62, 19);
            this.label_Location.TabIndex = 94;
            this.label_Location.Text = "Location";
            // 
            // calculate
            // 
            this.calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculate.ForeColor = System.Drawing.Color.Green;
            this.calculate.Location = new System.Drawing.Point(38, 351);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(110, 30);
            this.calculate.TabIndex = 93;
            this.calculate.Text = "Calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // video
            // 
            this.video.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.video.Location = new System.Drawing.Point(38, 49);
            this.video.Name = "video";
            this.video.Size = new System.Drawing.Size(320, 222);
            this.video.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.video.TabIndex = 92;
            this.video.TabStop = false;
            // 
            // label_video
            // 
            this.label_video.AutoSize = true;
            this.label_video.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_video.Location = new System.Drawing.Point(34, 29);
            this.label_video.Name = "label_video";
            this.label_video.Size = new System.Drawing.Size(45, 19);
            this.label_video.TabIndex = 91;
            this.label_video.Text = "Video";
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(822, 24);
            this.menuStrip.TabIndex = 100;
            this.menuStrip.Text = "menuStrip1";
            // 
            // label_TotalFiles
            // 
            this.label_TotalFiles.AutoSize = true;
            this.label_TotalFiles.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalFiles.Location = new System.Drawing.Point(200, 420);
            this.label_TotalFiles.Name = "label_TotalFiles";
            this.label_TotalFiles.Size = new System.Drawing.Size(90, 19);
            this.label_TotalFiles.TabIndex = 101;
            this.label_TotalFiles.Text = "/     Total files";
            // 
            // label_TotalFilesV
            // 
            this.label_TotalFilesV.AutoSize = true;
            this.label_TotalFilesV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalFilesV.Location = new System.Drawing.Point(332, 420);
            this.label_TotalFilesV.Name = "label_TotalFilesV";
            this.label_TotalFilesV.Size = new System.Drawing.Size(17, 19);
            this.label_TotalFilesV.TabIndex = 102;
            this.label_TotalFilesV.Text = "..";
            // 
            // label_CurrentFileV
            // 
            this.label_CurrentFileV.AutoSize = true;
            this.label_CurrentFileV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentFileV.Location = new System.Drawing.Point(152, 420);
            this.label_CurrentFileV.Name = "label_CurrentFileV";
            this.label_CurrentFileV.Size = new System.Drawing.Size(17, 19);
            this.label_CurrentFileV.TabIndex = 104;
            this.label_CurrentFileV.Text = "..";
            // 
            // label_CurrentFile
            // 
            this.label_CurrentFile.AutoSize = true;
            this.label_CurrentFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentFile.Location = new System.Drawing.Point(34, 420);
            this.label_CurrentFile.Name = "label_CurrentFile";
            this.label_CurrentFile.Size = new System.Drawing.Size(76, 19);
            this.label_CurrentFile.TabIndex = 103;
            this.label_CurrentFile.Text = "Current file";
            // 
            // label_Frame
            // 
            this.label_Frame.AutoSize = true;
            this.label_Frame.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Frame.Location = new System.Drawing.Point(34, 443);
            this.label_Frame.Name = "label_Frame";
            this.label_Frame.Size = new System.Drawing.Size(93, 19);
            this.label_Frame.TabIndex = 105;
            this.label_Frame.Text = "Current frame";
            // 
            // label_CurrentFrameV
            // 
            this.label_CurrentFrameV.AutoSize = true;
            this.label_CurrentFrameV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentFrameV.Location = new System.Drawing.Point(152, 443);
            this.label_CurrentFrameV.Name = "label_CurrentFrameV";
            this.label_CurrentFrameV.Size = new System.Drawing.Size(17, 19);
            this.label_CurrentFrameV.TabIndex = 106;
            this.label_CurrentFrameV.Text = "..";
            // 
            // label_FPSV
            // 
            this.label_FPSV.AutoSize = true;
            this.label_FPSV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FPSV.Location = new System.Drawing.Point(152, 466);
            this.label_FPSV.Name = "label_FPSV";
            this.label_FPSV.Size = new System.Drawing.Size(17, 19);
            this.label_FPSV.TabIndex = 108;
            this.label_FPSV.Text = "..";
            // 
            // label_FPS
            // 
            this.label_FPS.AutoSize = true;
            this.label_FPS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FPS.Location = new System.Drawing.Point(34, 466);
            this.label_FPS.Name = "label_FPS";
            this.label_FPS.Size = new System.Drawing.Size(36, 19);
            this.label_FPS.TabIndex = 107;
            this.label_FPS.Text = "FPS";
            // 
            // label_TotalFramesV
            // 
            this.label_TotalFramesV.AutoSize = true;
            this.label_TotalFramesV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalFramesV.Location = new System.Drawing.Point(332, 443);
            this.label_TotalFramesV.Name = "label_TotalFramesV";
            this.label_TotalFramesV.Size = new System.Drawing.Size(17, 19);
            this.label_TotalFramesV.TabIndex = 110;
            this.label_TotalFramesV.Text = "..";
            // 
            // label_TotalFrames
            // 
            this.label_TotalFrames.AutoSize = true;
            this.label_TotalFrames.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalFrames.Location = new System.Drawing.Point(200, 443);
            this.label_TotalFrames.Name = "label_TotalFrames";
            this.label_TotalFrames.Size = new System.Drawing.Size(107, 19);
            this.label_TotalFrames.TabIndex = 109;
            this.label_TotalFrames.Text = "/     Total frames";
            // 
            // label_Load
            // 
            this.label_Load.AutoSize = true;
            this.label_Load.BackColor = System.Drawing.Color.Silver;
            this.label_Load.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Load.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Load.Location = new System.Drawing.Point(39, 283);
            this.label_Load.Name = "label_Load";
            this.label_Load.Size = new System.Drawing.Size(59, 25);
            this.label_Load.TabIndex = 111;
            this.label_Load.Text = " Load";
            // 
            // label_Calculate
            // 
            this.label_Calculate.AutoSize = true;
            this.label_Calculate.BackColor = System.Drawing.Color.Silver;
            this.label_Calculate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Calculate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Calculate.Location = new System.Drawing.Point(156, 283);
            this.label_Calculate.Name = "label_Calculate";
            this.label_Calculate.Size = new System.Drawing.Size(91, 25);
            this.label_Calculate.TabIndex = 112;
            this.label_Calculate.Text = "Calculate";
            // 
            // label_Save
            // 
            this.label_Save.AutoSize = true;
            this.label_Save.BackColor = System.Drawing.Color.Silver;
            this.label_Save.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Save.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Save.Location = new System.Drawing.Point(305, 283);
            this.label_Save.Name = "label_Save";
            this.label_Save.Size = new System.Drawing.Size(51, 25);
            this.label_Save.TabIndex = 113;
            this.label_Save.Text = "Save";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 114;
            this.label1.Text = ">>>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(253, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 23);
            this.label2.TabIndex = 115;
            this.label2.Text = ">>>";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 495);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Save);
            this.Controls.Add(this.label_Calculate);
            this.Controls.Add(this.label_Load);
            this.Controls.Add(this.label_TotalFramesV);
            this.Controls.Add(this.label_TotalFrames);
            this.Controls.Add(this.label_FPSV);
            this.Controls.Add(this.label_FPS);
            this.Controls.Add(this.label_CurrentFrameV);
            this.Controls.Add(this.label_Frame);
            this.Controls.Add(this.label_CurrentFileV);
            this.Controls.Add(this.label_CurrentFile);
            this.Controls.Add(this.label_TotalFilesV);
            this.Controls.Add(this.label_TotalFiles);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.label_History);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label_LocationW);
            this.Controls.Add(this.label_Location);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.video);
            this.Controls.Add(this.label_video);
            this.Name = "MainForm";
            this.Text = "Openpose calculator";
            ((System.ComponentModel.ISupportInitialize)(this.video)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_History;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label label_LocationW;
        private System.Windows.Forms.Label label_Location;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.PictureBox video;
        private System.Windows.Forms.Label label_video;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Label label_TotalFiles;
        private System.Windows.Forms.Label label_TotalFilesV;
        private System.Windows.Forms.Label label_CurrentFileV;
        private System.Windows.Forms.Label label_CurrentFile;
        private System.Windows.Forms.Label label_Frame;
        private System.Windows.Forms.Label label_CurrentFrameV;
        private System.Windows.Forms.Label label_FPSV;
        private System.Windows.Forms.Label label_FPS;
        private System.Windows.Forms.Label label_TotalFramesV;
        private System.Windows.Forms.Label label_TotalFrames;
        private System.Windows.Forms.Label label_Load;
        private System.Windows.Forms.Label label_Calculate;
        private System.Windows.Forms.Label label_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}