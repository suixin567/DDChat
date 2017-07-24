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
using System.Threading;

namespace MainProgram.UserControls
{
    public partial class FriendItem : UserControl
    {
        public string FriendUsername;

        public SynchronizationContext m_SyncContext = null;

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
            //圆形头像
            friendFacePictureBox.Image =ImageTool.CutEllipse(friendFacePictureBox.Image);
            FriendUsername = friendUsername;        
        }

        private void FriendItem_Load(object sender, EventArgs e)
        {
            //获取这个好友的基本信息
            string friendInfo = HttpReqHelper.request(AppConst.WebUrl + "baseInfo?username=" + FriendUsername);
            PersonalInfoModel model = Coding<PersonalInfoModel>.decode(friendInfo);
            friendNickName.Text = model.Nickname;
            LabelDescription.Text = model.Description;
            //下载头像
            if (model.Face != "")
            {
                Image image = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + model.Face);
                if (image != null)
                {
                    Image newImage = ImageTool.CutEllipse(image);
                    this.friendFacePictureBox.Image = newImage;
                }
            }
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
            MsgModel mm = new MsgModel(MsgProtocol.DELETE_FRIEND_CREQ, PlayerPrefs.GetString("username"), FriendUsername, "我把你删除好友了，再见。", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MsgProtocol.FRIEND, mm);
        }

        //好友Item被双击
        private void FriendItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label labelTip = new Label();
            ((FormMain)FindForm()).flowLayoutPanelFriendList.Controls.Add(labelTip);
            labelTip.Text = "暂时不能和对方聊天";
            labelTip.Size = new Size(140, 25);
            labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            labelTip.ForeColor = Color.White;
            labelTip.TextAlign = ContentAlignment.MiddleCenter;
            labelTip.BackColor = Color.DodgerBlue;
            Point po = new Point(this.Location.X +10, this.Location.Y+10 );
            labelTip.Location = po;
            labelTip.BringToFront();
            Thread th = new Thread(new ParameterizedThreadStart(closeTip));
            th.Start(labelTip);
        }



        void closeTip(object tip) {
            Thread.Sleep(2000);
            disponseTipSafePost(((Label)tip));
        }

       
        public void disponseTipSafePost(Label labelTip)
        {
            m_SyncContext = ((FormMain)FindForm()).m_SyncContext;
            m_SyncContext.Post(disponseTip, labelTip);
        }
     
        void disponseTip(object state)
        {
            ((Label)state).Dispose();
        }

        private void friendFacePictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label labelTip = new Label();
            ((FormMain)FindForm()).flowLayoutPanelFriendList.Controls.Add(labelTip);
            labelTip.Text = "暂时不能和对方聊天";
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
        }

        private void friendNickName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label labelTip = new Label();
            ((FormMain)FindForm()).flowLayoutPanelFriendList.Controls.Add(labelTip);
            labelTip.Text = "暂时不能和对方聊天";
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
        }

        private void LabelDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label labelTip = new Label();
            ((FormMain)FindForm()).flowLayoutPanelFriendList.Controls.Add(labelTip);
            labelTip.Text = "暂时不能和对方聊天";
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
        }
    }
}
