using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
using Dialog;
using ToolLib;

namespace MainProgram.UserControls
{
    public partial class GroupItem : UserControl
    {
        public MyGroupModel m_myGroupModel;
        private GroupInfoModel m_groupInfoModel;                 
        
        public SynchronizationContext m_SyncContext = null;

        public GroupItem()
        {
            InitializeComponent();         
        }

        public GroupItem(MyGroupModel myGroupModel)
        {
            if (myGroupModel.GroupID == 0)
            {
                Debug.Print("groupID=0这不该发生" + m_myGroupModel.GroupID);
                Dispose();
                return;
            }

            InitializeComponent();
            m_myGroupModel = myGroupModel;
            DataMgr.Instance.updateGroupInfoEvent += this.onGroupModelMotified;
            FaceMgr.Instance.modifyFaceEvent += this.onGroupFaceModify;
        }

     



        private void GroupItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBoxGroupFace.DisplayRectangle, 0, 360);
            pictureBoxGroupFace.Region = new Region(path);
            m_SyncContext = SynchronizationContext.Current;
            if (m_myGroupModel ==null) {
                return;
            }

            //获取这个群的基本信息
            DataMgr.Instance.getGroupByID(m_myGroupModel.GroupID,delegate(GroupInfoModel model) {
                m_groupInfoModel = model;
            //     Debug.Print("qqqqqqqqqqq群得到消息" + m_groupInfoModel.Name);
                initLabelSafePost();
                //下载头像

                if (m_groupInfoModel.Face != "" && m_groupInfoModel.Face != null)
                {
                    FaceMgr.Instance.getFaceByName(m_groupInfoModel.Face, delegate (Image face)
                    {
                        if (face != null)
                        {
                            this.pictureBoxGroupFace.Image = face;
                        }
                    });
                }
                else {
                    Debug.Print("err---------错误的头像！！！"+ m_groupInfoModel.Face);
                }
            });       
        }

        void initLabelSafePost()
        {
            m_SyncContext.Post(initLabel, null);
        }
        void initLabel(object state)
        {
            labelName.Text = m_groupInfoModel.Name;
    
        }

        private void 退出这个群ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_groupInfoModel.Master == AppInfo.USER_NAME)
            {
                MainMgr.Instance.formMain.flowLayoutPanelGroupList.showOpreationResultSafePost("群主不可以退出群");
                return;
            }
            MsgModel mm = new MsgModel(MessageProtocol.QUIT_GROUP_CREQ, AppInfo.USER_NAME, m_groupInfoModel.Gid.ToString(), "不想继续留在这个群了，再见！", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.GROUP, mm);
        }
        //双击
        private void GroupItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //刷新一下数据，有可能已经过时了
            DataMgr.Instance.getGroupByID(m_myGroupModel.GroupID, delegate (GroupInfoModel model) {
                m_groupInfoModel = model;
            });
            FormDialogManager.Instance.openDialog(1, m_groupInfoModel.Gid, m_groupInfoModel.Name,pictureBoxGroupFace.Image);
        }
        //双击
        private void labelName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GroupItem_MouseDoubleClick(null,null);
        }
        //双击
        private void pictureBoxGroupFace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GroupItem_MouseDoubleClick(null, null);
        }

        private void pictureBoxGroupFace_MouseEnter(object sender, EventArgs e)
        {
            FormInfoCard.Instance.SetGroupCard(PointToScreen(this.pictureBoxGroupFace.Location), m_groupInfoModel, this.pictureBoxGroupFace.Image);
            FormInfoCard.Instance.enterItem(m_groupInfoModel.Gid.ToString());
        }

        private void pictureBoxGroupFace_MouseLeave(object sender, EventArgs e)
        {
            FormInfoCard.Instance.leaveItem(m_groupInfoModel.Gid.ToString());
        }

        private void 发送群消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupItem_MouseDoubleClick(null,null);
        }

        //查看群资料
        FormShowGroupInfo formShowGroupInfo = null;
        private void 查看群资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formShowGroupInfo == null || formShowGroupInfo.IsDisposed)
            {
                formShowGroupInfo = new FormShowGroupInfo(m_groupInfoModel, this.pictureBoxGroupFace.Image, this);
                formShowGroupInfo.Show();
            }
            else {
                formShowGroupInfo.Activate();
            }
        }

        public GroupInfoModel getGroupMode() {
            return m_groupInfoModel;
        }

        //当群模型发生改变（有更新）
        void onGroupModelMotified(int gid,GroupInfoModel newMode) {
            if (m_groupInfoModel.Gid ==gid)
            {
                m_groupInfoModel = newMode;              
                //刷新群名字label
                initLabelSafePost();
            }                    
        }

        void onGroupFaceModify(string faceName,Image newFace) {
            if (m_groupInfoModel.Face == "default.jpg")
            {
                m_groupInfoModel.Face = "group" + m_groupInfoModel.Gid + ".jpg";
            }
           
            if (m_groupInfoModel.Face == faceName)
            {
                this.pictureBoxGroupFace.Image = newFace;
            }
        }
    }
}
