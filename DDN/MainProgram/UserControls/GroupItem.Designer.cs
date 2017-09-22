namespace MainProgram.UserControls
{
    partial class GroupItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupItem));
            this.pictureBoxGroupFace = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出这个公司ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupFace)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxGroupFace
            // 
            this.pictureBoxGroupFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGroupFace.Image")));
            this.pictureBoxGroupFace.Location = new System.Drawing.Point(12, 6);
            this.pictureBoxGroupFace.Name = "pictureBoxGroupFace";
            this.pictureBoxGroupFace.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxGroupFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGroupFace.TabIndex = 0;
            this.pictureBoxGroupFace.TabStop = false;
            this.pictureBoxGroupFace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGroupFace_MouseDoubleClick);
            this.pictureBoxGroupFace.MouseEnter += new System.EventHandler(this.pictureBoxGroupFace_MouseEnter);
            this.pictureBoxGroupFace.MouseLeave += new System.EventHandler(this.pictureBoxGroupFace_MouseLeave);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(75, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "......";
            this.labelName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelName_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出这个公司ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 26);
            // 
            // 退出这个公司ToolStripMenuItem
            // 
            this.退出这个公司ToolStripMenuItem.Name = "退出这个公司ToolStripMenuItem";
            this.退出这个公司ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出这个公司ToolStripMenuItem.Text = "退出这个群";
            this.退出这个公司ToolStripMenuItem.Click += new System.EventHandler(this.退出这个群ToolStripMenuItem_Click);
            // 
            // GroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureBoxGroupFace);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Name = "GroupItem";
            this.Size = new System.Drawing.Size(500, 57);
            this.Load += new System.EventHandler(this.GroupItem_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GroupItem_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupFace)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxGroupFace;
        public System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 退出这个公司ToolStripMenuItem;
    }
}
