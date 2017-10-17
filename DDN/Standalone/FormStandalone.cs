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
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityModule;

namespace Standalone
{
    public partial class FormStandalone : Form
    {
        static string exe = "";
        Process unityProcess;

        public FormStandalone()
        {
            InitializeComponent();
        }

        private void FormStandalone_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width * 3);
            int y = (300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            UnityManager.Instance.netMode = 1;
            ServerForUnity.Instance.Start();
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {              
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

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //关闭程序
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (unityProcess!=null)
            {
                if (!unityProcess.HasExited)
                    unityProcess.Kill();
                unityProcess = null;
            }
            this.notifyIconFormStandalone.Visible = false;
            Environment.Exit(0);
        }

        private void notifyIconFormStandalone_Click(object sender, EventArgs e)
        {
            FormStandalone_Load(null,null);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonExit_Click(null,null);
        }

        //启动Unity
        private void buttonStart_Click(object sender, EventArgs e)
        {
         //   UnityManager.Instance.changeUnityScene(4);
         //   UnityManager.Instance.resourceMode = 0;

            findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");
            if (exe == "")
            {
                MessageBox.Show("3D展示模块不存在！\n请先下载3D模块。", "叮叮鸟提示：");
            }
            else
            {
                try
                {
                    unityProcess = new Process();
                    unityProcess.StartInfo.FileName = exe;
                    //   p.StartInfo.UseShellExecute = false;

                    // p.StartInfo.RedirectStandardInput = true;

                    // p.StartInfo.RedirectStandardOutput = true;

                    //  p.StartInfo.RedirectStandardError = true;

                    //  p.StartInfo.CreateNoWindow = true;

                    //    p.StartInfo.WorkingDirectory = Application.StartupPath + @"\FormGen\";

                    unityProcess.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序加载失败"+ ex.ToString());
                    if (unityProcess != null)
                    {
                        if (!unityProcess.HasExited)
                            unityProcess.Kill();
                        unityProcess = null;
                    }
                }
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


        static void findExe(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹  
                {
                    findExe(fsinfo.FullName);//递归调用  
                }
                else
                {
                    if (fsinfo.FullName.EndsWith(".exe"))
                    {
                        exe = fsinfo.FullName;
                        return;
                    }
                }
            }
        }
    }
}
