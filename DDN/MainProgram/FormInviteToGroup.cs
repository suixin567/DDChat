using MainProgram.UserControls;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ToolLib;

namespace MainProgram
{
    public partial class FormInviteToGroup : Form
    {
        int m_belongToGid ;
        SynchronizationContext m_SyncContext = null;//线程上下文

        public FormInviteToGroup(int belongToGid)
        {
            InitializeComponent();
            m_belongToGid = belongToGid;
            m_SyncContext = SynchronizationContext.Current;
        }

        private void FormInviteToGroup_Load(object sender, EventArgs e)
        {
            this.flowLayoutPanelFriends.Controls.Clear();
            this.labelTip.Text = "";
            //拉取好友列表
            foreach (var item in MainMgr.Instance.formMain.flowLayoutPanelFriendList.flowLayoutPanel.Controls)
            {
                if (item is FriendItem)
                {
                    FriendItem friendItem = (FriendItem)item;
                    //创建inviteItem
                    InviteItem inviteItem = new InviteItem(friendItem.m_FriendModel.Username, friendItem.m_FriendModel.Nickname, friendItem.friendFacePictureBox.Image,this,false);
                    this.flowLayoutPanelFriends.Controls.Add(inviteItem);
                }
            }           
        }

        public void onItemSelected(InviteItem clickedItem) {
            foreach (var item in this.flowLayoutPanelSelected.Controls)
            {
                InviteItem inviteItem = (InviteItem)item;
                if (inviteItem.m_friendUsername == clickedItem.m_friendUsername)
                {
                    return;
                }
            }
            //判断是否已经在群中
            DataMgr.Instance.getGroupByID(m_belongToGid,delegate (GroupInfoModel mode) {
                string[] managerArr = mode.Manager.Split(',');
                foreach (var item in managerArr)
                {
                    //是否已经在群中
                    if (item == clickedItem.m_friendUsername)
                    {
                        showLoginOpreationResultSafePost("此好友已经是群成员");
                        return;
                    }
                }
                string[] memberArr = mode.Member.Split(',');
                foreach (var item in memberArr)
                {
                    //是否已经在群中
                    if (item== clickedItem.m_friendUsername)
                    {
                        showLoginOpreationResultSafePost("此好友已经是群成员");
                        return;
                    }
                }
                //移动到选择框中去
                InviteItem newInviteItem = new InviteItem(clickedItem.m_friendUsername, clickedItem.m_nickname, clickedItem.m_face, this, true);
                this.flowLayoutPanelSelected.Controls.Add(newInviteItem);
            });
            
        }

        //有新item添加
        private void flowLayoutPanelSelected_ControlAdded(object sender, ControlEventArgs e)
        {
            this.buttonYes.Enabled = true;
        }
        //有item被移除
        private void flowLayoutPanelSelected_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this.flowLayoutPanelSelected.Controls.Count == 0)
            {
                this.buttonYes.Enabled = false;
            }

        }

        //发送邀请好友的命令
        private void buttonYes_Click(object sender, EventArgs e)
        {

        }





        /// ///////////////////////////////////////////////
        /// 工具方法
        /// ///////////////////////////////////////////////
        /// 
        void showLoginOpreationResultSafePost(string content)
        {
            m_SyncContext.Post(showOpreationResult, content);
        }

        int delay = 0;
        int currentCount = 0;
        void showOpreationResult(object content)
        {
            this.labelTip.Text = content.ToString();
            delay = 3;
            currentCount = 0;
            this.timerOpreationResult.Start();
        }

        private void timerOpreationResult_Tick(object sender, EventArgs e)
        {
            currentCount++;
            if (currentCount >= delay)
            {
                this.timerOpreationResult.Stop();
                this.labelTip.Text = "";
            }
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormInviteToGroup_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
}
