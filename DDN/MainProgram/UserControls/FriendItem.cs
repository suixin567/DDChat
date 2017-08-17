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
using System.Drawing.Drawing2D;
using Dialog;

namespace MainProgram.UserControls
{
    public partial class FriendItem : UserControl
    {
        public string FriendUsername;
        PersonalInfoModel m_friendModel = new PersonalInfoModel();
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
                  
            FriendUsername = friendUsername;
        }

        private void FriendItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(friendFacePictureBox.DisplayRectangle, 0, 360);
            friendFacePictureBox.Region = new Region(path);

            m_SyncContext = SynchronizationContext.Current;
            //获取这个好友的基本信息
            HttpReqHelper.requestSync(AppConst.WebUrl + "baseInfo?username=" + FriendUsername,delegate(string friendInfo) {
                Debug.Print("收到一名朋友的信息" + friendInfo);
                try
                {
                    m_friendModel = Coding<PersonalInfoModel>.decode(friendInfo);
                    initLabelSafePost();
                }
                catch (Exception err)
                {
                    Debug.Print("FriendItem.FriendItem_Load解析失败" + err.ToString());
                    return;
                }
                
                //下载头像
                if (m_friendModel.Face != "")
                {
                    HttpReqHelper.loadFaceSync(m_friendModel.Face,delegate(Image face) {
                        if (face != null)
                        {
                            friendFacePictureBox.Image = face;
                       //     faceRegionSafePost();
                        }
                    });                   
                }
            });           
        }

        //void faceRegionSafePost()
        //{           
        //    m_SyncContext.Post(faceRegion, null);
        //}
        //void faceRegion(object state)
        //{
        //    GraphicsPath path = new GraphicsPath();
        //    path.AddArc(friendFacePictureBox.DisplayRectangle, 360, 360);
        //    friendFacePictureBox.Region = new Region(path);
        //}




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
            MsgModel mm = new MsgModel(MsgProtocol.DELETE_FRIEND_CREQ, PlayerPrefs.GetString("username"), FriendUsername, "我把你删除好友了，再见。", DateTime.Now.ToString());
            MainMgr.Instance.msgMgr.sendMessage(MsgProtocol.FRIEND, mm);
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

        private void friendNickName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FriendItem_MouseDoubleClick(null, null);
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

        private void LabelDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FriendItem_MouseDoubleClick(null, null);
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
    }
}
