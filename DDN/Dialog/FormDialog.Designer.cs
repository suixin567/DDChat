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
            this.panelRight = new System.Windows.Forms.Panel();
            this.pictureBoxAd = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTakeEdit = new System.Windows.Forms.Panel();
            this.labelTip = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labelChat = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.labelDraw = new System.Windows.Forms.Label();
            this.groupMemberPanel1 = new Dialog.GroupMemberPanel();
            this.Rich_Edit = new Thedog.PicRichTextBox();
            this.panelChat.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAd)).BeginInit();
            this.panelTakeEdit.SuspendLayout();
            this.flowLayoutPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChat
            // 
            this.panelChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelChat.Controls.Add(this.panelRight);
            this.panelChat.Controls.Add(this.flowLayoutPanel1);
            this.panelChat.Controls.Add(this.panelTakeEdit);
            this.panelChat.Location = new System.Drawing.Point(0, 35);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(700, 566);
            this.panelChat.TabIndex = 5;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(500, 430);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panelTakeEdit
            // 
            this.panelTakeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTakeEdit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelTakeEdit.Controls.Add(this.labelTip);
            this.panelTakeEdit.Controls.Add(this.Rich_Edit);
            this.panelTakeEdit.Controls.Add(this.buttonSend);
            this.panelTakeEdit.Location = new System.Drawing.Point(0, 433);
            this.panelTakeEdit.Name = "panelTakeEdit";
            this.panelTakeEdit.Size = new System.Drawing.Size(500, 133);
            this.panelTakeEdit.TabIndex = 0;
            // 
            // labelTip
            // 
            this.labelTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTip.AutoSize = true;
            this.labelTip.ForeColor = System.Drawing.Color.Red;
            this.labelTip.Location = new System.Drawing.Point(298, 111);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(113, 12);
            this.labelTip.TabIndex = 3;
            this.labelTip.Text = "发送的消息太长了！";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(417, 105);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // flowLayoutPanelTop
            // 
            this.flowLayoutPanelTop.Controls.Add(this.labelChat);
            this.flowLayoutPanelTop.Controls.Add(this.labelRes);
            this.flowLayoutPanelTop.Controls.Add(this.labelDraw);
            this.flowLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            this.flowLayoutPanelTop.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(253, 35);
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
            // labelRes
            // 
            this.labelRes.BackColor = System.Drawing.SystemColors.Control;
            this.labelRes.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRes.Location = new System.Drawing.Point(83, 3);
            this.labelRes.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(52, 29);
            this.labelRes.TabIndex = 1;
            this.labelRes.Text = "资源";
            this.labelRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRes.Click += new System.EventHandler(this.labelRes_Click);
            // 
            // labelDraw
            // 
            this.labelDraw.BackColor = System.Drawing.SystemColors.Control;
            this.labelDraw.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDraw.Location = new System.Drawing.Point(158, 3);
            this.labelDraw.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.labelDraw.Name = "labelDraw";
            this.labelDraw.Size = new System.Drawing.Size(75, 29);
            this.labelDraw.TabIndex = 2;
            this.labelDraw.Text = "绘制户型";
            this.labelDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDraw.Click += new System.EventHandler(this.labelDraw_Click);
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
            // Rich_Edit
            // 
            this.Rich_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rich_Edit.Location = new System.Drawing.Point(0, 25);
            this.Rich_Edit.Name = "Rich_Edit";
            this.Rich_Edit.Size = new System.Drawing.Size(500, 78);
            this.Rich_Edit.TabIndex = 0;
            this.Rich_Edit.Text = "";
            this.Rich_Edit.TextChanged += new System.EventHandler(this.Rich_Edit_TextChanged);
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
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAd)).EndInit();
            this.panelTakeEdit.ResumeLayout(false);
            this.panelTakeEdit.PerformLayout();
            this.flowLayoutPanelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.Label labelDraw;
        private System.Windows.Forms.Panel panelTakeEdit;
        private System.Windows.Forms.Button buttonSend;
        public Thedog.PicRichTextBox Rich_Edit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox pictureBoxAd;
        public GroupMemberPanel groupMemberPanel1;
    }
}