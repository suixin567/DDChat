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

namespace DDN.UserControls
{
    public partial class GroupItem : UserControl
    {
        public string m_groupID;

        public GroupItem()
        {
            InitializeComponent();
        }

        public GroupItem(string groupNumber)
        {
            if (m_groupID == "")
            {
                Dispose();
                return;
            }

            InitializeComponent();
            m_groupID = groupNumber;
            //圆形头像
            pictureBoxGroupFace.Image = ImageTool.CutEllipse(pictureBoxGroupFace.Image);
        }


        private void GroupItem_Load(object sender, EventArgs e)
        {
            ////获取这个好友的基本信息
            //string friendInfo = HttpReqHelper.request(AppConst.WebUrl + "baseInfo?username=" + FriendUsername);
            //PersonalInfoModel model = Coding<PersonalInfoModel>.decode(friendInfo);
            //friendNickName.Text = model.Nickname;
            //LabelDescription.Text = model.Description;
            ////下载头像
            //if (model.Face != "")
            //{
            //    Image image = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + model.Face);
            //    if (image != null)
            //    {
            //        Image newImage = ImageTool.CutEllipse(image);
            //        this.friendFacePictureBox.Image = newImage;
            //    }
            //}
        //}
    }
    }
}
