using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityModule
{
    public partial class FormUnity : Form
    {
        public SynchronizationContext m_SyncContext = null;
        static string exe = "";

        public FormUnity()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void FormUnity_Load(object sender, EventArgs e)
        {
            this.Size = new Size(System.Windows.Forms.SystemInformation.WorkingArea.Width / 3, System.Windows.Forms.SystemInformation.WorkingArea.Height / 2);
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width/2 - this.Size.Width/2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);

            findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");
            Debug.Print("准备打开Unity客户端：" + exe);
            if (exe == "")
            {
                MessageBox.Show("3D展示模块不存在！\n请先下载3D模块。", "叮叮鸟提示：");
                this.Dispose();
            }
            else {
                appContainer.AppFilename = exe;
                appContainer.Start();
            } 
        }


        
        static void findExe(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                //  Debug.Print("遍历顺序" + fsinfo.FullName);
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹  
                {
                    findExe(fsinfo.FullName);//递归调用  
                }
                else
                {
                    //    Debug.Print("遍历中" + fsinfo.FullName);
                    if (fsinfo.FullName.EndsWith(".exe"))
                    {
                        //         Debug.Print("找到exe了" + fsinfo.FullName);
                        exe = fsinfo.FullName;
                        return;
                    }
                }
            }
        }

        public void setTextSafePost(string text)
        {
            m_SyncContext.Post(setText, text);
        }
        void setText(object state)
        {
            this.Text = (string)state;
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

        private void FormUnity_Paint(object sender, PaintEventArgs e)
        {
            this.panel1. Refresh();
         //   this.Size = new Size(this.Width, this.Width*2/3);
        }

        private void FormUnity_Resize(object sender, EventArgs e)
        {
         //   this.Size = new Size(this.Width, this.Width * 2 / 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this .Dispose();
        }

        //public void closeSafePost(string text)
        //{
        //    m_SyncContext.Post(setText, text);
        //}
        //void setText(object state)
        //{
        //    this.Text = (string)state;
        //}

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
    }
}
