namespace MainProgram.UserControls
{
    partial class VerifyMsgMgr
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
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Location = new System.Drawing.Point(12, 6);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxFace.TabIndex = 1;
            this.pictureBoxFace.TabStop = false;
            this.pictureBoxFace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFace_MouseDoubleClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.SystemColors.Control;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.SandyBrown;
            this.labelTitle.Location = new System.Drawing.Point(63, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(57, 12);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "验证消息";
            this.labelTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDoubleClick);
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(63, 39);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(41, 12);
            this.labelContent.TabIndex = 3;
            this.labelContent.Text = "......";
            this.labelContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelContent_MouseDoubleClick);
            // 
            // VerifyMsgMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxFace);
            this.Name = "VerifyMsgMgr";
            this.Size = new System.Drawing.Size(500, 57);
            this.Load += new System.EventHandler(this.VerifyMsgMgr_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VerifyMsgMgr_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelContent;
    }
}
