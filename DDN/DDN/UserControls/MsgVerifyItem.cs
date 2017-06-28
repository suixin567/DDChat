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
using DDN.Tools;

namespace DDN
{
    public partial class MsgVerifyItem : UserControl
    {

        MsgModel m_MsgModel=new MsgModel();

        public MsgVerifyItem()
        {
            InitializeComponent();
        }

        public MsgVerifyItem(MsgModel msgModel)
        {
            InitializeComponent();
            m_MsgModel = msgModel;
        }

        private void FriendVerifyItem_Load(object sender, EventArgs e)
        {
            //圆形头像
            Image newImage = CutEllipse(pictureBoxFace.Image, new Rectangle(0, 0, 200, 200), new Size(62, 62));
            pictureBoxFace.Image = newImage;
            //控件赋值
            this.labelUsername.Text = m_MsgModel.From;
            this.labelContent.Text = "消息内容：" + m_MsgModel.Content;
            this.labelTime.Text = m_MsgModel.Time;

            //对方信息（昵称和头像）
            string fromInfo = HttpReqHelper.request(AppConst.WebUrl + "baseInfo?username=" + m_MsgModel.From);

            if (fromInfo != "null")
            {
                PersonalInfoModel model = Coding<PersonalInfoModel>.decode(fromInfo);
                this.labelNickName.Text = model.Nickname;

                //请求头像
                Image image = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + model.Face);
                if (image != null)
                {
                    Image newImage2 = CutEllipse(image, new Rectangle(0, 0, 200, 200), new Size(62, 62));
                    this.pictureBoxFace.Image = newImage2;
                }
            }

            //跟据消息类型 进行不同的展示
            switch (m_MsgModel.MsgType)
            {
                case MsgProtocol.ONE_AGREED_YOU://别人同意了你的好友申请
                    this.buttonYes.Hide();
                    this.buttonNo.Hide();
                    this.buttonIgnore.Hide();
                    //消息列表中清除这个不需要操作的消息
                 //   Manager.Instance.msgMgr.mList.Remove(m_MsgModel);
                    // Debug.Print("移除了这个不需要操作的消息" + Manager.Instance.msgMgr.mList.Count.ToString());
                    break;
                case MsgProtocol.YOU_BE_DELETED://被删除好友
                    this.buttonYes.Hide();
                    this.buttonNo.Hide();
                    this.buttonIgnore.Hide();
                    //消息列表中清除这个不需要操作的消息
                 //   Manager.Instance.msgMgr.mList.Remove(m_MsgModel);
                    // Debug.Print("移除了这个不需要操作的消息" + Manager.Instance.msgMgr.mList.Count.ToString());
                    break;
                default:
                    break;
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

        //通过好友验证
        private void buttonYes_Click(object sender, EventArgs e)
        {

            MsgModel model = new MsgModel(MsgProtocol.AGREE_ADD_FRIEND_CREQ,GameInfo.ACC_ID,this.m_MsgModel.From, "我同意了你的好友申请",DateTime.Now.ToString());
            Manager.Instance.msgMgr.sendMessage(model);
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {

        }
       
    }
}
