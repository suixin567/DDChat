namespace MainProgram.UserControls
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
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Location = new System.Drawing.Point(4, 4);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(23, 12);
            this.labelNickName.TabIndex = 0;
            this.labelNickName.Text = "...";
            this.labelNickName.Click += new System.EventHandler(this.labelNickName_Click);
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(4, 26);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(23, 12);
            this.labelContent.TabIndex = 1;
            this.labelContent.Text = "...";
            this.labelContent.Click += new System.EventHandler(this.labelContent_Click);
            // 
            // MsgTipItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelNickName);
            this.Name = "MsgTipItem";
            this.Size = new System.Drawing.Size(185, 50);
            this.Load += new System.EventHandler(this.MsgTipItem_Load);
            this.Click += new System.EventHandler(this.MsgTipItem_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Label labelContent;
    }
}
