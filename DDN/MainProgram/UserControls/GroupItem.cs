using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Mgr;
using UnityControl;
using System.Drawing.Drawing2D;

namespace MainProgram.UserControls
{
    public partial class GroupItem : UserControl
    {
        public MyGroupModel m_myGroupModel;

        public GroupInfoModel m_groupInfoModel;

        public GroupItem()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBoxGroupFace.DisplayRectangle, 0, 360);
            pictureBoxGroupFace.Region = new Region(path);
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
            //获取这个群的基本信息
            HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?gid=" + m_myGroupModel.GroupID,delegate(string info) {
                GroupInfoModel model = new GroupInfoModel();
                try
                {
                    model = Coding<GroupInfoModel>.decode(info);
                }
                catch (Exception err)
                {
                    Debug.Print("GroupItem.GroupItm()解析失败" + err.ToString());
                    return;
                }
                m_groupInfoModel = model;

                labelName.Text = model.Name;

                //下载头像
                if (model.Face != "")
                {
                    HttpReqHelper.loadFaceSync(model.Face,delegate(Image face) {
                        if (face != null)
                        {
                            this.pictureBoxGroupFace.Image = face;
                        }
                    });
                  
                }
            });
            
        }


        private void GroupItem_Load(object sender, EventArgs e)
        {
            if (m_myGroupModel ==null) {
                return;
            }
           
        }


        private void 退出这个群ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_groupInfoModel.Master == PlayerPrefs.GetString("username"))
            {
                MainMgr.Instance.formMain.flowLayoutPanelGroupList.showOpreationResultSafePost("群主不可以退出群");
                return;
            }
            MsgModel mm = new MsgModel(MsgProtocol.QUIT_GROUP_CREQ, PlayerPrefs.GetString("username"), m_myGroupModel.GroupID.ToString(), "不想继续留在这个群了，再见！", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MsgProtocol.GROUP, mm);
        }
        //双击
        private void GroupItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
            UnityManager.Instance.changeUnityScene(4);
            UnityManager.Instance.resourceMode = 1;
        }
        //双击
        private void labelName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
            UnityManager.Instance.changeUnityScene(4);
            UnityManager.Instance.resourceMode = 1;
        }

        private void pictureBoxGroupFace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
            UnityManager.Instance.changeUnityScene(4);
            UnityManager.Instance.resourceMode = 1;
        }
    }
}
