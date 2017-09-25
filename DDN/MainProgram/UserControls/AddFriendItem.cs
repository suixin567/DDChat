using System;
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
    public partial class AddFriendItem : UserControl
    {

        string m_userName;
        string m_nickName;
        string m_face;

        public AddFriendItem()
        {
            InitializeComponent();
        }

        public AddFriendItem(string username,string nickname,string face) {
            InitializeComponent();
            m_userName = username;
            m_nickName = nickname;
            m_face = face;     
        }


        private void AddFriendItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBoxFace.DisplayRectangle, 0, 360);
            pictureBoxFace.Region = new Region(path);

            this.labelUsername.Text = m_userName;
            this.labelNickName.Text = m_nickName;
            //下载头像
            if (m_face != "")
            {
                HttpReqHelper.loadFaceSync(m_face,delegate(Image face) {
                    if (face != null)
                    {
                        this.pictureBoxFace.Image = face;
                    }
                });               
            }
        }     

        //申请添加好友
        private void buttonAddFriend_Click(object sender, EventArgs e)
        {
            if (MainMgr.Instance.formMain.flowLayoutPanelFriendList.getFriendList().Contains(this.labelUsername.Text))
            {
                ((FormAddFriend)this.FindForm()).showOpreationResultSafePost("对方已经是你的好友了！");
                return;
            }

            MsgModel mm = new MsgModel(MessageProtocol.ADD_FRIEND_CREQ, AppInfo.USER_NAME, this.labelUsername.Text, "我们加个好友吧！", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.FRIEND, mm);
            this.Dispose();   
        }

    }
}
