namespace MainProgram.UserControls
{
    partial class DialogueItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogueItem));
            this.PictureBoxDialogueFace = new System.Windows.Forms.PictureBox();
            this.LabelNickName = new System.Windows.Forms.Label();
            this.LabelHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDialogueFace)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxDialogueFace
            // 
            this.PictureBoxDialogueFace.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxDialogueFace.Image")));
            this.PictureBoxDialogueFace.Location = new System.Drawing.Point(12, 6);
            this.PictureBoxDialogueFace.Name = "PictureBoxDialogueFace";
            this.PictureBoxDialogueFace.Size = new System.Drawing.Size(45, 45);
            this.PictureBoxDialogueFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxDialogueFace.TabIndex = 1;
            this.PictureBoxDialogueFace.TabStop = false;
            // 
            // LabelNickName
            // 
            this.LabelNickName.AutoSize = true;
            this.LabelNickName.BackColor = System.Drawing.SystemColors.Info;
            this.LabelNickName.Location = new System.Drawing.Point(70, 10);
            this.LabelNickName.Name = "LabelNickName";
            this.LabelNickName.Size = new System.Drawing.Size(41, 12);
            this.LabelNickName.TabIndex = 2;
            this.LabelNickName.Text = "叮叮鸟";
            // 
            // LabelHistory
            // 
            this.LabelHistory.AutoSize = true;
            this.LabelHistory.Location = new System.Drawing.Point(70, 35);
            this.LabelHistory.Name = "LabelHistory";
            this.LabelHistory.Size = new System.Drawing.Size(41, 12);
            this.LabelHistory.TabIndex = 3;
            this.LabelHistory.Text = "......";
            // 
            // DialogueItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.LabelHistory);
            this.Controls.Add(this.LabelNickName);
            this.Controls.Add(this.PictureBoxDialogueFace);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Name = "DialogueItem";
            this.Size = new System.Drawing.Size(500, 57);
            this.Load += new System.EventHandler(this.DialogueItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDialogueFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxDialogueFace;
        private System.Windows.Forms.Label LabelNickName;
        private System.Windows.Forms.Label LabelHistory;
    }
}
