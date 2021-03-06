﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Mgr;

namespace MainProgram.UserControls
{
    public partial class MainTabControl : UserControl
    {
        int currentSelectState = 1;//默认选中朋友列表

        Point oriLocation;
        Size oriSize;
        AnchorStyles OriAnchor;
        FormMain formMain;

        public MainTabControl()
        {
            InitializeComponent();            
        }

        private void MainTabControl_Load(object sender, EventArgs e)
        {
            formMain = MainMgr.Instance.formMain;
            if (formMain!=null) {
                oriLocation = formMain.flowLayoutPanelFriendList.Location;
                oriSize = formMain.flowLayoutPanelFriendList.Size;
                OriAnchor = formMain.flowLayoutPanelFriendList.Anchor;

                formMain.flowLayoutPanelDialogueList.Location = oriLocation;
                formMain.flowLayoutPanelDialogueList.Size = oriSize;
                formMain.flowLayoutPanelDialogueList.Anchor = OriAnchor;

                formMain.flowLayoutPanelGroupList.Location = oriLocation;
                formMain.flowLayoutPanelGroupList.Size = oriSize;
                formMain.flowLayoutPanelGroupList.Anchor = OriAnchor;

                switchState();
            }       
        }

     
        void switchState() {           

            switch (currentSelectState)
            {
                case 0:
                    formMain.flowLayoutPanelDialogueList.Show();
                    formMain.flowLayoutPanelFriendList.Hide();
                    formMain.flowLayoutPanelGroupList.Hide();
                    pictureBoxDia.BackColor = Color.FromArgb(100,100,100);
                    pictureBoxFriend.BackColor = Color.Transparent;
                    pictureBoxGroup.BackColor = Color.Transparent;
                 //   pictureBoxRes.BackColor = Color.Transparent;

                    break;
                case 1:
                    formMain.flowLayoutPanelDialogueList.Hide();
                    formMain.flowLayoutPanelFriendList.Show();
                    formMain.flowLayoutPanelGroupList.Hide();

                    pictureBoxDia.BackColor = Color.Transparent;
                    pictureBoxFriend.BackColor = Color.FromArgb(100, 100, 100);
                    pictureBoxGroup.BackColor = Color.Transparent;
                //    pictureBoxRes.BackColor = Color.Transparent;

                    break;
                case 2:
                    formMain.flowLayoutPanelDialogueList.Hide();
                    formMain.flowLayoutPanelFriendList.Hide();
                    formMain.flowLayoutPanelGroupList.Show();

                    pictureBoxDia.BackColor = Color.Transparent;
                    pictureBoxFriend.BackColor = Color.Transparent;
                    pictureBoxGroup.BackColor = Color.FromArgb(100, 100, 100);
                    //     pictureBoxRes.BackColor = Color.Transparent;
                    break;
                default:
                    break;
            }
        }
        Label m_labelTip = null;

        private void pictureBoxDia_MouseHover(object sender, EventArgs e)
        {
            Label labelTip = new Label();
            formMain.Controls.Add(labelTip);
            labelTip.Text = "会话";
            labelTip.Size = new Size(40, 20);
            labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            labelTip.TextAlign = ContentAlignment.MiddleCenter;
            labelTip.BackColor = Color.White;
            Point po = new Point(this.Location.X + 25, this.Location.Y + 30);
            labelTip.Location = po;
            labelTip.BringToFront();
            m_labelTip = labelTip;

        }

        private void pictureBoxDia_MouseLeave(object sender, EventArgs e)
        {
            if (m_labelTip != null)
            {
                m_labelTip.Dispose();
            }

        }

        private void pictureBoxFriend_MouseHover(object sender, EventArgs e)
        {

            Label labelTip = new Label();
            formMain.Controls.Add(labelTip);
            labelTip.Text = "联系人";
            labelTip.Size = new Size(55, 20);
            labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            labelTip.TextAlign = ContentAlignment.MiddleCenter;
            labelTip.BackColor = Color.White;
            Point po = new Point(this.Location.X + 110, this.Location.Y + 30);
            labelTip.Location = po;
            labelTip.BringToFront();
            m_labelTip = labelTip;

        }

        private void pictureBoxFriend_MouseLeave(object sender, EventArgs e)
        {
            if (m_labelTip != null)
            {
                m_labelTip.Dispose();
            }

        }

        private void pictureBoxGroup_MouseHover(object sender, EventArgs e)
        {

            Label labelTip = new Label();
            formMain.Controls.Add(labelTip);
            labelTip.Text = "群组";
            labelTip.Size = new Size(40, 20);
            labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            labelTip.TextAlign = ContentAlignment.MiddleCenter;
            labelTip.BackColor = Color.White;
            Point po = new Point(this.Location.X + 210, this.Location.Y + 30);
            labelTip.Location = po;
            labelTip.BringToFront();
            m_labelTip = labelTip;

        }

        private void pictureBoxGroup_MouseLeave(object sender, EventArgs e)
        {
            if (m_labelTip != null)
            {
                m_labelTip.Dispose();
            }

        }

        private void pictureBoxRes_MouseHover(object sender, EventArgs e)
        {

            Label labelTip = new Label();
            formMain.Controls.Add(labelTip);
            labelTip.Text = "资源管理";
            labelTip.Size = new Size(60, 20);
            labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            labelTip.TextAlign = ContentAlignment.MiddleCenter;
            labelTip.BackColor = Color.White;
            Point po = new Point(this.Location.X + 210, this.Location.Y + 30);
            labelTip.Location = po;
            labelTip.BringToFront();
            m_labelTip = labelTip;

        }

        private void pictureBoxRes_MouseLeave(object sender, EventArgs e)
        {
            if (m_labelTip != null)
            {
                m_labelTip.Dispose();
            }

        }

        private void pictureBoxDia_Click(object sender, EventArgs e)
        {
            currentSelectState = 0;
            switchState();

        }

        private void pictureBoxFriend_Click(object sender, EventArgs e)
        {
            currentSelectState = 1;
            switchState();

        }

        private void pictureBoxGroup_Click(object sender, EventArgs e)
        {
            currentSelectState = 2;
            switchState();

        }

        private void pictureBoxRes_Click(object sender, EventArgs e)
        {
            currentSelectState = 3;
            switchState();

        }
    }
}
