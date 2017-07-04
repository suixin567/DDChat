namespace DDN
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
            this.addFriendButton = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonFormMsgVerify = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerNotifyIcon = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanelFriendList = new DDN.UserControls.FlowLayoutPanelFriendList();
            this.topInfoPanel1 = new DDN.TopInfoPanel();
            this.mainTabControl1 = new DDN.UserControls.MainTabControl();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.panelBottom.SuspendLayout();
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
            // addFriendButton
            // 
            this.addFriendButton.Location = new System.Drawing.Point(96, 47);
            this.addFriendButton.Name = "addFriendButton";
            this.addFriendButton.Size = new System.Drawing.Size(85, 23);
            this.addFriendButton.TabIndex = 9;
            this.addFriendButton.Text = "查找";
            this.addFriendButton.UseVisualStyleBackColor = true;
            this.addFriendButton.Click += new System.EventHandler(this.addFriendButton_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelBottom.Controls.Add(this.buttonFormMsgVerify);
            this.panelBottom.Controls.Add(this.button2);
            this.panelBottom.Controls.Add(this.button3);
            this.panelBottom.Controls.Add(this.button1);
            this.panelBottom.Controls.Add(this.addFriendButton);
            this.panelBottom.Location = new System.Drawing.Point(4, 570);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(282, 75);
            this.panelBottom.TabIndex = 10;
            // 
            // buttonFormMsgVerify
            // 
            this.buttonFormMsgVerify.Location = new System.Drawing.Point(5, 47);
            this.buttonFormMsgVerify.Name = "buttonFormMsgVerify";
            this.buttonFormMsgVerify.Size = new System.Drawing.Size(76, 23);
            this.buttonFormMsgVerify.TabIndex = 14;
            this.buttonFormMsgVerify.Text = "消息管理";
            this.buttonFormMsgVerify.UseVisualStyleBackColor = true;
            this.buttonFormMsgVerify.Click += new System.EventHandler(this.buttonFormMsgVerify_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 42);
            this.button2.TabIndex = 13;
            this.button2.Text = "其他服务";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 42);
            this.button3.TabIndex = 12;
            this.button3.Text = "户型绘制";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 10;
            this.button1.Text = "叮叮鸟商城";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(258, 2);
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
            this.buttonMin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMin.Location = new System.Drawing.Point(225, 2);
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
            this.timerNotifyIcon.Interval = 500;
            this.timerNotifyIcon.Tick += new System.EventHandler(this.notifyIconTimer_Tick);
            // 
            // flowLayoutPanelFriendList
            // 
            this.flowLayoutPanelFriendList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFriendList.Location = new System.Drawing.Point(4, 161);
            this.flowLayoutPanelFriendList.Name = "flowLayoutPanelFriendList";
            this.flowLayoutPanelFriendList.Size = new System.Drawing.Size(282, 406);
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
            // mainTabControl1
            // 
            this.mainTabControl1.Location = new System.Drawing.Point(4, 122);
            this.mainTabControl1.Name = "mainTabControl1";
            this.mainTabControl1.Size = new System.Drawing.Size(282, 36);
            this.mainTabControl1.TabIndex = 15;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(290, 650);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanelFriendList);
            this.Controls.Add(this.topInfoPanel1);
            this.Controls.Add(this.mainTabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 1500);
            this.MinimumSize = new System.Drawing.Size(290, 500);
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "叮叮鸟";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainClose);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconFormMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Timer timerShowOrHide;
        private System.Windows.Forms.Button addFriendButton;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerNotifyIcon;
        private System.Windows.Forms.Button buttonFormMsgVerify;
        private UserControls.MainTabControl mainTabControl1;
        private TopInfoPanel topInfoPanel1;
        public UserControls.FlowLayoutPanelFriendList flowLayoutPanelFriendList;
    }
}

