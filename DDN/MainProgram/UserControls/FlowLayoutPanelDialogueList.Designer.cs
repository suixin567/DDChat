namespace MainProgram.UserControls
{
    partial class FlowLayoutPanelDialogueList
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空会话列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyMsgMgr1 = new MainProgram.UserControls.VerifyMsgItem();
            this.flowLayoutPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.flowLayoutPanel.Controls.Add(this.verifyMsgMgr1);
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(227, 382);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空会话列表ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // 清空会话列表ToolStripMenuItem
            // 
            this.清空会话列表ToolStripMenuItem.Name = "清空会话列表ToolStripMenuItem";
            this.清空会话列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清空会话列表ToolStripMenuItem.Text = "清空会话列表";
            this.清空会话列表ToolStripMenuItem.Click += new System.EventHandler(this.清空会话列表ToolStripMenuItem_Click);
            // 
            // verifyMsgMgr1
            // 
            this.verifyMsgMgr1.BackColor = System.Drawing.SystemColors.Window;
            this.verifyMsgMgr1.Location = new System.Drawing.Point(0, 0);
            this.verifyMsgMgr1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.verifyMsgMgr1.Name = "verifyMsgMgr1";
            this.verifyMsgMgr1.Size = new System.Drawing.Size(500, 57);
            this.verifyMsgMgr1.TabIndex = 3;
            // 
            // FlowLayoutPanelDialogueList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "FlowLayoutPanelDialogueList";
            this.Size = new System.Drawing.Size(227, 382);
            this.Load += new System.EventHandler(this.FlowLayoutPanelDialogueList_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private VerifyMsgItem verifyMsgMgr1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空会话列表ToolStripMenuItem;
    }
}
