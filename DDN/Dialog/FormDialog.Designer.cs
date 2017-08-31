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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTakeEdit = new System.Windows.Forms.Panel();
            this.labelTip = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labelChat = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.labelDraw = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelGroupMember = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupMember12 = new Dialog.GroupMember();
            this.groupMember1 = new Dialog.GroupMember();
            this.groupMember2 = new Dialog.GroupMember();
            this.groupMember3 = new Dialog.GroupMember();
            this.groupMember4 = new Dialog.GroupMember();
            this.groupMember5 = new Dialog.GroupMember();
            this.groupMember6 = new Dialog.GroupMember();
            this.groupMember7 = new Dialog.GroupMember();
            this.groupMember8 = new Dialog.GroupMember();
            this.groupMember9 = new Dialog.GroupMember();
            this.groupMember10 = new Dialog.GroupMember();
            this.groupMember11 = new Dialog.GroupMember();
            this.groupMember13 = new Dialog.GroupMember();
            this.Rich_Edit = new Thedog.PicRichTextBox();
            this.groupMember14 = new Dialog.GroupMember();
            this.panelChat.SuspendLayout();
            this.panelTakeEdit.SuspendLayout();
            this.flowLayoutPanelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanelGroupMember.SuspendLayout();
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
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackColor = System.Drawing.Color.SteelBlue;
            this.panelRight.Controls.Add(this.label1);
            this.panelRight.Controls.Add(this.flowLayoutPanelGroupMember);
            this.panelRight.Controls.Add(this.pictureBox1);
            this.panelRight.Location = new System.Drawing.Point(502, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(200, 566);
            this.panelRight.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanelGroupMember
            // 
            this.flowLayoutPanelGroupMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelGroupMember.AutoScroll = true;
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember12);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember1);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember2);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember3);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember4);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember5);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember6);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember7);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember8);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember9);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember10);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember11);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember13);
            this.flowLayoutPanelGroupMember.Controls.Add(this.groupMember14);
            this.flowLayoutPanelGroupMember.Location = new System.Drawing.Point(0, 241);
            this.flowLayoutPanelGroupMember.Name = "flowLayoutPanelGroupMember";
            this.flowLayoutPanelGroupMember.Size = new System.Drawing.Size(200, 343);
            this.flowLayoutPanelGroupMember.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "群成员 0/0";
            // 
            // groupMember12
            // 
            this.groupMember12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember12.Location = new System.Drawing.Point(0, 0);
            this.groupMember12.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember12.Name = "groupMember12";
            this.groupMember12.Size = new System.Drawing.Size(200, 30);
            this.groupMember12.TabIndex = 24;
            // 
            // groupMember1
            // 
            this.groupMember1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember1.Location = new System.Drawing.Point(0, 31);
            this.groupMember1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember1.Name = "groupMember1";
            this.groupMember1.Size = new System.Drawing.Size(200, 30);
            this.groupMember1.TabIndex = 25;
            // 
            // groupMember2
            // 
            this.groupMember2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember2.Location = new System.Drawing.Point(0, 62);
            this.groupMember2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember2.Name = "groupMember2";
            this.groupMember2.Size = new System.Drawing.Size(200, 30);
            this.groupMember2.TabIndex = 26;
            // 
            // groupMember3
            // 
            this.groupMember3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember3.Location = new System.Drawing.Point(0, 93);
            this.groupMember3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember3.Name = "groupMember3";
            this.groupMember3.Size = new System.Drawing.Size(200, 30);
            this.groupMember3.TabIndex = 27;
            // 
            // groupMember4
            // 
            this.groupMember4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember4.Location = new System.Drawing.Point(0, 124);
            this.groupMember4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember4.Name = "groupMember4";
            this.groupMember4.Size = new System.Drawing.Size(200, 30);
            this.groupMember4.TabIndex = 28;
            // 
            // groupMember5
            // 
            this.groupMember5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember5.Location = new System.Drawing.Point(0, 155);
            this.groupMember5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember5.Name = "groupMember5";
            this.groupMember5.Size = new System.Drawing.Size(200, 30);
            this.groupMember5.TabIndex = 29;
            // 
            // groupMember6
            // 
            this.groupMember6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember6.Location = new System.Drawing.Point(0, 186);
            this.groupMember6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember6.Name = "groupMember6";
            this.groupMember6.Size = new System.Drawing.Size(200, 30);
            this.groupMember6.TabIndex = 30;
            // 
            // groupMember7
            // 
            this.groupMember7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember7.Location = new System.Drawing.Point(0, 217);
            this.groupMember7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember7.Name = "groupMember7";
            this.groupMember7.Size = new System.Drawing.Size(200, 30);
            this.groupMember7.TabIndex = 31;
            // 
            // groupMember8
            // 
            this.groupMember8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember8.Location = new System.Drawing.Point(0, 248);
            this.groupMember8.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember8.Name = "groupMember8";
            this.groupMember8.Size = new System.Drawing.Size(200, 30);
            this.groupMember8.TabIndex = 32;
            // 
            // groupMember9
            // 
            this.groupMember9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember9.Location = new System.Drawing.Point(0, 279);
            this.groupMember9.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember9.Name = "groupMember9";
            this.groupMember9.Size = new System.Drawing.Size(200, 30);
            this.groupMember9.TabIndex = 33;
            // 
            // groupMember10
            // 
            this.groupMember10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember10.Location = new System.Drawing.Point(0, 310);
            this.groupMember10.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember10.Name = "groupMember10";
            this.groupMember10.Size = new System.Drawing.Size(200, 30);
            this.groupMember10.TabIndex = 34;
            // 
            // groupMember11
            // 
            this.groupMember11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember11.Location = new System.Drawing.Point(0, 341);
            this.groupMember11.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember11.Name = "groupMember11";
            this.groupMember11.Size = new System.Drawing.Size(200, 30);
            this.groupMember11.TabIndex = 35;
            // 
            // groupMember13
            // 
            this.groupMember13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember13.Location = new System.Drawing.Point(0, 372);
            this.groupMember13.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember13.Name = "groupMember13";
            this.groupMember13.Size = new System.Drawing.Size(200, 30);
            this.groupMember13.TabIndex = 36;
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
            // groupMember14
            // 
            this.groupMember14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupMember14.Location = new System.Drawing.Point(0, 403);
            this.groupMember14.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.groupMember14.Name = "groupMember14";
            this.groupMember14.Size = new System.Drawing.Size(200, 30);
            this.groupMember14.TabIndex = 37;
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
            this.panelTakeEdit.ResumeLayout(false);
            this.panelTakeEdit.PerformLayout();
            this.flowLayoutPanelTop.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanelGroupMember.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGroupMember;
        private System.Windows.Forms.Label label1;
        private GroupMember groupMember12;
        private GroupMember groupMember1;
        private GroupMember groupMember2;
        private GroupMember groupMember3;
        private GroupMember groupMember4;
        private GroupMember groupMember5;
        private GroupMember groupMember6;
        private GroupMember groupMember7;
        private GroupMember groupMember8;
        private GroupMember groupMember9;
        private GroupMember groupMember10;
        private GroupMember groupMember11;
        private GroupMember groupMember13;
        private GroupMember groupMember14;
    }
}