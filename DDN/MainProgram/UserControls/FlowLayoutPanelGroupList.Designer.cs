namespace MainProgram.UserControls
{
    partial class FlowLayoutPanelGroupList
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.创建群ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateGroup = new System.Windows.Forms.Button();
            this.labelTip = new System.Windows.Forms.Label();
            this.timerOpreationResult = new System.Windows.Forms.Timer(this.components);
            this.buttonGroup = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel.ContextMenuStrip = this.contextMenuStrip;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 46);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(310, 455);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建群ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // 创建群ToolStripMenuItem
            // 
            this.创建群ToolStripMenuItem.Name = "创建群ToolStripMenuItem";
            this.创建群ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.创建群ToolStripMenuItem.Text = "创建群";
            this.创建群ToolStripMenuItem.Click += new System.EventHandler(this.创建群ToolStripMenuItem_Click);
            // 
            // buttonCreateGroup
            // 
            this.buttonCreateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateGroup.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCreateGroup.ForeColor = System.Drawing.Color.White;
            this.buttonCreateGroup.Location = new System.Drawing.Point(234, 1);
            this.buttonCreateGroup.Name = "buttonCreateGroup";
            this.buttonCreateGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateGroup.TabIndex = 1;
            this.buttonCreateGroup.Text = "创建群";
            this.buttonCreateGroup.UseVisualStyleBackColor = false;
            this.buttonCreateGroup.Click += new System.EventHandler(this.buttonCreateGroup_Click);
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTip.ForeColor = System.Drawing.Color.Red;
            this.labelTip.Location = new System.Drawing.Point(3, 6);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(67, 14);
            this.labelTip.TabIndex = 2;
            this.labelTip.Text = "提示文字";
            // 
            // timerOpreationResult
            // 
            this.timerOpreationResult.Enabled = true;
            this.timerOpreationResult.Interval = 1000;
            this.timerOpreationResult.Tick += new System.EventHandler(this.timerOpreationResult_Tick);
            // 
            // buttonGroup
            // 
            this.buttonGroup.FlatAppearance.BorderSize = 0;
            this.buttonGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGroup.Image = global::MainProgram.Properties.Resources._3_1;
            this.buttonGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGroup.Location = new System.Drawing.Point(6, 23);
            this.buttonGroup.Name = "buttonGroup";
            this.buttonGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonGroup.TabIndex = 3;
            this.buttonGroup.Text = "我的群 0";
            this.buttonGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGroup.UseVisualStyleBackColor = true;
            this.buttonGroup.Click += new System.EventHandler(this.buttonGroup_Click);
            // 
            // FlowLayoutPanelGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.buttonGroup);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.buttonCreateGroup);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "FlowLayoutPanelGroupList";
            this.Size = new System.Drawing.Size(310, 501);
            this.Load += new System.EventHandler(this.flowLayoutPanelCompanyList_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 创建群ToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreateGroup;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Timer timerOpreationResult;
        private System.Windows.Forms.Button buttonGroup;
    }
}
