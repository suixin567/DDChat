namespace MainProgram.UserControls
{
    partial class FlowLayoutPanelFriendList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlowLayoutPanelFriendList));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonFriend = new System.Windows.Forms.Button();
            this.panelSelf = new System.Windows.Forms.Panel();
            this.labelTip = new System.Windows.Forms.Label();
            this.labelSelf = new System.Windows.Forms.Label();
            this.pictureBoxSelfFace = new System.Windows.Forms.PictureBox();
            this.contextMenuStripSelf = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看自己的资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel.SuspendLayout();
            this.panelSelf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelfFace)).BeginInit();
            this.contextMenuStripSelf.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel.Controls.Add(this.buttonFriend);
            this.flowLayoutPanel.Controls.Add(this.panelSelf);
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(246, 502);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // buttonFriend
            // 
            this.buttonFriend.BackColor = System.Drawing.Color.Transparent;
            this.buttonFriend.FlatAppearance.BorderSize = 0;
            this.buttonFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFriend.Image = ((System.Drawing.Image)(resources.GetObject("buttonFriend.Image")));
            this.buttonFriend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFriend.Location = new System.Drawing.Point(3, 3);
            this.buttonFriend.Name = "buttonFriend";
            this.buttonFriend.Size = new System.Drawing.Size(65, 23);
            this.buttonFriend.TabIndex = 1;
            this.buttonFriend.Text = "好友 0";
            this.buttonFriend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFriend.UseVisualStyleBackColor = false;
            this.buttonFriend.Click += new System.EventHandler(this.buttonFriend_Click);
            // 
            // panelSelf
            // 
            this.panelSelf.BackColor = System.Drawing.Color.White;
            this.panelSelf.ContextMenuStrip = this.contextMenuStripSelf;
            this.panelSelf.Controls.Add(this.labelTip);
            this.panelSelf.Controls.Add(this.labelSelf);
            this.panelSelf.Controls.Add(this.pictureBoxSelfFace);
            this.panelSelf.Location = new System.Drawing.Point(0, 29);
            this.panelSelf.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panelSelf.Name = "panelSelf";
            this.panelSelf.Size = new System.Drawing.Size(500, 57);
            this.panelSelf.TabIndex = 2;
            this.panelSelf.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelSelf_MouseDoubleClick);
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(74, 38);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(113, 12);
            this.labelTip.TabIndex = 2;
            this.labelTip.Text = "双击查看自己的资源";
            this.labelTip.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelTip_MouseDoubleClick);
            // 
            // labelSelf
            // 
            this.labelSelf.AutoSize = true;
            this.labelSelf.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelf.ForeColor = System.Drawing.Color.Green;
            this.labelSelf.Location = new System.Drawing.Point(71, 13);
            this.labelSelf.Name = "labelSelf";
            this.labelSelf.Size = new System.Drawing.Size(31, 12);
            this.labelSelf.TabIndex = 1;
            this.labelSelf.Text = "自己";
            this.labelSelf.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelSelf_MouseDoubleClick);
            // 
            // pictureBoxSelfFace
            // 
            this.pictureBoxSelfFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSelfFace.Image")));
            this.pictureBoxSelfFace.Location = new System.Drawing.Point(12, 6);
            this.pictureBoxSelfFace.Name = "pictureBoxSelfFace";
            this.pictureBoxSelfFace.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxSelfFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSelfFace.TabIndex = 0;
            this.pictureBoxSelfFace.TabStop = false;
            this.pictureBoxSelfFace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSelfFace_MouseDoubleClick);
            // 
            // contextMenuStripSelf
            // 
            this.contextMenuStripSelf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看自己的资源ToolStripMenuItem});
            this.contextMenuStripSelf.Name = "contextMenuStripSelf";
            this.contextMenuStripSelf.Size = new System.Drawing.Size(161, 26);
            // 
            // 查看自己的资源ToolStripMenuItem
            // 
            this.查看自己的资源ToolStripMenuItem.Name = "查看自己的资源ToolStripMenuItem";
            this.查看自己的资源ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.查看自己的资源ToolStripMenuItem.Text = "查看自己的资源";
            this.查看自己的资源ToolStripMenuItem.Click += new System.EventHandler(this.查看自己的资源ToolStripMenuItem_Click);
            // 
            // FlowLayoutPanelFriendList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "FlowLayoutPanelFriendList";
            this.Size = new System.Drawing.Size(246, 502);
            this.Load += new System.EventHandler(this.FlowLayoutPanelFriendList_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.panelSelf.ResumeLayout(false);
            this.panelSelf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelfFace)).EndInit();
            this.contextMenuStripSelf.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonFriend;
        private System.Windows.Forms.Panel panelSelf;
        private System.Windows.Forms.PictureBox pictureBoxSelfFace;
        private System.Windows.Forms.Label labelSelf;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSelf;
        private System.Windows.Forms.ToolStripMenuItem 查看自己的资源ToolStripMenuItem;
    }
}
