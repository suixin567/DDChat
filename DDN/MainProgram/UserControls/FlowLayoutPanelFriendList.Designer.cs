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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlowLayoutPanelFriendList));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonFriend = new System.Windows.Forms.Button();
            this.flowLayoutPanel.SuspendLayout();
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
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
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
            // FlowLayoutPanelFriendList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "FlowLayoutPanelFriendList";
            this.Size = new System.Drawing.Size(246, 502);
            this.Load += new System.EventHandler(this.FlowLayoutPanelFriendList_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonFriend;
    }
}
