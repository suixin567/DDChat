namespace Dialog
{
    partial class FormDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialog));
            this.panelChat = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.panelTakeEdit = new System.Windows.Forms.Panel();
            this.labelTip = new System.Windows.Forms.Label();
            this.Rich_Edit = new Thedog.PicRichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupMemberPanel1 = new Dialog.GroupMemberPanel();
            this.pictureBoxAd = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labelChat = new System.Windows.Forms.Label();
            this.panelChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelTakeEdit.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAd)).BeginInit();
            this.flowLayoutPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChat
            // 
            this.panelChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(204)))), ((int)(((byte)(213)))));
            this.panelChat.Controls.Add(this.splitContainer1);
            this.panelChat.Controls.Add(this.panelRight);
            this.panelChat.Location = new System.Drawing.Point(0, 35);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(700, 566);
            this.panelChat.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxChat);
            this.splitContainer1.Panel1MinSize = 140;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelTakeEdit);
            this.splitContainer1.Panel2MinSize = 140;
            this.splitContainer1.Size = new System.Drawing.Size(501, 566);
            this.splitContainer1.SplitterDistance = 416;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 4;
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(204)))), ((int)(((byte)(213)))));
            this.richTextBoxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxChat.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxChat.Location = new System.Drawing.Point(19, 0);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxChat.Size = new System.Drawing.Size(482, 413);
            this.richTextBoxChat.TabIndex = 3;
            this.richTextBoxChat.Text = "";
            // 
            // panelTakeEdit
            // 
            this.panelTakeEdit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelTakeEdit.Controls.Add(this.labelTip);
            this.panelTakeEdit.Controls.Add(this.Rich_Edit);
            this.panelTakeEdit.Controls.Add(this.buttonSend);
            this.panelTakeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTakeEdit.Location = new System.Drawing.Point(0, 0);
            this.panelTakeEdit.Name = "panelTakeEdit";
            this.panelTakeEdit.Size = new System.Drawing.Size(501, 149);
            this.panelTakeEdit.TabIndex = 0;
            // 
            // labelTip
            // 
            this.labelTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTip.AutoSize = true;
            this.labelTip.ForeColor = System.Drawing.Color.Red;
            this.labelTip.Location = new System.Drawing.Point(299, 127);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(113, 12);
            this.labelTip.TabIndex = 3;
            this.labelTip.Text = "发送的消息太长了！";
            // 
            // Rich_Edit
            // 
            this.Rich_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rich_Edit.Location = new System.Drawing.Point(0, 25);
            this.Rich_Edit.Name = "Rich_Edit";
            this.Rich_Edit.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rich_Edit.Size = new System.Drawing.Size(501, 94);
            this.Rich_Edit.TabIndex = 0;
            this.Rich_Edit.Text = "";
            this.Rich_Edit.TextChanged += new System.EventHandler(this.Rich_Edit_TextChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(418, 121);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackColor = System.Drawing.Color.SteelBlue;
            this.panelRight.Controls.Add(this.groupMemberPanel1);
            this.panelRight.Controls.Add(this.pictureBoxAd);
            this.panelRight.Location = new System.Drawing.Point(502, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(200, 566);
            this.panelRight.TabIndex = 2;
            // 
            // groupMemberPanel1
            // 
            this.groupMemberPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMemberPanel1.Location = new System.Drawing.Point(0, 218);
            this.groupMemberPanel1.Name = "groupMemberPanel1";
            this.groupMemberPanel1.Size = new System.Drawing.Size(200, 348);
            this.groupMemberPanel1.TabIndex = 1;
            // 
            // pictureBoxAd
            // 
            this.pictureBoxAd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAd.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAd.Image")));
            this.pictureBoxAd.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAd.Name = "pictureBoxAd";
            this.pictureBoxAd.Size = new System.Drawing.Size(200, 216);
            this.pictureBoxAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAd.TabIndex = 0;
            this.pictureBoxAd.TabStop = false;
            // 
            // flowLayoutPanelTop
            // 
            this.flowLayoutPanelTop.Controls.Add(this.labelChat);
            this.flowLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            this.flowLayoutPanelTop.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(105, 35);
            this.flowLayoutPanelTop.TabIndex = 0;
            // 
            // labelChat
            // 
            this.labelChat.BackColor = System.Drawing.SystemColors.Control;
            this.labelChat.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelChat.Location = new System.Drawing.Point(8, 3);
            this.labelChat.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(52, 29);
            this.labelChat.TabIndex = 0;
            this.labelChat.Text = "聊天";
            this.labelChat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelChat.Click += new System.EventHandler(this.labelChat_Click);
            // 
            // FormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.flowLayoutPanelTop);
            this.Controls.Add(this.panelChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDialog";
            this.ShowInTaskbar = false;
            this.Text = "FormDialog";
            this.Load += new System.EventHandler(this.FormDialog_Load);
            this.VisibleChanged += new System.EventHandler(this.FormDialog_VisibleChanged);
            this.panelChat.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelTakeEdit.ResumeLayout(false);
            this.panelTakeEdit.PerformLayout();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAd)).EndInit();
            this.flowLayoutPanelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Panel panelTakeEdit;
        private System.Windows.Forms.Button buttonSend;
        public Thedog.PicRichTextBox Rich_Edit;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox pictureBoxAd;
        public GroupMemberPanel groupMemberPanel1;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}