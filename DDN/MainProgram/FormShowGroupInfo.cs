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
    public partial class FormShowGroupInfo : Form
    {

        #region 属性
        SynchronizationContext m_SyncContext = null;
        GroupInfoModel m_groupModel;
        #endregion

        public FormShowGroupInfo()
        {
            InitializeComponent();
        }

        //群资料时调用
        public FormShowGroupInfo(GroupInfoModel groupModel, Image face)
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            this.labelNickName.Text = groupModel.Name;
            this.labelUsername.Text = groupModel.Gid.ToString();
            this.labelCreatedtime.Text = groupModel.Createdtime; 
            this.pictureBoxFace.Image = face;
            m_groupModel = groupModel;
            //判断是不是群主，群主才可以修改资料
            if (m_groupModel.Master != AppInfo.PERSONAL_INFO.Username)
            {
                this.labelModify.Hide();
                this.labelChangeFace.Hide();
            }
        }

        private void FormModifyPersonalInfo_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width/2 - this.Size.Width/2);
            int y = (SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);         
        }


        //修改    群资料按钮被点击
        FormModifyGroupInfo formModifyGroupInfo = null;
        private void labelModify_Click(object sender, EventArgs e)
        {
            if (formModifyGroupInfo == null || formModifyGroupInfo.IsDisposed)
            {
                formModifyGroupInfo = new FormModifyGroupInfo(m_groupModel,this);
                formModifyGroupInfo.Show();
            }
            else {
                formModifyGroupInfo.Activate();
            }
        }


        //点击修改头像
        FormModifyGroupFace formModifyGroupFace = null;
        private void pictureBoxFace_Click(object sender, EventArgs e)
        {

            if (m_groupModel.Master != AppInfo.PERSONAL_INFO.Username)
            {
                return;
            }

            if (formModifyGroupFace == null || formModifyGroupFace.IsDisposed)
            {
                formModifyGroupFace = new FormModifyGroupFace(this.pictureBoxFace.Image, m_groupModel.Gid.ToString(),this);
                formModifyGroupFace.Show();
            }
            else
            {
                formModifyGroupFace.Activate();
            }
        }
        private void labelChangeFace_Click(object sender, EventArgs e)
        {
            pictureBoxFace_Click(null, null);
        }


        //刷新展示内容
        public void refreshSafePost(GroupInfoModel newGroupModel)
        {
            m_SyncContext.Post(refresh, newGroupModel);
        }
        void refresh(object state)
        {
            GroupInfoModel newGroupModel = (GroupInfoModel)state;
            this.labelNickName.Text = newGroupModel.Name;                 
            this.textBoxDescription.Text = "Todo";          
        }

        //头像被修改后要 刷新头像
       public void refreshFaceSafePost(Image newFace)
        {
            m_SyncContext.Post(refreshFace, newFace);
        }
        void refreshFace(object state)
        {
            this.pictureBoxFace.Image = (Image)state;           
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
            FormDialogManager.Instance.openDialog(1, m_groupModel.Gid, m_groupModel.Name, pictureBoxFace.Image);
        }
    }
}
