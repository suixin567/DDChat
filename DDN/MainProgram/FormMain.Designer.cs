namespace MainProgram
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIconFormMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerShowOrHide = new System.Windows.Forms.Timer(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonShop = new System.Windows.Forms.Button();
            this.buttonMsg = new System.Windows.Forms.PictureBox();
            this.buttonFindFriend = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerNotifyIcon = new System.Windows.Forms.Timer(this.components);
            this.mainTabControl1 = new MainProgram.UserControls.MainTabControl();
            this.flowLayoutPanelFriendList = new MainProgram.UserControls.FlowLayoutPanelFriendList();
            this.topInfoPanel1 = new MainProgram.UserControls.TopInfoPanel();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFindFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIconFormMain
            // 
            this.notifyIconFormMain.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIconFormMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconFormMain.Icon")));
            this.notifyIconFormMain.Visible = true;
            this.notifyIconFormMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStrip1";
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(137, 26);
            this.contextMenuStripNotifyIcon.Text = "叮叮鸟系统";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出叮叮鸟";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // timerShowOrHide
            // 
            this.timerShowOrHide.Enabled = true;
            this.timerShowOrHide.Tick += new System.EventHandler(this.timerShowOrHide_Tick);
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.buttonShop);
            this.panelBottom.Controls.Add(this.buttonMsg);
            this.panelBottom.Controls.Add(this.buttonFindFriend);
            this.panelBottom.Location = new System.Drawing.Point(4, 613);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(272, 33);
            this.panelBottom.TabIndex = 10;
            // 
            // buttonShop
            // 
            this.buttonShop.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonShop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShop.FlatAppearance.BorderSize = 0;
            this.buttonShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShop.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonShop.ForeColor = System.Drawing.Color.White;
            this.buttonShop.Image = ((System.Drawing.Image)(resources.GetObject("buttonShop.Image")));
            this.buttonShop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonShop.Location = new System.Drawing.Point(3, 6);
            this.buttonShop.Name = "buttonShop";
            this.buttonShop.Size = new System.Drawing.Size(67, 30);
            this.buttonShop.TabIndex = 17;
            this.buttonShop.Text = "商城";
            this.buttonShop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonShop.UseVisualStyleBackColor = false;
            this.buttonShop.Click += new System.EventHandler(this.buttonShop_Click);
            this.buttonShop.MouseLeave += new System.EventHandler(this.buttonShop_MouseLeave);
            this.buttonShop.MouseHover += new System.EventHandler(this.buttonShop_MouseHover);
            // 
            // buttonMsg
            // 
            this.buttonMsg.Image = ((System.Drawing.Image)(resources.GetObject("buttonMsg.Image")));
            this.buttonMsg.Location = new System.Drawing.Point(215, 16);
            this.buttonMsg.Name = "buttonMsg";
            this.buttonMsg.Size = new System.Drawing.Size(15, 15);
            this.buttonMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonMsg.TabIndex = 16;
            this.buttonMsg.TabStop = false;
            this.buttonMsg.Click += new System.EventHandler(this.buttonFormMsgVerify_Click);
            this.buttonMsg.MouseLeave += new System.EventHandler(this.buttonMsg_MouseLeave);
            this.buttonMsg.MouseHover += new System.EventHandler(this.buttonMsg_MouseHover);
            // 
            // buttonFindFriend
            // 
            this.buttonFindFriend.Image = ((System.Drawing.Image)(resources.GetObject("buttonFindFriend.Image")));
            this.buttonFindFriend.Location = new System.Drawing.Point(247, 16);
            this.buttonFindFriend.Name = "buttonFindFriend";
            this.buttonFindFriend.Size = new System.Drawing.Size(15, 15);
            this.buttonFindFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonFindFriend.TabIndex = 15;
            this.buttonFindFriend.TabStop = false;
            this.buttonFindFriend.Click += new System.EventHandler(this.addFriendButton_Click);
            this.buttonFindFriend.MouseLeave += new System.EventHandler(this.buttonFindFriend_MouseLeave);
            this.buttonFindFriend.MouseHover += new System.EventHandler(this.buttonFindFriend_MouseHover);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(250, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(30, 30);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.Text = "×";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMin.FlatAppearance.BorderSize = 0;
            this.buttonMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMin.ForeColor = System.Drawing.Color.White;
            this.buttonMin.Location = new System.Drawing.Point(221, 0);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(30, 30);
            this.buttonMin.TabIndex = 13;
            this.buttonMin.Text = "一";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // timerNotifyIcon
            // 
            this.timerNotifyIcon.Enabled = true;
            this.timerNotifyIcon.Interval = 300;
            this.timerNotifyIcon.Tick += new System.EventHandler(this.notifyIconTimer_Tick);
            // 
            // mainTabControl1
            // 
            this.mainTabControl1.BackColor = System.Drawing.Color.Transparent;
            this.mainTabControl1.Location = new System.Drawing.Point(4, 123);
            this.mainTabControl1.Name = "mainTabControl1";
            this.mainTabControl1.Size = new System.Drawing.Size(272, 31);
            this.mainTabControl1.TabIndex = 18;
            // 
            // flowLayoutPanelFriendList
            // 
            this.flowLayoutPanelFriendList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFriendList.Location = new System.Drawing.Point(4, 155);
            this.flowLayoutPanelFriendList.Name = "flowLayoutPanelFriendList";
            this.flowLayoutPanelFriendList.Size = new System.Drawing.Size(272, 475);
            this.flowLayoutPanelFriendList.TabIndex = 17;
            // 
            // topInfoPanel1
            // 
            this.topInfoPanel1.BackColor = System.Drawing.Color.Transparent;
            this.topInfoPanel1.Location = new System.Drawing.Point(10, 38);
            this.topInfoPanel1.Name = "topInfoPanel1";
            this.topInfoPanel1.Size = new System.Drawing.Size(230, 80);
            this.topInfoPanel1.TabIndex = 16;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(280, 650);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.mainTabControl1);
            this.Controls.Add(this.flowLayoutPanelFriendList);
            this.Controls.Add(this.topInfoPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.buttonExit);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 1500);
            this.MinimumSize = new System.Drawing.Size(280, 500);
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "叮叮鸟";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFindFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NotifyIcon notifyIconFormMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Timer timerShowOrHide;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerNotifyIcon;
        private UserControls.TopInfoPanel topInfoPanel1;
        public UserControls.FlowLayoutPanelFriendList flowLayoutPanelFriendList;
        private System.Windows.Forms.Button buttonShop;
        private System.Windows.Forms.PictureBox buttonMsg;
        private System.Windows.Forms.PictureBox buttonFindFriend;
        private UserControls.MainTabControl mainTabControl1;
    }
}

