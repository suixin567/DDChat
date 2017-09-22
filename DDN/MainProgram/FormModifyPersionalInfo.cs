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

namespace MainProgram
{
    public partial class FormModifyPersionalInfo : Form
    {
        public FormModifyPersionalInfo()
        {
            InitializeComponent();
        }

        private void FormModifyPersionalInfo_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }



        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormModifyPersionalInfo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //关闭面板
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
