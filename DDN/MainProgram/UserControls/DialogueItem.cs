using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Diagnostics;
using ToolLib;
using Dialog;

namespace MainProgram.UserControls
{
    public partial class DialogueItem : UserControl
    {
        #region 属性
        public SynchronizationContext m_SyncContext = null;
        public string m_friendAndGroupID="";//特殊id
        public string m_friendAndGroupNickName="";
        public string m_friendAndGroupContent="";
        #endregion

        public DialogueItem()
        {
            InitializeComponent();
        }

        
        public DialogueItem(string friendAndGroupID,string content)
        {
            InitializeComponent();
            
            m_SyncContext = SynchronizationContext.Current;
            m_friendAndGroupID = friendAndGroupID;
            m_friendAndGroupContent = content;
            reFreshContentSafePost(null);
            //获取昵称与头像
            if (friendAndGroupID.Contains("friend"))
            {
                //获取这个人的基本信息
                DataMgr.Instance.getPersonalByID(friendAndGroupID.Substring("friend".Length), delegate (PersonalInfoModel model) {
                    m_friendAndGroupNickName = model.Nickname;//获取昵称
                    reFreshContentSafePost(null);
                    //下载头像
                    if (model.Face != "" && model.Face != null)
                    {
                        HttpReqHelper.loadFaceSync(model.Face, delegate (Image face)
                        {
                            if (face != null)
                            {
                                this.PictureBoxDialogueFace.Image = face;
                            }
                        });
                    }
                    else
                    {
                        Debug.Print("err---------错误的头像！！！" + model.Face);
                    }
                });
            }
            else if (friendAndGroupID.Contains("group"))
            {
                //获取这个群的基本信息
                DataMgr.Instance.getGroupByID(friendAndGroupID.Substring("group".Length), delegate (GroupInfoModel model) {
                    m_friendAndGroupNickName = model.Name;//获取昵称
                    reFreshContentSafePost(null);
                    //下载头像
                    if (model.Face != "" && model.Face != null)
                    {
                        HttpReqHelper.loadFaceSync(model.Face, delegate (Image face)
                        {
                            if (face != null)
                            {
                                this.PictureBoxDialogueFace.Image = face;
                            }
                        });
                    }
                    else
                    {
                        Debug.Print("err---------错误的头像！！！" + model.Face);
                    }
                });
            }
            else {
                Debug.Print("错误的对话item类型");
            }            
        }

        private void DialogueItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(PictureBoxDialogueFace.DisplayRectangle, 0, 360);
            PictureBoxDialogueFace.Region = new Region(path);
        }

        //更新内容
        public void reFreshContentSafePost(string content) {
            m_SyncContext.Post(reFreshContent, content);
        }

        void reFreshContent(object state)
        {
            string content = (string)state;
            if (content != null)//外部传来的值
            {
                this.LabelHistory.Text = content;
            }
            else {//使用自己的值
                this.LabelHistory.Text = m_friendAndGroupContent;
            }         
            this.LabelNickName.Text = m_friendAndGroupNickName;
        }


        private void 移除会话ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMgr.Instance.formMain.flowLayoutPanelDialogueList.removeDialogueSafePost(m_friendAndGroupID);
        }

        //鼠标进入头像
        private void PictureBoxDialogueFace_MouseEnter(object sender, EventArgs e)
        {
            if (m_friendAndGroupID.Contains("friend"))
            {
                string friendId = m_friendAndGroupID.Substring("friend".Length);
                FormPersionalInfo.Instance.SetFormPersionalInfo(3, PointToScreen(this.PictureBoxDialogueFace.Location), m_friendAndGroupNickName, friendId, "");               
            }
            else {
                string groupId = m_friendAndGroupID.Substring("group".Length);
                FormPersionalInfo.Instance.SetFormPersionalInfo(3, PointToScreen(this.PictureBoxDialogueFace.Location), m_friendAndGroupNickName, groupId, "");
            }
            FormPersionalInfo.Instance.enterItem(m_friendAndGroupID);
        }

        //鼠标离开头像
        private void PictureBoxDialogueFace_MouseLeave(object sender, EventArgs e)
        {
            FormPersionalInfo.Instance.leaveItem(m_friendAndGroupID);
        }

        //双击打开对话
        private void DialogueItem_DoubleClick(object sender, EventArgs e)
        {
            if (m_friendAndGroupID.Contains("friend"))
            {
                string friendId = m_friendAndGroupID.Substring("friend".Length);
                FormDialogManager.Instance.openDialog(3, int.Parse(friendId), m_friendAndGroupNickName, this.PictureBoxDialogueFace.Image);
            }
            else if(m_friendAndGroupID.Contains("group"))//打开群
            {
                string groupId = m_friendAndGroupID.Substring("group".Length);
                FormDialogManager.Instance.openDialog(1,int.Parse(groupId), m_friendAndGroupNickName, this.PictureBoxDialogueFace.Image);
            }
        }
        //双击打开对话
        private void PictureBoxDialogueFace_DoubleClick(object sender, EventArgs e)
        {
            DialogueItem_DoubleClick(null,null);
        }
        //双击打开对话
        private void LabelNickName_DoubleClick(object sender, EventArgs e)
        {
            DialogueItem_DoubleClick(null, null);
        }
        //双击打开对话
        private void LabelHistory_DoubleClick(object sender, EventArgs e)
        {
            DialogueItem_DoubleClick(null, null);
        }
    }
}
