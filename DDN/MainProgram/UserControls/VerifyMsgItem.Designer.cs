namespace MainProgram.UserControls
{
    partial class VerifyMsgItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyMsgItem));
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCont = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFace.Image")));
            this.pictureBoxFace.Location = new System.Drawing.Point(12, 6);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            // labelCont
            // 
            this.labelCont.AutoSize = true;
            this.labelCont.Location = new System.Drawing.Point(63, 39);
            this.labelCont.Name = "labelCont";
            this.labelCont.Size = new System.Drawing.Size(41, 12);
            this.labelCont.TabIndex = 3;
            this.labelCont.Text = "......";
            this.labelCont.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelContent_MouseDoubleClick);
            // 
            // VerifyMsgItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCont);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxFace);
            this.Name = "VerifyMsgItem";
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
        private System.Windows.Forms.Label labelCont;
    }
}
