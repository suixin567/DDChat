﻿namespace MainProgram.UserControls
{
    partial class MsgTipItem
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgTipItem));
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelMsgNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Location = new System.Drawing.Point(45, 5);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(23, 12);
            this.labelNickName.TabIndex = 0;
            this.labelNickName.Text = "...";
            this.labelNickName.Click += new System.EventHandler(this.labelNickName_Click);
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(45, 25);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(23, 12);
            this.labelContent.TabIndex = 1;
            this.labelContent.Text = "...";
            this.labelContent.Click += new System.EventHandler(this.labelContent_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(1, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(40, 40);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.MsgTipItem_Click);
            // 
            // labelMsgNum
            // 
            this.labelMsgNum.AutoSize = true;
            this.labelMsgNum.ForeColor = System.Drawing.Color.Black;
            this.labelMsgNum.Location = new System.Drawing.Point(174, 5);
            this.labelMsgNum.Name = "labelMsgNum";
            this.labelMsgNum.Size = new System.Drawing.Size(11, 12);
            this.labelMsgNum.TabIndex = 3;
            this.labelMsgNum.Text = "0";
            // 
            // MsgTipItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelMsgNum);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelNickName);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.Name = "MsgTipItem";
            this.Size = new System.Drawing.Size(200, 50);
            this.Load += new System.EventHandler(this.MsgTipItem_Load);
            this.Click += new System.EventHandler(this.MsgTipItem_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Label labelContent;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelMsgNum;
    }
}
