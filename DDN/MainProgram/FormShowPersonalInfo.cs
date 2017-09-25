using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ToolLib;

namespace MainProgram
{
    public partial class FormShowPersonalInfo : Form
    {

        public FormShowPersonalInfo()
        {
            InitializeComponent();
        }

        public FormShowPersonalInfo(Image face)
        {
            InitializeComponent();
            this.labelNickName.Text = AppInfo.PERSONAL_INFO.Nickname;
            this.labelUsername.Text = AppInfo.PERSONAL_INFO.Username;
            this.labelDisc.Text = AppInfo.PERSONAL_INFO.Description;
            this.pictureBoxFace.Image = face;
        }

        private void FormModifyPersonalInfo_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width/2 - this.Size.Width/2);
            int y = (SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }


        //修改资料按钮被点击
        FormModifyPersionalInfo formModifyPersionalInfo = null;
        private void labelModify_Click(object sender, EventArgs e)
        {
            if (formModifyPersionalInfo == null || formModifyPersionalInfo.IsDisposed)
            {
                formModifyPersionalInfo = new FormModifyPersionalInfo(this);
                formModifyPersionalInfo.Show();
            }
            else {
                formModifyPersionalInfo.Activate();
            }
        }


        //点击修改头像
        private void pictureBoxFace_Click(object sender, EventArgs e)
        {
            //TODO:
        }

        //刷新展示内容
        public void refreshInfo() {
            this.labelNickName.Text = AppInfo.PERSONAL_INFO.Nickname;          
            this.labelDisc.Text = AppInfo.PERSONAL_INFO.Description;
        }




        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormModifyPersonalInfo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
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
        //最小化
        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
