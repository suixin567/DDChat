using Dialog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class FormShowPersonalInfo : Form
    {

        #region 属性
        SynchronizationContext m_SyncContext = null;
        int m_windowType = -1; //1群资料卡 2自己的资料卡 3朋友资料卡
        PersonalInfoModel m_PersonalInfoModel;
        #endregion

        public FormShowPersonalInfo()
        {
            InitializeComponent();
            m_windowType = 2;
            m_SyncContext = SynchronizationContext.Current;
            this.labelNickName.Text = AppInfo.PERSONAL_INFO.Nickname;
            this.labelUsername.Text = AppInfo.PERSONAL_INFO.Username;

            //设置签名信息
            this.textBoxDescription.Text = AppInfo.PERSONAL_INFO.Description;
            this.pictureBoxFace.Image = AppInfo.SELF_FACE;

            //注册头像被修改的事件
            AppInfo.onPersonalFaceChanged += this.refreshFaceSafePost;
            //注册资料被修改的事件
            AppInfo.onPersonalInfoModelChanged += this.refreshSafePost;
            this.buttonOpenDialogue.Hide();           
        }

        //朋友资料时调用
        public FormShowPersonalInfo(PersonalInfoModel friendModel,Image face)
        {
            InitializeComponent();
            m_windowType = 3;
            m_SyncContext = SynchronizationContext.Current;
            this.labelNickName.Text = friendModel.Nickname;
            this.labelUsername.Text = friendModel.Username;
            this.textBoxDescription.Text = friendModel.Description;
            this.pictureBoxFace.Image = face;
            m_PersonalInfoModel = friendModel;
            //隐藏修改内容
            this.labelChangeFace.Hide();
            this.labelModify.Hide(); 
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
                formModifyPersionalInfo = new FormModifyPersionalInfo();
                formModifyPersionalInfo.Show();
            }
            else {
                formModifyPersionalInfo.Activate();
            }
        }


        //点击修改头像
        FormModifyFace formModifyFace = null;
        private void pictureBoxFace_Click(object sender, EventArgs e)
        {
            if (m_windowType != 2)
            {
                return;
            }
            if (formModifyFace == null || formModifyFace.IsDisposed)
            {
                formModifyFace = new FormModifyFace();
                formModifyFace.Show();
            }
            else
            {
                formModifyFace.Activate();
            }
        }
        private void labelChangeFace_Click(object sender, EventArgs e)
        {
            pictureBoxFace_Click(null, null);
        }


        //刷新展示内容
        void refreshSafePost()
        {
            m_SyncContext.Post(refresh, null);
        }
        void refresh(object state)
        {
            this.labelNickName.Text = AppInfo.PERSONAL_INFO.Nickname;                 
            this.textBoxDescription.Text = AppInfo.PERSONAL_INFO.Description;          
        }

        //刷新头像
        void refreshFaceSafePost()
        {
            m_SyncContext.Post(refreshFace, null);
        }
        void refreshFace(object state)
        {
            this.pictureBoxFace.Image = AppInfo.SELF_FACE;           
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

        private void buttonOpenDialogue_Click(object sender, EventArgs e)
        {
            FormDialogManager.Instance.openDialog(3, int.Parse(m_PersonalInfoModel.Username), m_PersonalInfoModel.Nickname, pictureBoxFace.Image);
        }
    }
}
