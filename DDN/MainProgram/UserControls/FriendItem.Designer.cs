namespace MainProgram.UserControls
{
    partial class FriendItem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendItem));
            this.friendFacePictureBox = new System.Windows.Forms.PictureBox();
            this.friendNickName = new System.Windows.Forms.Label();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.contextMenuStripFriendItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.friendFacePictureBox)).BeginInit();
            this.contextMenuStripFriendItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // friendFacePictureBox
            // 
            this.friendFacePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("friendFacePictureBox.Image")));
            this.friendFacePictureBox.Location = new System.Drawing.Point(12, 6);
            this.friendFacePictureBox.Name = "friendFacePictureBox";
            this.friendFacePictureBox.Size = new System.Drawing.Size(45, 45);
            this.friendFacePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.friendFacePictureBox.TabIndex = 0;
            this.friendFacePictureBox.TabStop = false;
            this.friendFacePictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.friendFacePictureBox_MouseDoubleClick);
            // 
            // friendNickName
            // 
            this.friendNickName.AutoSize = true;
            this.friendNickName.BackColor = System.Drawing.SystemColors.Info;
            this.friendNickName.Location = new System.Drawing.Point(71, 13);
            this.friendNickName.Name = "friendNickName";
            this.friendNickName.Size = new System.Drawing.Size(41, 12);
            this.friendNickName.TabIndex = 1;
            this.friendNickName.Text = "叮叮鸟";
            this.friendNickName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.friendNickName_MouseDoubleClick);
            // 
            // LabelDescription
            // 
            this.LabelDescription.AutoSize = true;
            this.LabelDescription.Location = new System.Drawing.Point(74, 38);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(41, 12);
            this.LabelDescription.TabIndex = 2;
            this.LabelDescription.Text = "......";
            this.LabelDescription.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LabelDescription_MouseDoubleClick);
            // 
            // contextMenuStripFriendItem
            // 
            this.contextMenuStripFriendItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除好友ToolStripMenuItem});
            this.contextMenuStripFriendItem.Name = "contextMenuStripFriendItem";
            this.contextMenuStripFriendItem.Size = new System.Drawing.Size(125, 26);
            // 
            // 删除好友ToolStripMenuItem
            // 
            this.删除好友ToolStripMenuItem.Name = "删除好友ToolStripMenuItem";
            this.删除好友ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除好友ToolStripMenuItem.Text = "删除好友";
            this.删除好友ToolStripMenuItem.Click += new System.EventHandler(this.删除好友ToolStripMenuItem_Click);
            // 
            // FriendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ContextMenuStrip = this.contextMenuStripFriendItem;
            this.Controls.Add(this.LabelDescription);
            this.Controls.Add(this.friendNickName);
            this.Controls.Add(this.friendFacePictureBox);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Name = "FriendItem";
            this.Size = new System.Drawing.Size(500, 57);
            this.Load += new System.EventHandler(this.FriendItem_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FriendItem_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.friendFacePictureBox)).EndInit();
            this.contextMenuStripFriendItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox friendFacePictureBox;
        private System.Windows.Forms.Label friendNickName;
        private System.Windows.Forms.Label LabelDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFriendItem;
        private System.Windows.Forms.ToolStripMenuItem 删除好友ToolStripMenuItem;
    }
}
