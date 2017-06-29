using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDN.Tools;
using System.Diagnostics;

namespace DDN
{
    public partial class FriendItem : UserControl
    {
        public string FriendUsername;

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
            Debug.Print("删除好友");
            MsgModel mm = new MsgModel(MsgProtocol.DELETE_FRIEND_CREQ, GameInfo.ACC_ID, FriendUsername, "我把你删除好友了，再见。", DateTime.Now.ToString());
            Manager.Instance.msgMgr.sendMessage(MsgProtocol.FRIEND, mm);
        }
    }
}
