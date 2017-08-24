using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;

namespace MainProgram.UserControls
{
    public partial class MsgVerifyItem : UserControl
    {
        public SynchronizationContext m_SyncContext = null;
        public VerifyMsgModel m_MsgModel =new VerifyMsgModel();

        public MsgVerifyItem()
        {
            InitializeComponent();
        }

        public MsgVerifyItem(VerifyMsgModel msgModel)
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            m_MsgModel = msgModel;
        }

        private void FriendVerifyItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBoxFace.DisplayRectangle, 0, 360);
            pictureBoxFace.Region = new Region(path);
            //控件赋值
            switch (m_MsgModel.MsgType)
            {
                case MessageProtocol.ADD_FRIEND_SRES://添加好友的响应
                    this.labelUsername.Text = m_MsgModel.To;
                    this.labelContent.Text = "消息内容：已发送好友申请，等待对方验证。";
                    this.labelTime.Text = m_MsgModel.Time;
                    this.buttonYes.Hide();
                    this.buttonIgnore.Hide();
                    this.labelProcessMark.Hide();
                    pullOtherFaceAndName(AppConst.WebUrl + "baseInfo?username=" + m_MsgModel.To);
                    break;
                case MessageProtocol.ONE_ADD_YOU_SRES://有人想加你
                    this.labelUsername.Text = m_MsgModel.From;
                    this.labelContent.Text = m_MsgModel.Content;
                    this.labelTime.Text = m_MsgModel.Time;
                    if (m_MsgModel.IsDealed == true)//已处理
                    {
                        this.labelProcessMark.Text = "已处理";
                        this.buttonYes.Hide();
                        this.buttonIgnore.Hide();
                    }
                    else {
                        this.labelProcessMark.Hide();
                    }
                    pullOtherFaceAndName(AppConst.WebUrl + "baseInfo?username=" + m_MsgModel.From);
                    break;
                case MessageProtocol.ADD_GROUP_SRES://申请加群的响应
                    this.labelUsername.Text = m_MsgModel.To;
                    this.labelContent.Text = "消息内容：已发送入群申请，等待群主验证。";
                    this.labelTime.Text = m_MsgModel.Time;
                    this.buttonYes.Hide();
                    this.buttonIgnore.Hide();
                    //TODO: 应拉取这个群的头像和群名字
                    break;
                case MessageProtocol.ONE_WANT_ADD_GROUP_SRES://有人想加入群
                    this.labelNickName.Text = "申请人的昵称 申请加入群 群的昵称";
                    this.labelUsername.Text = m_MsgModel.From;
                    this.labelContent.Text = "消息内容："+ m_MsgModel.Content;
                    this.labelTime.Text = m_MsgModel.Time;
                    if (m_MsgModel.IsDealed == true)//已处理
                    {
                        this.labelProcessMark.Text = "已处理";
                        this.buttonYes.Hide();
                        this.buttonIgnore.Hide();
                    }
                    else
                    {
                        this.labelProcessMark.Hide();
                    }
                    //TODO: 以及申请人的头像还没有
                    break;
                default:
                    Debug.Print("这条协议还没有做处理"+ m_MsgModel.MsgType);
                    break;
            }
        }


        //拉取对方的头像和昵称
        void pullOtherFaceAndName(string url) {
            //对方信息（昵称和头像）
            HttpReqHelper.requestSync(url , delegate (string info)
            {
                if (info != "null")
                {
                    PersonalInfoModel model = new PersonalInfoModel();
                    try
                    {
                        model = Coding<PersonalInfoModel>.decode(info);
                    }
                    catch (Exception err)
                    {
                        Debug.Print("MsgVerifyItem.FriendVerifyItem_Load解析错误" + err.ToString());
                        return;
                    }
                    //  this.labelNickName.Text = model.Nickname;
                    setLabelSafePost(model.Nickname);
                    //请求头像
                    HttpReqHelper.loadFaceSync(model.Face, delegate (Image face)
                    {
                        if (face != null)
                        {
                            //        this.pictureBoxFace.Image = face;
                            setImageSafePost(face);
                        }
                    });
                }
            });
        }

        //安全设置label
        public void setLabelSafePost(string content)
        {
            m_SyncContext.Post(setLabel, content);
        }
        void setLabel(object state)
        {
            this.labelNickName.Text = (string)state;
        }

        //安全设置图片
        public void setImageSafePost(Image ima)
        {
            m_SyncContext.Post(setImage, ima);
        }
        void setImage(object state)
        {
            this.pictureBoxFace.Image = (Image)state;
        }
        //安全设置自己为已被处理
        public void setProcessedSafePost()
        {
            m_SyncContext.Post(setProcessed, null);
        }
        void setProcessed(object state)
        {
            this.buttonYes.Hide();
            this.buttonIgnore.Hide();

            this.labelProcessMark.Text = "已处理";
            this.labelProcessMark.Show();
        }


        //通过验证
        private void buttonYes_Click(object sender, EventArgs e)
        {
            switch (m_MsgModel.MsgType)
            {
                case MessageProtocol.ONE_ADD_YOU_SRES://有人申请加好友
                    MsgModel model = new MsgModel(MessageProtocol.AGREE_ADD_FRIEND_CREQ, PlayerPrefs.GetString("username"), this.m_MsgModel.From, "我通过了你的好友申请", DateTime.Now.ToString());
                    MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.FRIEND, model);
                    break;
                case MessageProtocol.ONE_WANT_ADD_GROUP_SRES://有人申请入群
                    MsgModel model2 = new MsgModel(MessageProtocol.AGREE_ADD_GROUP_CREQ, this.m_MsgModel.From, this.m_MsgModel.To, "我通过了你的入群申请", DateTime.Now.ToString());
                    MainMgr.Instance.msgMgr.sendMessage(MessageProtocol.GROUP, model2);
                    break;
                default:
                    break;
            }
            
        }

        //忽略按钮
        private void buttonIgnore_Click(object sender, EventArgs e)
        {             
        }
    }
}
