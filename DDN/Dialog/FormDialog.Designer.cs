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
            this.Takeconter_panel = new System.Windows.Forms.Panel();
            this.TakeScrollBar_panel = new System.Windows.Forms.Panel();
            this.TakeScrollHard_panel = new System.Windows.Forms.Panel();
            this.panelTakeEdit = new System.Windows.Forms.Panel();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labelChat = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.labelDraw = new System.Windows.Forms.Label();
            this.panelChat.SuspendLayout();
            this.Takeconter_panel.SuspendLayout();
            this.TakeScrollBar_panel.SuspendLayout();
            this.panelTakeEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChat
            // 
            this.panelChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelChat.Controls.Add(this.Takeconter_panel);
            this.panelChat.Controls.Add(this.panelTakeEdit);
            this.panelChat.Location = new System.Drawing.Point(0, 35);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(700, 566);
            this.panelChat.TabIndex = 5;
            // 
            // Takeconter_panel
            // 
            this.Takeconter_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Takeconter_panel.BackColor = System.Drawing.Color.White;
            this.Takeconter_panel.Controls.Add(this.TakeScrollBar_panel);
            this.Takeconter_panel.Location = new System.Drawing.Point(0, 0);
            this.Takeconter_panel.Name = "Takeconter_panel";
            this.Takeconter_panel.Size = new System.Drawing.Size(700, 448);
            this.Takeconter_panel.TabIndex = 3;
            // 
            // TakeScrollBar_panel
            // 
            this.TakeScrollBar_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TakeScrollBar_panel.BackgroundImage")));
            this.TakeScrollBar_panel.Controls.Add(this.TakeScrollHard_panel);
            this.TakeScrollBar_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TakeScrollBar_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TakeScrollBar_panel.Location = new System.Drawing.Point(689, 0);
            this.TakeScrollBar_panel.Name = "TakeScrollBar_panel";
            this.TakeScrollBar_panel.Size = new System.Drawing.Size(11, 448);
            this.TakeScrollBar_panel.TabIndex = 4;
            // 
            // TakeScrollHard_panel
            // 
            this.TakeScrollHard_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TakeScrollHard_panel.BackgroundImage")));
            this.TakeScrollHard_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TakeScrollHard_panel.Location = new System.Drawing.Point(0, 3);
            this.TakeScrollHard_panel.Name = "TakeScrollHard_panel";
            this.TakeScrollHard_panel.Size = new System.Drawing.Size(11, 25);
            this.TakeScrollHard_panel.TabIndex = 3;
            // 
            // panelTakeEdit
            // 
            this.panelTakeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTakeEdit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelTakeEdit.Controls.Add(this.panelEdit);
            this.panelTakeEdit.Controls.Add(this.pictureBox1);
            this.panelTakeEdit.Controls.Add(this.button2);
            this.panelTakeEdit.Controls.Add(this.button1);
            this.panelTakeEdit.Location = new System.Drawing.Point(0, 451);
            this.panelTakeEdit.Name = "panelTakeEdit";
            this.panelTakeEdit.Size = new System.Drawing.Size(700, 115);
            this.panelTakeEdit.TabIndex = 0;
            // 
            // panelEdit
            // 
            this.panelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEdit.Location = new System.Drawing.Point(0, 29);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(700, 57);
            this.panelEdit.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(536, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(617, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
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
            this.Takeconter_panel.ResumeLayout(false);
            this.TakeScrollBar_panel.ResumeLayout(false);
            this.panelTakeEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Panel Takeconter_panel;
        private System.Windows.Forms.Panel TakeScrollBar_panel;
        private System.Windows.Forms.Panel TakeScrollHard_panel;
    }
}