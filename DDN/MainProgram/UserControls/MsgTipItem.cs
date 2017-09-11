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
using System.Threading;
using System.Drawing.Drawing2D;

namespace MainProgram.UserControls
{
    public partial class MsgTipItem : UserControl
    {
        public SynchronizationContext m_SyncContext = null;
        MsgModel m_mode;
        delegate void SetTextCallback(string text);
        delegate void SetImgCallback(Image img);
        public MsgTipItem()
        {
            InitializeComponent();

        }

        public MsgTipItem(MsgModel mode)
        {
            m_mode = mode;
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void MsgTipItem_Load(object sender, EventArgs e)
        {
            if (m_mode==null)
            {
                return;
            }
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBox.DisplayRectangle, 0, 360);
            pictureBox.Region = new Region(path);

            switch (m_mode.MsgType)
            {
                case MessageProtocol.ONE_ADD_YOU_SRES://有人添加你
                    this.labelContent.Text = "附加消息："+m_mode.Content;
                    pullOtherFaceAndName(AppConst.WebUrl + "baseInfo?username=" + m_mode.From);
                    break;
                case MessageProtocol.ONE_AGREED_YOU://别人同意你的好友申请
                    this.labelContent.Text = "附加消息：" + m_mode.Content;
                    pullOtherFaceAndName(AppConst.WebUrl + "baseInfo?username=" + m_mode.From);
                    break;
                case MessageProtocol.ONE_WANT_ADD_GROUP_SRES://有人申请入群
                    this.labelNickName.Text = "";
                    this.labelContent.Text = "验证消息";
                    //头像应为一个喇叭图片TODO:
                    break;
                case MessageProtocol.YOU_BE_AGREED_ENTER_GROUP://被同意入群
                    labelNickName.Text = "群名字";
                    labelContent.Text = "已加入群聊，来聊天吧！";
                    //头像应为群图片TODO:
                    break;
                case MessageProtocol.CHAT_FRIEND_TO_ME_SRES://朋友和我聊天
                    labelNickName.Text = m_mode.From;
                    labelContent.Text = m_mode.Content;
                 //   pictureBox.Image = "发来消息的人的头像"  TODO:
                    break;
                case MessageProtocol.CHAT_GROUP_TO_ME_SRES://群向我聊天
                    labelNickName.Text = m_mode.To;
                    labelContent.Text = m_mode.Content;
                    //   pictureBox.Image = "发来消息的群的头像"  TODO:
                    break;
                default:
                    Debug.Print("MsgTipItem：未知协议类型" + m_mode.MsgType);
                    break;
            }
        }


        //拉取对方的头像和昵称
        void pullOtherFaceAndName(string url)
        {
            //对方信息（昵称和头像）
            HttpReqHelper.requestSync(url, delegate (string info)
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
                    this.SetText(model.Nickname);
                    //请求头像
                    HttpReqHelper.loadFaceSync(model.Face, delegate (Image face)
                    {
                        if (face != null)
                        {
                            this.SetImg(face);
                        }
                    });
                }
            });
        }


        //安全设置图片
        public void setImageSafePost(Image ima)
        {
            m_SyncContext.Post(setImage, ima);
        }
        void setImage(object state)
        {
            Debug.Print("我被设置tupian了" + (string)state);
            this.pictureBox.Image = (Image)state;
        }

        //被点击
        private void MsgTipItem_Click(object sender, EventArgs e)
        {
            Debug.Print("被点击");
            MsgTip FormMsgTip = (MsgTip)this.FindForm();
            //处理这些待处理消息
            FormMsgTip.processTipMsg();
        }
        //被点击
        private void labelNickName_Click(object sender, EventArgs e)
        {
            MsgTipItem_Click(null, null);
        }
        //被点击
        private void labelContent_Click(object sender, EventArgs e)
        {
            MsgTipItem_Click(null,null);
        }









        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.labelNickName.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.labelNickName.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.labelNickName.Disposing || this.labelNickName.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(SetText);
                this.labelNickName.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelNickName.Text = text;
            }
        }


        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetImg(Image img)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.pictureBox.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.pictureBox.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.pictureBox.Disposing || this.pictureBox.IsDisposed)
                        return;
                }
                SetImgCallback d = new SetImgCallback(SetImg);
                this.pictureBox.Invoke(d, new object[] { img });
            }
            else
            {
                this.pictureBox.Image = img;
            }
        }
    }
}
