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

        MsgModel m_MsgModel=new MsgModel();//可能申请加好友，可能申请入群等等。

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
            Image newImage =ImageTool.CutEllipse(pictureBoxFace.Image);
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
                    Image newImage2 = ImageTool.CutEllipse(image);
                    this.pictureBoxFace.Image = newImage2;
                }
            }

            //跟据消息类型 进行不同的展示
            switch (m_MsgModel.MsgType)
            {
                case MsgProtocol.ONE_AGREED_YOU://别人同意了你的好友申请
                    this.buttonYes.Hide();
                    this.buttonIgnore.Hide();
                 //Manager.Instance.msgMgr.mList.Remove(m_MsgModel);
                    //Debug.Print("移除了这个不需要操作的消息" + Manager.Instance.msgMgr.mList.Count.ToString());
                    break;
                case MsgProtocol.YOU_BE_DELETED://被删除好友
                    this.buttonYes.Hide();
                    this.buttonIgnore.Hide();
                 //Manager.Instance.msgMgr.mList.Remove(m_MsgModel);
                    // Debug.Print("移除了这个不需要操作的消息" + Manager.Instance.msgMgr.mList.Count.ToString());
                    break;
                case MsgProtocol.YOU_BE_AGREED_ENTER_GROUP://被同意进群
                    this.buttonYes.Hide();
                    this.buttonIgnore.Hide();
                    //Manager.Instance.msgMgr.mList.Remove(m_MsgModel);
                    // Debug.Print("移除了这个不需要操作的消息" + Manager.Instance.msgMgr.mList.Count.ToString());
                    break;
                default:
                    break;
            }
        }

        //通过验证
        private void buttonYes_Click(object sender, EventArgs e)
        {
            switch (m_MsgModel.MsgType)
            {
                case MsgProtocol.ONE_ADD_YOU_SRES://有人申请加好友
                    MsgModel model = new MsgModel(MsgProtocol.AGREE_ADD_FRIEND_CREQ, GameInfo.ACC_ID, this.m_MsgModel.From, "我通过了你的好友申请", DateTime.Now.ToString());
                    Manager.Instance.msgMgr.sendMessage(MsgProtocol.FRIEND, model);
                    break;
                case MsgProtocol.ONE_WANT_ADD_GROUP_SRES://有人申请入群
                    MsgModel model2 = new MsgModel(MsgProtocol.AGREE_ADD_GROUP_CREQ, this.m_MsgModel.From, this.m_MsgModel.To, "我通过了你的入群申请", DateTime.Now.ToString());
                    Manager.Instance.msgMgr.sendMessage(MsgProtocol.GROUP, model2);
                    break;
                default:
                    break;
            }
            
        }

        //忽略按钮
        private void buttonIgnore_Click(object sender, EventArgs e)
        {
            Manager.Instance.msgMgr.mList.Remove(m_MsgModel);
            this.Dispose();                
        }
    }
}
