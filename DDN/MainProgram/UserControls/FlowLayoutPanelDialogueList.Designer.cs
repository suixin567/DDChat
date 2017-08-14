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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMsgVerifyItem = new System.Windows.Forms.Panel();
            this.pictureBoxMsgVerifyFace = new System.Windows.Forms.PictureBox();
            this.labelMsgVerify = new System.Windows.Forms.Label();
            this.labelMsgVerifyContent = new System.Windows.Forms.Label();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMsgVerifyItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsgVerifyFace)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(50, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "暂时还不支持聊天功能";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "聊天功能正在开发中";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel.Controls.Add(this.panelMsgVerifyItem);
            this.flowLayoutPanel.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel.Controls.Add(this.label1);
            this.flowLayoutPanel.Controls.Add(this.label2);
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(227, 382);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 90);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panelMsgVerifyItem
            // 
            this.panelMsgVerifyItem.BackColor = System.Drawing.Color.White;
            this.panelMsgVerifyItem.Controls.Add(this.labelMsgVerifyContent);
            this.panelMsgVerifyItem.Controls.Add(this.labelMsgVerify);
            this.panelMsgVerifyItem.Controls.Add(this.pictureBoxMsgVerifyFace);
            this.panelMsgVerifyItem.Location = new System.Drawing.Point(3, 3);
            this.panelMsgVerifyItem.Name = "panelMsgVerifyItem";
            this.panelMsgVerifyItem.Size = new System.Drawing.Size(500, 57);
            this.panelMsgVerifyItem.TabIndex = 3;
            this.panelMsgVerifyItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelMsgVerifyItem_MouseDoubleClick);
            // 
            // pictureBoxMsgVerifyFace
            // 
            this.pictureBoxMsgVerifyFace.Location = new System.Drawing.Point(12, 6);
            this.pictureBoxMsgVerifyFace.Name = "pictureBoxMsgVerifyFace";
            this.pictureBoxMsgVerifyFace.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxMsgVerifyFace.TabIndex = 0;
            this.pictureBoxMsgVerifyFace.TabStop = false;
            this.pictureBoxMsgVerifyFace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMsgVerifyFace_MouseDoubleClick);
            // 
            // labelMsgVerify
            // 
            this.labelMsgVerify.AutoSize = true;
            this.labelMsgVerify.Location = new System.Drawing.Point(63, 14);
            this.labelMsgVerify.Name = "labelMsgVerify";
            this.labelMsgVerify.Size = new System.Drawing.Size(53, 12);
            this.labelMsgVerify.TabIndex = 1;
            this.labelMsgVerify.Text = "验证消息";
            this.labelMsgVerify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelMsgVerify_MouseDoubleClick);
            // 
            // labelMsgVerifyContent
            // 
            this.labelMsgVerifyContent.AutoSize = true;
            this.labelMsgVerifyContent.Location = new System.Drawing.Point(64, 38);
            this.labelMsgVerifyContent.Name = "labelMsgVerifyContent";
            this.labelMsgVerifyContent.Size = new System.Drawing.Size(41, 12);
            this.labelMsgVerifyContent.TabIndex = 2;
            this.labelMsgVerifyContent.Text = "......";
            this.labelMsgVerifyContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelMsgVerifyContent_MouseDoubleClick);
            // 
            // FlowLayoutPanelDialogueList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "FlowLayoutPanelDialogueList";
            this.Size = new System.Drawing.Size(227, 382);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMsgVerifyItem.ResumeLayout(false);
            this.panelMsgVerifyItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsgVerifyFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMsgVerifyItem;
        private System.Windows.Forms.PictureBox pictureBoxMsgVerifyFace;
        private System.Windows.Forms.Label labelMsgVerifyContent;
        private System.Windows.Forms.Label labelMsgVerify;
    }
}
