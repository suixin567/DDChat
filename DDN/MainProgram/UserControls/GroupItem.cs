﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Mgr;

namespace MainProgram.UserControls
{
    public partial class GroupItem : UserControl
    {
        public MyGroupModel m_myGroupModel;

        public GroupInfoModel m_groupInfoModel;

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
            //圆形头像
            pictureBoxGroupFace.Image = ImageTool.CutEllipse(pictureBoxGroupFace.Image);
            //获取这个群的基本信息
            string info = HttpReqHelper.request(AppConst.WebUrl + "groupBaseInfo?gid=" + m_myGroupModel.GroupID);
            GroupInfoModel model = Coding<GroupInfoModel>.decode(info);
            m_groupInfoModel = model;

            labelName.Text = model.Name;

            //下载头像
            if (model.Face != "")
            {
                Image image = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + model.Face);
                if (image != null)
                {
                    Image newImage = ImageTool.CutEllipse(image);
                    this.pictureBoxGroupFace.Image = newImage;
                }
            }
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
    }
}