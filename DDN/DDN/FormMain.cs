using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using DDN.Properties;
using System.Resources;
using System.Reflection;
using DDN.Tools;
using DDN.UserControls;

namespace DDN
{
    public partial class FormMain : Form
    {

        private static FormMain instance;
        public static FormMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormMain();
                }
                return instance;
            }
        }

        public SynchronizationContext m_SyncContext = null;


        public FormAddFriend FormAddFriend = null;//添加好友的窗体
        public FormMessageVerify formMessageVerify;//消息管理窗体
        public FlowLayoutPanelDialogueList flowLayoutPanelDialogueList;//会话列表面板
        public FlowLayoutPanelGroupList flowLayoutPanelGroupList;//群列表面板
        public FlowLayoutPanelResourcesList flowLayoutPanelResourcesList;//资源列表面板

        public FormMain()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            //创建会话面板
            flowLayoutPanelDialogueList = new FlowLayoutPanelDialogueList();
            this.Controls.Add(flowLayoutPanelDialogueList);
            flowLayoutPanelDialogueList.Location = new Point(10000, 10000);

            //创建公司面板
            flowLayoutPanelGroupList = new FlowLayoutPanelGroupList();
            this.Controls.Add(flowLayoutPanelGroupList);
            flowLayoutPanelGroupList.Location = new Point(10000, 10000);

            //创建资源面板
            flowLayoutPanelResourcesList = new FlowLayoutPanelResourcesList();
            this.Controls.Add(flowLayoutPanelResourcesList);
            flowLayoutPanelResourcesList.Location = new Point(10000, 10000);
            
        }

        /// <summary>
        /// 初始化窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width * 3);
            int y = (300);
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)     
            SetBtnStyle(this.buttonExit);
            SetBtnStyle(this.buttonMin);
            //icon闪烁计时器停止
            this.timerNotifyIcon.Stop();
            this.notifyIconFormMain.Text = "叮叮鸟："+GameInfo.BaseInfo.Nickname+"（"+ GameInfo.BaseInfo.Username + "）";
            //////////////
            //ResourceManager rm = new ResourceManager("DDN.FormMain", Assembly.GetExecutingAssembly());
            //Image img = (Image)rm.GetObject("pic");
            //pictureBox2.Image = img;
          

            

            //处理离线消息
            if (Manager.Instance.msgMgr.offlineMsgArr != null)
            {
                if (Manager.Instance.msgMgr.offlineMsgArr.Length > 0)
                {
                    foreach (var item in Manager.Instance.msgMgr.offlineMsgArr)
                    {
                        Manager.Instance.msgMgr.onNewMessage(item);
                    }
                }
                Manager.Instance.msgMgr.offlineMsgArr = null;
            }
        }


        //适配
        void Main_Resize(object sender, EventArgs e)
        {
        }


        //icon开始闪烁
        public void notifyIonFlashSafePost()
        {
            m_SyncContext.Post(notifyIonFlash, null);
        }
        //icon开始闪烁
       void notifyIonFlash(object state)
        {
            this.timerNotifyIcon.Start();
            isNotifyIconFlashing = true;
        }


       //icon开始闪烁
        bool isNotifyIconHide = false;
        private void notifyIconTimer_Tick(object sender, EventArgs e)
        {
            if (isNotifyIconHide==false)//变小
            {
                this.notifyIconFormMain.Icon = DDN.Properties.Resources.blank;
                isNotifyIconHide = true;
            }else{//变大
                this.notifyIconFormMain.Icon = DDN.Properties.Resources.bird;
                isNotifyIconHide = false;
            }          
        }


        [DllImport("user32.dll")]
        public static extern bool FlashWindow(
           IntPtr hWnd,     // handle to window
           bool bInvert   // flash status
           );
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);






        //托盘右键退出被点击
        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Debug.Print("托盘右键退出被点击");
            this.notifyIconFormMain.Visible = false;
            this.Close();
            this.Dispose();
            Manager.Instance.ExitApp();
        }

        bool isNotifyIconFlashing = false;
        //托盘图标被点击
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.Print("托盘被左键点击");
            if (e.Button == MouseButtons.Left)
            {
                if (isNotifyIconFlashing == false)
                {
                    this.WindowState = FormWindowState.Normal;
                    int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width * 3);
                    int y = (300);
                    this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
                    this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)     
                }
                else { //消息面板                
                    buttonFormMsgVerify_Click(null,null);
                }
            }
        }

        //打开消息管理器面板
        private void buttonFormMsgVerify_Click(object sender, EventArgs e)
        {
            isNotifyIconFlashing = false;//停止icon闪烁
            this.timerNotifyIcon.Stop();
            this.notifyIconFormMain.Icon = DDN.Properties.Resources.bird;

            //创建消息管理器面板
            if (formMessageVerify == null)
            {
                formMessageVerify = new FormMessageVerify();
                formMessageVerify.Show();
            }
            else
            {
                if (formMessageVerify.IsDisposed)
                {
                    formMessageVerify = new FormMessageVerify();
                    formMessageVerify.Show();
                }
                formMessageVerify.Activate();
                formMessageVerify.reFreshSafePost();
            }
        }

        private void timerShowOrHide_Tick(object sender, EventArgs e)
        {
            AutoSideHideOrShow();
        }

        void AutoSideHideOrShow()
        {
            int sideThickness = 4;//边缘的厚度，窗体停靠在边缘隐藏后留出来的可见部分的厚度  

            //如果窗体最小化或最大化了则什么也不做  
            if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
            {
                return;
            }

            //如果鼠标在窗体内  
            if (Cursor.Position.X >= this.Left && Cursor.Position.X < this.Right && Cursor.Position.Y >= this.Top && Cursor.Position.Y < this.Bottom)
            {
                //如果窗体离屏幕边缘很近，则自动停靠在该边缘  
                if (this.Top <= sideThickness)
                {
                    this.Top = 0;
                }
                if (this.Left <= sideThickness)
                {
                    this.Left = 0;
                }
                if (this.Left >= Screen.PrimaryScreen.WorkingArea.Width - this.Width - sideThickness)
                {
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                }
            }
            //当鼠标离开窗体以后  
            else
            {
                //隐藏到屏幕左边缘  
                if (this.Left == 0)
                {
                    this.Left = sideThickness - this.Width;
                }
                //隐藏到屏幕右边缘  
                else if (this.Left == Screen.PrimaryScreen.WorkingArea.Width - this.Width)
                {
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - sideThickness;
                }
                //隐藏到屏幕上边缘  
                else if (this.Top == 0 && this.Left > 0 && this.Left < Screen.PrimaryScreen.WorkingArea.Width - this.Width)
                {
                    this.Top = sideThickness - this.Height;
                }
            }
        }

       
        //添加好友按钮被点击
        private void addFriendButton_Click(object sender, EventArgs e)
        {
          
            if (FormAddFriend == null)
            {
                FormAddFriend = new FormAddFriend();
                FormAddFriend.Show();
            }
            else {

                if (FormAddFriend.IsDisposed) {
                    FormAddFriend = new FormAddFriend();
                    FormAddFriend.Show();
                }
                FormAddFriend.Activate();
            }
        }



        //好友面板不显示横向滚动条
        private void friendPanelPaint(object sender, PaintEventArgs e)
        {
            //   Control _Control = (Control)sender;
            //    ShowScrollBar(_Control.Handle, 0, 0);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);


        //用户退出程序
        private void FormMainClose(object sender, FormClosedEventArgs e)
        {
            this.notifyIconFormMain.Visible = false;
            Manager.Instance.ExitApp();
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    //取消"关闭窗口"事件
            //    //    e.Cancel = true;
            //    //使关闭时窗口向右下角缩小的效果
            //    //   this.WindowState = FormWindowState.Minimized;
            //    //    this.notifyIcon1.Visible = true;
            //    //    this.Hide();
            //    //    return;
            //    Debug.Print("用户关闭窗体");

            //}
        }


        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                    (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201: //鼠标左键按下的消息
                    m.Msg = 0x00A1; //更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero; //默认值
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>  
        /// 设置透明按钮样式  
        /// </summary>  
        private void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;//样式  
            btn.ForeColor = Color.Transparent;//前景  
            btn.BackColor = Color.Transparent;//去背景  
            btn.FlatAppearance.BorderSize = 0;//去边线  
            btn.FlatAppearance.MouseOverBackColor = Color.Red;//鼠标经过  
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下  
        }
        //最小化
        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //退出
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.notifyIconFormMain.Visible = false;
            this.Dispose();
            Manager.Instance.ExitApp();
        }


        //打开商城
        private void buttonShop_Click(object sender, EventArgs e)
        {
            Manager.Instance.OpenUnity();
        }
    }
}
