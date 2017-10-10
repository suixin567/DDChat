using System;
using System.Windows.Forms;
using ToolLib;
using System.Threading;
using System.Diagnostics;
using System.Drawing;

namespace MainProgram.UserControls
{
    public partial class GroupManageMemberItem : UserControl
    {
        #region 属性
        SynchronizationContext m_SyncContext = null;
        private string m_memberUsername;
        private PersonalInfoModel m_mode;
        private Image m_face;

        delegate void SetTextCallback(string text);
        delegate void SetImgCallback(Image img);
        #endregion


        public GroupManageMemberItem()
        {
            InitializeComponent();
        }

        public GroupManageMemberItem(string username,int memberLevel)//0群主 1管理 2成员
        {
          
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            m_memberUsername = username;
            switch (memberLevel)
            {
                case 0:
                    this.labelMemberLevel.Text = "群主";
                    this.buttonRemove.Hide();
                    break;
                case 1:
                    this.labelMemberLevel.Text = "管理员";
                    break;
                case 2:
                    this.labelMemberLevel.Text = "";
                    break;
                default:
                    break;
            }        
        }

        private void GroupManageMemberItem_Load(object sender, EventArgs e)
        {
            if (m_memberUsername == null)
            {
                return;
            }
            //获取昵称与头像
            DataMgr.Instance.getPersonalByID(m_memberUsername, delegate (PersonalInfoModel mode)
            {
                m_mode = mode;
                if (mode.Nickname != null)
                {
                    SetText(mode.Nickname);
                }
                //下载头像
                if (mode.Face != "")
                {
                    FaceMgr.Instance.getFaceByName(mode.Face, delegate (Image face) {
                        if (face != null)
                        {
                            m_face = face;
                            SetImg(face);
                        }
                    });
                }
            });         
        }


        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.labelNickName.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.labelNickName.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.labelNickName.Disposing || this.labelNickName.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(SetText);
                this.labelNickName.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelNickName.Text = text;
            }
        }


        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetImg(Image img)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.pictureBoxFace.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.pictureBoxFace.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.pictureBoxFace.Disposing || this.pictureBoxFace.IsDisposed)
                        return;
                }
                SetImgCallback d = new SetImgCallback(SetImg);
                this.pictureBoxFace.Invoke(d, new object[] { img });
            }
            else
            {
                this.pictureBoxFace.Image = img;
            }
        }

        //查看资料，应该打开资料面板。
        FormShowPersonalInfo formShowPersonalInfo;
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (formShowPersonalInfo == null || formShowPersonalInfo.IsDisposed)
            {
                formShowPersonalInfo = new FormShowPersonalInfo(m_mode, m_face);
                formShowPersonalInfo.Show();
            }
            else {
                formShowPersonalInfo.Activate();
            }
        }

        //移除成员按钮被点击
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            MsgModel mm = new MsgModel(MessageProtocol.FORCE_REMOVE_GROUP_CREQ, ((FormShowGroupInfo)FindForm()).m_groupItem.getGroupMode().Gid.ToString(), m_memberUsername,
                "您已被移出群" + ((FormShowGroupInfo)FindForm()).m_groupItem.getGroupMode().Name + "。", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.GROUP, mm);
        }
    }
}
