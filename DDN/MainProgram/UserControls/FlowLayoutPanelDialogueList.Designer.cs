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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.verifyMsgMgr1 = new MainProgram.UserControls.VerifyMsgItem();
            this.dialogueItem1 = new MainProgram.UserControls.DialogueItem();
            this.dialogueItem2 = new MainProgram.UserControls.DialogueItem();
            this.dialogueItem3 = new MainProgram.UserControls.DialogueItem();
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
            this.flowLayoutPanel.Controls.Add(this.verifyMsgMgr1);
            this.flowLayoutPanel.Controls.Add(this.dialogueItem1);
            this.flowLayoutPanel.Controls.Add(this.dialogueItem2);
            this.flowLayoutPanel.Controls.Add(this.dialogueItem3);
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(227, 382);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
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
            // dialogueItem1
            // 
            this.dialogueItem1.BackColor = System.Drawing.SystemColors.Window;
            this.dialogueItem1.Location = new System.Drawing.Point(0, 59);
            this.dialogueItem1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.dialogueItem1.Name = "dialogueItem1";
            this.dialogueItem1.Size = new System.Drawing.Size(500, 57);
            this.dialogueItem1.TabIndex = 4;
            // 
            // dialogueItem2
            // 
            this.dialogueItem2.BackColor = System.Drawing.SystemColors.Window;
            this.dialogueItem2.Location = new System.Drawing.Point(0, 118);
            this.dialogueItem2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.dialogueItem2.Name = "dialogueItem2";
            this.dialogueItem2.Size = new System.Drawing.Size(500, 57);
            this.dialogueItem2.TabIndex = 5;
            // 
            // dialogueItem3
            // 
            this.dialogueItem3.BackColor = System.Drawing.SystemColors.Window;
            this.dialogueItem3.Location = new System.Drawing.Point(0, 177);
            this.dialogueItem3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.dialogueItem3.Name = "dialogueItem3";
            this.dialogueItem3.Size = new System.Drawing.Size(500, 57);
            this.dialogueItem3.TabIndex = 6;
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private VerifyMsgItem verifyMsgMgr1;
        private DialogueItem dialogueItem1;
        private DialogueItem dialogueItem2;
        private DialogueItem dialogueItem3;
    }
}
