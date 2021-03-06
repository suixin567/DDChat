﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Drawing2D;
using Dialog;
using ToolLib;

namespace MainProgram.UserControls
{
    public partial class FriendItem : UserControl
    {
        #region 属性
        public string FriendUsername;

        private PersonalInfoModel m_friendModel;
        public PersonalInfoModel m_FriendModel
        {
            get {
                return m_friendModel;
            }
            set {
                m_friendModel = value;
            }
        }
        public SynchronizationContext m_SyncContext = null;
        #endregion

        public FriendItem()
        {
            InitializeComponent();          
        }


        public FriendItem( string friendUsername)
        {
            if (friendUsername=="") {
                Dispose();
                return;
            }
            InitializeComponent();     
                  
            FriendUsername = friendUsername;
        }

        private void FriendItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(friendFacePictureBox.DisplayRectangle, 0, 360);
            friendFacePictureBox.Region = new Region(path);

            m_SyncContext = SynchronizationContext.Current;
            //获取这个好友的基本信息
            DataMgr.Instance.getPersonalByID(FriendUsername,delegate(PersonalInfoModel friendModel) {
                Debug.Print("朋友的信息：" + FriendUsername +"   "+ friendModel .Username+ friendModel.Nickname);
                m_friendModel = friendModel;
                initLabelSafePost();
                //下载头像
                if (m_friendModel.Face != "")
                {
                    FaceMgr.Instance.getFaceByName(m_friendModel.Face, delegate (Image face) {
                        if (face != null)
                        {
                            friendFacePictureBox.Image = face;
                        }
                    });
                }
            });

        }


        void initLabelSafePost() {
            m_SyncContext.Post(initLabel,null);
        }
        void initLabel(object state)
        {     
            friendNickName.Text = m_friendModel.Nickname;
            LabelDescription.Text = m_friendModel.Description;
        }


        private void 删除好友ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FriendUsername=="111111") {
                Label labelTip = new Label();
                ((FormMain)FindForm()).flowLayoutPanelFriendList.Controls.Add(labelTip);
                labelTip.Text = "怎么连客服妹妹也要删？";
                labelTip.Size = new Size(140, 25);
                labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                labelTip.ForeColor = Color.White;
                labelTip.TextAlign = ContentAlignment.MiddleCenter;
                labelTip.BackColor = Color.DodgerBlue;
                Point po = new Point(this.Location.X + 10, this.Location.Y + 10);
                labelTip.Location = po;
                labelTip.BringToFront();
                Thread th = new Thread(new ParameterizedThreadStart(closeTip));
                th.Start(labelTip);
                return;
            }
            Debug.Print("删除好友");
            MsgModel mm = new MsgModel(MessageProtocol.DELETE_FRIEND_CREQ, AppInfo.USER_NAME, FriendUsername, "我把你删除好友了，再见。", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.FRIEND, mm);
        }

        void closeTip(object tip) {
            Thread.Sleep(2000);
            disponseTipSafePost(((Label)tip));
        }

       
        public void disponseTipSafePost(Label labelTip)
        {
            m_SyncContext.Post(disponseTip, labelTip);
        }
     
        void disponseTip(object state)
        {
            ((Label)state).Dispose();
        }



        //好友Item被双击
        private void FriendItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormDialogManager.Instance.openDialog(3,int.Parse(m_friendModel.Username) , m_friendModel.Nickname, friendFacePictureBox.Image);
            //Label labelTip = new Label();
            //((FormMain)FindForm()).flowLayoutPanelFriendList.Controls.Add(labelTip);
            //labelTip.Text = "暂时不能和对方聊天";
            //labelTip.Size = new Size(140, 25);
            //labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            //labelTip.ForeColor = Color.White;
            //labelTip.TextAlign = ContentAlignment.MiddleCenter;
            //labelTip.BackColor = Color.DodgerBlue;
            //Point po = new Point(this.Location.X + 10, this.Location.Y + 10);
            //labelTip.Location = po;
            //labelTip.BringToFront();
            //Thread th = new Thread(new ParameterizedThreadStart(closeTip));
            //th.Start(labelTip);
        }

        private void friendFacePictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FriendItem_MouseDoubleClick(null,null);
        }

        private void friendNickName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FriendItem_MouseDoubleClick(null, null);
        }

        private void LabelDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FriendItem_MouseDoubleClick(null, null);
        }

        
        //鼠标进入头像范围内，则展示资料
        private void friendFacePictureBox_MouseEnter(object sender, EventArgs e)
        {
            FormInfoCard.Instance.SetPersionalCard(PointToScreen(this.friendFacePictureBox.Location), m_friendModel,this.friendFacePictureBox.Image);
            FormInfoCard.Instance.enterItem(m_friendModel.Username);
        }

        //鼠标离开后关闭资料展示
        private void friendFacePictureBox_MouseLeave(object sender, EventArgs e)
        {
            FormInfoCard.Instance.leaveItem(m_friendModel.Username);           
        }

        //查看好友资料
        FormShowPersonalInfo formModifyPersonalInfo = null;
        private void 查看资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formModifyPersonalInfo == null || formModifyPersonalInfo.IsDisposed)
            {
                formModifyPersonalInfo = new FormShowPersonalInfo(m_friendModel,this.friendFacePictureBox.Image);
                formModifyPersonalInfo.Show();
            }
        }

        private void 发送消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FriendItem_MouseDoubleClick(null,null);
        }
    }
}
