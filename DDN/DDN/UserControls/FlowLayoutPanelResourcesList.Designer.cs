namespace DDN.UserControls
{
    partial class FlowLayoutPanelResourcesList
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
            this.buttonCreateGroup = new System.Windows.Forms.Button();
            this.buttonMyRes = new System.Windows.Forms.Button();
            this.buttonGroupRes = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelGroupResItemList = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateGroup
            // 
            this.buttonCreateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateGroup.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCreateGroup.Location = new System.Drawing.Point(234, 1);
            this.buttonCreateGroup.Name = "buttonCreateGroup";
            this.buttonCreateGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateGroup.TabIndex = 1;
            this.buttonCreateGroup.Text = "创建群";
            this.buttonCreateGroup.UseVisualStyleBackColor = false;
            // 
            // buttonMyRes
            // 
            this.buttonMyRes.Location = new System.Drawing.Point(3, 3);
            this.buttonMyRes.Name = "buttonMyRes";
            this.buttonMyRes.Size = new System.Drawing.Size(75, 23);
            this.buttonMyRes.TabIndex = 0;
            this.buttonMyRes.Text = "个人资源";
            this.buttonMyRes.UseVisualStyleBackColor = true;
            this.buttonMyRes.Click += new System.EventHandler(this.buttonMyRes_Click);
            // 
            // buttonGroupRes
            // 
            this.buttonGroupRes.Location = new System.Drawing.Point(3, 32);
            this.buttonGroupRes.Name = "buttonGroupRes";
            this.buttonGroupRes.Size = new System.Drawing.Size(75, 23);
            this.buttonGroupRes.TabIndex = 1;
            this.buttonGroupRes.Text = "群资源";
            this.buttonGroupRes.UseVisualStyleBackColor = true;
            this.buttonGroupRes.Click += new System.EventHandler(this.buttonGroupRes_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Location = new System.Drawing.Point(3, 67);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(189, 23);
            this.buttonAll.TabIndex = 2;
            this.buttonAll.Text = "全部资源（个人资源+群资源）";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.buttonMyRes);
            this.flowLayoutPanel.Controls.Add(this.buttonGroupRes);
            this.flowLayoutPanel.Controls.Add(this.flowLayoutPanelGroupResItemList);
            this.flowLayoutPanel.Controls.Add(this.buttonAll);
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(311, 559);
            this.flowLayoutPanel.TabIndex = 3;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // flowLayoutPanelGroupResItemList
            // 
            this.flowLayoutPanelGroupResItemList.AutoSize = true;
            this.flowLayoutPanelGroupResItemList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelGroupResItemList.Location = new System.Drawing.Point(3, 61);
            this.flowLayoutPanelGroupResItemList.Name = "flowLayoutPanelGroupResItemList";
            this.flowLayoutPanelGroupResItemList.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanelGroupResItemList.TabIndex = 3;
            this.flowLayoutPanelGroupResItemList.WrapContents = false;
            // 
            // FlowLayoutPanelResourcesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.buttonCreateGroup);
            this.Name = "FlowLayoutPanelResourcesList";
            this.Size = new System.Drawing.Size(311, 589);
            this.Load += new System.EventHandler(this.FlowLayoutPanelResourcesList_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCreateGroup;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonMyRes;
        private System.Windows.Forms.Button buttonGroupRes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGroupResItemList;
    }
}
