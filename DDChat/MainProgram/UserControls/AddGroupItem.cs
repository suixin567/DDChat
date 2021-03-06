﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Mgr;
using System.Drawing.Drawing2D;
using ToolLib;

namespace MainProgram.UserControls
{
    public partial class AddGroupItem : UserControl
    {

        string m_Name;
        int m_GID;
        string m_Face;


        public AddGroupItem()
        {
            InitializeComponent();
        }

        public AddGroupItem(string name, int gid, string face)
        {
            m_Name = name;
            m_GID = gid;
            m_Face = face;
            InitializeComponent();
        }




        private void AddGroupItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBoxFace.DisplayRectangle, 0, 360);
            pictureBoxFace.Region = new Region(path);

            this.labelName.Text = m_Name;
            this.labelGid.Text = m_GID.ToString();
            //下载头像
            if (m_Face != "")
            {
                FaceMgr.Instance.getFaceByName(m_Face,delegate(Image face) {
                    if (face != null)
                    {
                        this.pictureBoxFace.Image = face;
                    }
                });                
            }
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            if (MainMgr.Instance.formMain.flowLayoutPanelGroupList.getGroupList().Contains(m_GID))
            {
                ((FormAddFriend)this.FindForm()).showOpreationResultSafePost("你已经加入这个群了，无需重复加入。");
                return;
            }

            MsgModel mm = new MsgModel(MessageProtocol.ADD_GROUP_CREQ, AppInfo.USER_NAME, m_GID.ToString(), "让我也加入你们吧！", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.GROUP, mm);
            this.Dispose();
        }
    }
}
