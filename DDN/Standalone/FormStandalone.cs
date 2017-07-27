using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standalone
{
    public partial class FormStandalone : Form
    {
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.notifyIconFormStandalone.Visible = false;
           // UnityManager.Instance.CloseUnity();
            Environment.Exit(0);
        }

        private void notifyIconFormStandalone_Click(object sender, EventArgs e)
        {
            FormStandalone_Load(null,null);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIconFormStandalone.Visible = false;
            Environment.Exit(0);
        }
    }
}
