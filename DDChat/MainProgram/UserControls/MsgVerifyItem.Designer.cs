﻿namespace MainProgram.UserControls
{
    partial class MsgVerifyItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgVerifyItem));
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonIgnore = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelProcessMark = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFace.Image")));
            this.pictureBoxFace.Location = new System.Drawing.Point(12, 5);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFace.TabIndex = 0;
            this.pictureBoxFace.TabStop = false;
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Location = new System.Drawing.Point(108, 14);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(59, 12);
            this.labelNickName.TabIndex = 1;
            this.labelNickName.Text = "拉取中...";
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(108, 51);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(83, 12);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "消息内容：...";
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonYes.Location = new System.Drawing.Point(432, 19);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(88, 50);
            this.buttonYes.TabIndex = 5;
            this.buttonYes.Text = "同意";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonIgnore
            // 
            this.buttonIgnore.Location = new System.Drawing.Point(547, 62);
            this.buttonIgnore.Name = "buttonIgnore";
            this.buttonIgnore.Size = new System.Drawing.Size(56, 23);
            this.buttonIgnore.TabIndex = 7;
            this.buttonIgnore.Text = "忽略";
            this.buttonIgnore.UseVisualStyleBackColor = true;
            this.buttonIgnore.Click += new System.EventHandler(this.buttonIgnore_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(108, 71);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(155, 12);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "时间：2001-11-11-10:22:21";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.ForeColor = System.Drawing.Color.Red;
            this.labelUsername.Location = new System.Drawing.Point(108, 31);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(23, 12);
            this.labelUsername.TabIndex = 9;
            this.labelUsername.Text = "...";
            // 
            // labelProcessMark
            // 
            this.labelProcessMark.AutoSize = true;
            this.labelProcessMark.Location = new System.Drawing.Point(526, 38);
            this.labelProcessMark.Name = "labelProcessMark";
            this.labelProcessMark.Size = new System.Drawing.Size(41, 12);
            this.labelProcessMark.TabIndex = 10;
            this.labelProcessMark.Text = "已处理";
            // 
            // MsgVerifyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.labelProcessMark);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonIgnore);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelNickName);
            this.Controls.Add(this.pictureBoxFace);
            this.Name = "MsgVerifyItem";
            this.Size = new System.Drawing.Size(645, 89);
            this.Load += new System.EventHandler(this.FriendVerifyItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonIgnore;
        private System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelProcessMark;
    }
}
