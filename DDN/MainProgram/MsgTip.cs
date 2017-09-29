using Dialog;
using MainProgram.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class MsgTip : Form
    {

        //#region 单例
        //private static MsgTip instance;
        //public static MsgTip Instance {
        //    get {
        //        if (instance ==null)
        //        {
        //            instance = new MsgTip();
        //        }
        //        return instance;
        //    }
        //}
        //#endregion

        public SynchronizationContext m_SyncContext = null;
        //需要提示的消息
        public List<MsgModel> tipMsgList = new List<MsgModel>();

        public MsgTip()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void MsgTip_Load(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width , this.flowLayoutPanel1.Size.Height+40);
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x,y);
        }

        //添加新提示
        public void addNewTip(MsgModel mode) {
            //这里应该过滤一些重复的提示消息，如：重复的申请好友提示、申请入群
            foreach (var item in tipMsgList)
            {
                //过滤同一个人发来的重复的好友申请。
                if (item.MsgType == mode.MsgType && item.From == mode.From && mode.MsgType == MessageProtocol.ONE_ADD_YOU_SRES)
                {
                    return;
                }
                //过滤同一个人发来的重复的入同一个群的申请。
                if (item.MsgType == mode.MsgType && item.From == mode.From && item.To == mode.To && mode.MsgType == MessageProtocol.ONE_WANT_ADD_GROUP_SRES)
                {
                    return;
                }
            }
            //添加一个新的提示
            tipMsgList.Add(mode);
            MsgTipItem tipItem = new MsgTipItem(mode);
            addItemSafePost(tipItem);
            MainMgr.Instance.formMain.notifyIonFlashSafePost();//icon闪烁
            showFormSafePost();
            
        }

        //处理提示消息
        public void processTipMsg() {
            MainMgr.Instance.formMain.stopInconFlash();
            //用户已做处理，清空待处理
            for (int i = 0; i < tipMsgList.Count; i++)
            {
                switch (tipMsgList[i].MsgType)
                {
                    case MessageProtocol.ONE_ADD_YOU_SRES://有人申请加好友
                        VerifyMsgMgr.Instance.openFormMesageVerify();
                        break;
                    case MessageProtocol.ONE_AGREED_YOU://别人同意你加好友
                        Image face1 = null;
                        string nickName1 = "";
                        foreach (var item in this.flowLayoutPanel1.Controls)
                        {
                            MsgTipItem mi = (MsgTipItem)item;
                            if (mi.m_mode.MsgType == MessageProtocol.ONE_AGREED_YOU && mi.m_mode.From == tipMsgList[i].From)//找到这个item
                            {
                                face1 = mi.pictureBox.Image;
                                nickName1 = mi.labelNickName.Text;
                                break;
                            }
                        }
                        //打开这个人的聊天对话
                        FormDialogManager.Instance.openDialog(3, int.Parse(tipMsgList[i].From), nickName1, face1);
                        break;
                    case MessageProtocol.ONE_WANT_ADD_GROUP_SRES://有人想加群
                        VerifyMsgMgr.Instance.openFormMesageVerify();
                        break;
                    case MessageProtocol.YOU_BE_AGREED_ENTER_GROUP://被同意入群
                        Image face2 = null;
                        string nickName2 = "";
                        foreach (var item in this.flowLayoutPanel1.Controls)
                        {
                            MsgTipItem mi = (MsgTipItem)item;
                            if (mi.m_mode.MsgType == MessageProtocol.YOU_BE_AGREED_ENTER_GROUP && mi.m_mode.To == tipMsgList[i].To)//找到这个item
                            {
                                face2 = mi.pictureBox.Image;
                                nickName2 = mi.labelNickName.Text;
                                break;
                            }
                        }
                        //打开这个群的聊天对话
                        FormDialogManager.Instance.openDialog(1, int.Parse(tipMsgList[i].To), nickName2, face2);
                        break;
                    case MessageProtocol.CHAT_FRIEND_TO_ME_SRES://朋友和我聊天
                        Image face3 = null;
                        string nickName3 = "";
                        foreach (var item in this.flowLayoutPanel1.Controls)
                        {
                            MsgTipItem mi = (MsgTipItem)item;
                            if (mi.m_mode.MsgType == MessageProtocol.CHAT_FRIEND_TO_ME_SRES && mi.m_mode.From == tipMsgList[i].From)//找到这个item
                            {
                                face3 = mi.pictureBox.Image;
                                nickName3 = mi.labelNickName.Text;
                                break;
                            }
                        }
                        FormDialogManager.Instance.openDialog(3, int.Parse(tipMsgList[i].From), nickName3, face3);
                        FormDialogManager.Instance.onChatMsg(tipMsgList[i]);
                        break;
                    case MessageProtocol.CHAT_GROUP_TO_ME_SRES://群和我聊天
                        Image face4 = null;
                        string nickName4 = "";
                        foreach (var item in this.flowLayoutPanel1.Controls)
                        {
                            MsgTipItem mi = (MsgTipItem)item;
                            if (mi.m_mode.MsgType == MessageProtocol.CHAT_GROUP_TO_ME_SRES && mi.m_mode.To== tipMsgList[i].To)//找到这个item
                            {
                                face4 = mi.pictureBox.Image;
                                nickName4 = mi.labelNickName.Text;
                                break;
                            }                            
                        }
                        FormDialogManager.Instance.openDialog(1, int.Parse(tipMsgList[i].To), nickName4, face4);
                        FormDialogManager.Instance.onChatMsg(tipMsgList[i]);//展示消息
                        break;
                    default:
                        Debug.Print("MsgTip:未知消息类型" + tipMsgList[i].MsgType);
                        break;
                }
            }
            tipMsgList.Clear();
            this.flowLayoutPanel1.Controls.Clear();
            this.Hide();
        }






        void addItemSafePost(MsgTipItem item)
        {
            m_SyncContext.Post(addItem, item);
        }

        void addItem(object state)
        {
            this.flowLayoutPanel1.Controls.Add((MsgTipItem)state);
        }


        void showFormSafePost() {
            m_SyncContext.Post(showForm, null);
        }

        void showForm(object state)
        {
            this.Size = new Size(this.Size.Width, this.flowLayoutPanel1.Size.Height + 40);
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height);
            this.Location = new Point(x,y);// (Point)new Size(x, y);
            this.Show();
        }
    

    }
  
}
