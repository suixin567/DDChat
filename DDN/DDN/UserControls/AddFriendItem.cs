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
using static DDN.MsgMgr;

namespace DDN
{
    public partial class AddFriendItem : UserControl
    {

        string m_userName;
        string m_nickName;
        string m_face;

        public AddFriendItem(string username,string nickname,string face) {
            InitializeComponent();
            m_userName = username;
            m_nickName = nickname;
            m_face = face;     
        }


        private void AddFriendItem_Load(object sender, EventArgs e)
        {
            this.labelUsername.Text = m_userName;
            this.labelNickName.Text = m_nickName;
            //下载头像
            if (m_face != "")
            {
                Image image = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + m_face);
                if (image != null)
                {
                    Image newImage = CutEllipse(image, new Rectangle(0, 0, 200, 200), new Size(62, 62));
                    this.pictureBoxFace.Image = newImage;
                    //   this.pictureBoxTopFace.Image=image;
                }

            }
        }

        //绘制圆图片
        private Image CutEllipse(Image img, Rectangle rec, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            return bitmap;
        }

        //申请添加好友
        private void buttonAddFriend_Click(object sender, EventArgs e)
        {
            if (Manager.Instance.formMain.flowLayoutPanelFriendList.getFriendList().Contains(this.labelUsername.Text)) {
                ((FormAddFriend)this.FindForm()).showOpreationResult("对方已经是你的好友了！", 2);
                return;
            }

            MsgModel mm = new MsgModel(MsgProtocol.ADD_FRIEND_CREQ, GameInfo.ACC_ID, this.labelUsername.Text,"我们加个好友吧！", DateTime.Now.ToString());
            Manager.Instance.msgMgr.sendMessage(MsgProtocol.FRIEND,mm);      
        }

    }
}
