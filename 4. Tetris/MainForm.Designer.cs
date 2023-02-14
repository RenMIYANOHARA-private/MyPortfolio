namespace tetris
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.restart = new System.Windows.Forms.Button();
            this.label_tetris = new System.Windows.Forms.Label();
            this.label_Comment = new System.Windows.Forms.Label();
            this.label_Message = new System.Windows.Forms.Label();
            this.label_Control = new System.Windows.Forms.Label();
            this.label_A = new System.Windows.Forms.Label();
            this.label_D = new System.Windows.Forms.Label();
            this.label_W = new System.Windows.Forms.Label();
            this.label_S = new System.Windows.Forms.Label();
            this.label_Score = new System.Windows.Forms.Label();
            this.label_ScoreV = new System.Windows.Forms.Label();
            this.label_BestScore = new System.Windows.Forms.Label();
            this.label_BestV = new System.Windows.Forms.Label();
            this.label_saftyMass = new System.Windows.Forms.Label();
            this.label_deathMass = new System.Windows.Forms.Label();
            this.label_com1 = new System.Windows.Forms.Label();
            this.label_com2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // restart
            // 
            this.restart.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restart.ForeColor = System.Drawing.Color.Blue;
            this.restart.Location = new System.Drawing.Point(561, 490);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(116, 32);
            this.restart.TabIndex = 0;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // label_tetris
            // 
            this.label_tetris.AutoSize = true;
            this.label_tetris.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tetris.Location = new System.Drawing.Point(50, 10);
            this.label_tetris.Name = "label_tetris";
            this.label_tetris.Size = new System.Drawing.Size(65, 27);
            this.label_tetris.TabIndex = 1;
            this.label_tetris.Text = "Tetris";
            // 
            // label_Comment
            // 
            this.label_Comment.AutoSize = true;
            this.label_Comment.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Comment.Location = new System.Drawing.Point(510, 165);
            this.label_Comment.Name = "label_Comment";
            this.label_Comment.Size = new System.Drawing.Size(68, 19);
            this.label_Comment.TabIndex = 2;
            this.label_Comment.Text = "Comment";
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Message.Location = new System.Drawing.Point(629, 106);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(27, 19);
            this.label_Message.TabIndex = 3;
            this.label_Message.Text = "---";
            // 
            // label_Control
            // 
            this.label_Control.AutoSize = true;
            this.label_Control.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Control.Location = new System.Drawing.Point(510, 18);
            this.label_Control.Name = "label_Control";
            this.label_Control.Size = new System.Drawing.Size(55, 19);
            this.label_Control.TabIndex = 4;
            this.label_Control.Text = "Control";
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.BackColor = System.Drawing.Color.Silver;
            this.label_A.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_A.Location = new System.Drawing.Point(495, 94);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(33, 31);
            this.label_A.TabIndex = 5;
            this.label_A.Text = "A";
            // 
            // label_D
            // 
            this.label_D.AutoSize = true;
            this.label_D.BackColor = System.Drawing.Color.Silver;
            this.label_D.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_D.Location = new System.Drawing.Point(569, 94);
            this.label_D.Name = "label_D";
            this.label_D.Size = new System.Drawing.Size(33, 31);
            this.label_D.TabIndex = 6;
            this.label_D.Text = "D";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.BackColor = System.Drawing.Color.Silver;
            this.label_W.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_W.Location = new System.Drawing.Point(524, 58);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(39, 31);
            this.label_W.TabIndex = 7;
            this.label_W.Text = "W";
            // 
            // label_S
            // 
            this.label_S.AutoSize = true;
            this.label_S.BackColor = System.Drawing.Color.Silver;
            this.label_S.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_S.Location = new System.Drawing.Point(534, 94);
            this.label_S.Name = "label_S";
            this.label_S.Size = new System.Drawing.Size(29, 31);
            this.label_S.TabIndex = 8;
            this.label_S.Text = "S";
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Score.Location = new System.Drawing.Point(510, 417);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(45, 19);
            this.label_Score.TabIndex = 9;
            this.label_Score.Text = "Score";
            // 
            // label_ScoreV
            // 
            this.label_ScoreV.AutoSize = true;
            this.label_ScoreV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ScoreV.Location = new System.Drawing.Point(587, 417);
            this.label_ScoreV.Name = "label_ScoreV";
            this.label_ScoreV.Size = new System.Drawing.Size(27, 19);
            this.label_ScoreV.TabIndex = 10;
            this.label_ScoreV.Text = "---";
            // 
            // label_BestScore
            // 
            this.label_BestScore.AutoSize = true;
            this.label_BestScore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BestScore.Location = new System.Drawing.Point(510, 449);
            this.label_BestScore.Name = "label_BestScore";
            this.label_BestScore.Size = new System.Drawing.Size(76, 19);
            this.label_BestScore.TabIndex = 11;
            this.label_BestScore.Text = "Best Score";
            // 
            // label_BestV
            // 
            this.label_BestV.AutoSize = true;
            this.label_BestV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BestV.Location = new System.Drawing.Point(614, 449);
            this.label_BestV.Name = "label_BestV";
            this.label_BestV.Size = new System.Drawing.Size(27, 19);
            this.label_BestV.TabIndex = 12;
            this.label_BestV.Text = "---";
            // 
            // label_saftyMass
            // 
            this.label_saftyMass.AutoSize = true;
            this.label_saftyMass.BackColor = System.Drawing.Color.Aquamarine;
            this.label_saftyMass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_saftyMass.Location = new System.Drawing.Point(544, 244);
            this.label_saftyMass.Name = "label_saftyMass";
            this.label_saftyMass.Size = new System.Drawing.Size(25, 19);
            this.label_saftyMass.TabIndex = 13;
            this.label_saftyMass.Text = "    ";
            // 
            // label_deathMass
            // 
            this.label_deathMass.AutoSize = true;
            this.label_deathMass.BackColor = System.Drawing.Color.LemonChiffon;
            this.label_deathMass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_deathMass.Location = new System.Drawing.Point(544, 204);
            this.label_deathMass.Name = "label_deathMass";
            this.label_deathMass.Size = new System.Drawing.Size(25, 19);
            this.label_deathMass.TabIndex = 14;
            this.label_deathMass.Text = "    ";
            // 
            // label_com1
            // 
            this.label_com1.AutoSize = true;
            this.label_com1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_com1.Location = new System.Drawing.Point(591, 204);
            this.label_com1.Name = "label_com1";
            this.label_com1.Size = new System.Drawing.Size(91, 19);
            this.label_com1.TabIndex = 15;
            this.label_com1.Text = "... Death area";
            // 
            // label_com2
            // 
            this.label_com2.AutoSize = true;
            this.label_com2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_com2.Location = new System.Drawing.Point(591, 244);
            this.label_com2.Name = "label_com2";
            this.label_com2.Size = new System.Drawing.Size(86, 19);
            this.label_com2.TabIndex = 16;
            this.label_com2.Text = "... Safty area";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.Controls.Add(this.label_com2);
            this.Controls.Add(this.label_com1);
            this.Controls.Add(this.label_deathMass);
            this.Controls.Add(this.label_saftyMass);
            this.Controls.Add(this.label_BestV);
            this.Controls.Add(this.label_BestScore);
            this.Controls.Add(this.label_ScoreV);
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.label_S);
            this.Controls.Add(this.label_W);
            this.Controls.Add(this.label_D);
            this.Controls.Add(this.label_A);
            this.Controls.Add(this.label_Control);
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.label_Comment);
            this.Controls.Add(this.label_tetris);
            this.Controls.Add(this.restart);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "jj";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Label label_tetris;
        private System.Windows.Forms.Label label_Comment;
        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.Label label_Control;
        private System.Windows.Forms.Label label_A;
        private System.Windows.Forms.Label label_D;
        private System.Windows.Forms.Label label_W;
        private System.Windows.Forms.Label label_S;
        private System.Windows.Forms.Label label_Score;
        private System.Windows.Forms.Label label_ScoreV;
        private System.Windows.Forms.Label label_BestScore;
        private System.Windows.Forms.Label label_BestV;
        private System.Windows.Forms.Label label_saftyMass;
        private System.Windows.Forms.Label label_deathMass;
        private System.Windows.Forms.Label label_com1;
        private System.Windows.Forms.Label label_com2;
    }
}

