using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Mgr;
using UnityModule;
using System.Drawing.Drawing2D;
using System.Threading;
using Dialog;

namespace MainProgram.UserControls
{
    public partial class GroupItem : UserControl
    {
        public MyGroupModel m_myGroupModel;
        public GroupInfoModel m_groupInfoModel;
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
            HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?gid=" + m_myGroupModel.GroupID, delegate (string info) {
                Debug.Print("群model是" + info);                
                try
                {
                    m_groupInfoModel = Coding<GroupInfoModel>.decode(info);                                 
                    initLabelSafePost();
                    //下载头像
                    if (m_groupInfoModel.Face != "")
                    {
                        HttpReqHelper.loadFaceSync(m_groupInfoModel.Face, delegate (Image face) {
                            if (face != null)
                            {
                                this.pictureBoxGroupFace.Image = face;
                            }
                        });
                    }
                }
                catch (Exception err)
                {
                    Debug.Print("GroupItem.GroupItm()解析失败" + err.ToString());
                    return;
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
            Debug.Print("群名字是" + m_groupInfoModel.Name);
        }

        private void 退出这个群ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_groupInfoModel.Master == PlayerPrefs.GetString("username"))
            {
                MainMgr.Instance.formMain.flowLayoutPanelGroupList.showOpreationResultSafePost("群主不可以退出群");
                return;
            }
            MsgModel mm = new MsgModel(MessageProtocol.QUIT_GROUP_CREQ, PlayerPrefs.GetString("username"), m_myGroupModel.GroupID.ToString(), "不想继续留在这个群了，再见！", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.GROUP, mm);
        }
        //双击
        private void GroupItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
            //UnityManager.Instance.changeUnityScene(4);
            //UnityManager.Instance.resourceMode = 1;
            FormDialogManager.Instance.openDialog(1, m_groupInfoModel.Gid, m_groupInfoModel.Name,pictureBoxGroupFace.Image);
        }
        //双击
        private void labelName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
            //UnityManager.Instance.changeUnityScene(4);
            //UnityManager.Instance.resourceMode = 1;
            FormDialogManager.Instance.openDialog(1, m_groupInfoModel.Gid, m_groupInfoModel.Name, pictureBoxGroupFace.Image);
        }

        private void pictureBoxGroupFace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
            //UnityManager.Instance.changeUnityScene(4);
            //UnityManager.Instance.resourceMode = 1;
            FormDialogManager.Instance.openDialog(1, m_groupInfoModel.Gid, m_groupInfoModel.Name, pictureBoxGroupFace.Image);
        }
    }
}
