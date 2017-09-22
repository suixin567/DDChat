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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogueItem));
            this.PictureBoxDialogueFace = new System.Windows.Forms.PictureBox();
            this.LabelNickName = new System.Windows.Forms.Label();
            this.LabelHistory = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移除会话ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDialogueFace)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.PictureBoxDialogueFace.MouseEnter += new System.EventHandler(this.PictureBoxDialogueFace_MouseEnter);
            this.PictureBoxDialogueFace.MouseLeave += new System.EventHandler(this.PictureBoxDialogueFace_MouseLeave);
            // 
            // LabelNickName
            // 
            this.LabelNickName.AutoSize = true;
            this.LabelNickName.BackColor = System.Drawing.SystemColors.Info;
            this.LabelNickName.Location = new System.Drawing.Point(70, 10);
            this.LabelNickName.Name = "LabelNickName";
            this.LabelNickName.Size = new System.Drawing.Size(77, 12);
            this.LabelNickName.TabIndex = 2;
            this.LabelNickName.Text = "聊天对象昵称";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移除会话ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 移除会话ToolStripMenuItem
            // 
            this.移除会话ToolStripMenuItem.Name = "移除会话ToolStripMenuItem";
            this.移除会话ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.移除会话ToolStripMenuItem.Text = "移除会话";
            this.移除会话ToolStripMenuItem.Click += new System.EventHandler(this.移除会话ToolStripMenuItem_Click);
            // 
            // DialogueItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.LabelHistory);
            this.Controls.Add(this.LabelNickName);
            this.Controls.Add(this.PictureBoxDialogueFace);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Name = "DialogueItem";
            this.Size = new System.Drawing.Size(500, 57);
            this.Load += new System.EventHandler(this.DialogueItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDialogueFace)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxDialogueFace;
        private System.Windows.Forms.Label LabelNickName;
        private System.Windows.Forms.Label LabelHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 移除会话ToolStripMenuItem;
    }
}
