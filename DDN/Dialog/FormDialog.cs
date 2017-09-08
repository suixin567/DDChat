﻿using SmileWei.EmbeddedApp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using UnityModule;

namespace Dialog
{
    public partial class FormDialog : Form
    {
        #region 属性
        public SynchronizationContext m_SyncContext = null;
        int m_dialogType = -1;
        int m_groupOrFriendId = -1;
        public string m_title = "";
        Image m_face = null;
        public int UIState = 1;//对话窗的UI模式，0代表展示资源的状态，1代表聊天状态 ,2代表绘制状态
        public FormFace formFace;
        int Fmx, Fmy; //主窗口坐标
        #endregion



        public FormDialog(int type , int dialogId, string dialogName, Image face)
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            m_dialogType = type;
            m_groupOrFriendId = dialogId;
            m_title = dialogName;//TODO:如果传来的是空字符串，应该请求一下数据,群的名字必须要有才行，否则拉取不了群的资源！！！！！！！！！！！！！！！！！！！！！！
            this.m_face = face;
            Fmx = FormDialogManager.Instance.Left;
            Fmy = FormDialogManager.Instance.Top;
        }

        private void FormDialog_Load(object sender, EventArgs e)
        {
            Parent.Resize += new EventHandler(this.resize);
            //根据窗体类型 设置toppanel的按钮        
            switch (m_dialogType)
            {
                case 0://商城
                    break;
                case 1://群
                    this.groupMemberPanel1.Show();
                    //拉取群成员
                    HttpReqHelper.requestSync(AppConst.WebUrl + "groupMembers?gid=" + m_groupOrFriendId, delegate(string membersJson) {
                    this.groupMemberPanel1.initMember(membersJson);
                    });
                    break;
                case 2://个人
                    this.labelChat.Dispose();
                    break;
                case 3://朋友     
                    this.labelRes.Dispose();
                    this.labelDraw.Dispose();
                    this.groupMemberPanel1.Hide();
                    this.pictureBoxAd.Size = new Size(pictureBoxAd.Size.Width, pictureBoxAd.Size.Height*2);
                    break;
                default:
                    break;
            }
            labelChat.BackColor = Color.SteelBlue;
            //信息编辑框属性
            Rich_Edit.BackColor = Color.FromArgb(213, 224, 230);
            Rich_Edit.BorderStyle = BorderStyle.None;
            Rich_Edit.ScrollBars = RichTextBoxScrollBars.None;
          //  Rich_Edit.KeyUp += new KeyEventHandler(RichEdit_KeyUp);
            Rich_Edit.TextChanged += new EventHandler(RichEdit_TextChanged);
            labelTip.Text = "";
        }

        //编辑框文字改变，失去焦点在获得，引发编辑框和显示内容框重绘，从而显示动画和背景透明图片
        private void RichEdit_TextChanged(object sender, EventArgs e)
        {
            this.Focus();
            Rich_Edit.Focus();
        }

        void resize(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                this.Size = new Size(Parent.Width - 105, Parent.Height - 50 - 3);
            }
            switch (m_dialogType)
                {
                    case 0:
                        if (this.Size.Width > 300 && this.Size.Height > 200)
                        {
                            FormDialogManager.Instance.appContainer.Size = this.Size;
                        }
                        break;
                    case 1://群
                        if (this.Size.Width > 300 && this.Size.Height > 200)
                        {
                            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
                        }
                        break;
                    case 2:
                        if (this.Size.Width > 300 && this.Size.Height > 200)
                        {
                            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
                        }
                        break;
                    default:
                        break;
                }
        }


        //设置激活窗体时触发
        private void FormDialog_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible==false)
            {
                return;
            }
            switch (m_dialogType)
            {
                case 0:
                    this.flowLayoutPanelTop.Hide();
                    this.panelChat.Hide();
                    FormDialogManager.Instance.appContainer.Show();
                    FormDialogManager.Instance.appContainer.Location = this.Location;
                    UnityManager.Instance.resourceMode = 0;
                    UnityManager.Instance.changeUnityScene(4);
                    break;
                case 1:
                    FormDialogManager.Instance.appContainer.Hide();
                    UnityManager.Instance.currentGroup = m_title;
                    UnityManager.Instance.resourceMode = 1;
                    if (UIState == 0)//资源
                    {
                        FormDialogManager.Instance.appContainer.Show();
                        FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                        UnityManager.Instance.changeUnityScene(4);
                    }
                    else if (UIState == 1)//聊天
                    {
                        this.panelChat.Show();
                        FormDialogManager.Instance.appContainer.Hide();
                    }
                    else//绘制
                    {
                        FormDialogManager.Instance.appContainer.Show();
                        FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                        UnityManager.Instance.changeUnityScene(3);
                    }
                    break;
                case 2://个人
                    this.panelChat.Hide();
                    UnityManager.Instance.resourceMode = 2;
                    FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                    FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
                    FormDialogManager.Instance.appContainer.Show();
                    UnityManager.Instance.changeUnityScene(4);
                    break;
                case 3://朋友
                    this.panelChat.Show();
                    FormDialogManager.Instance.appContainer.Hide();
                    break;
                default:                                  
                    Debug.Print("FormDialog：未知类型");
                    break;
            }
            resize(null,null);
        }

        //聊天选项卡
        private void labelChat_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanelTop.Controls)
            {
                ((Label)item).BackColor = Color.Transparent;
            }
            labelChat.BackColor = Color.SteelBlue;
            UIState = 1;
            panelChat.Show();
            FormDialogManager.Instance.appContainer.Hide();
        }
        //资源选项卡
        private void labelRes_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanelTop.Controls)
            {
                ((Label)item).BackColor = Color.Transparent;
            }
            labelRes.BackColor = Color.SteelBlue;
            UIState = 0;
            panelChat.Hide();
            UnityManager.Instance.changeUnityScene(4);
            FormDialogManager.Instance.appContainer.Show();
            FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
        }

        //画房子选项卡
        private void labelDraw_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanelTop.Controls)
            {
                ((Label)item).BackColor = Color.Transparent;
            }
            labelDraw.BackColor = Color.SteelBlue;
            UIState = 2;
            panelChat.Hide();
            UnityManager.Instance.changeUnityScene(3);
            FormDialogManager.Instance.appContainer.Show();
            FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
        }


        /// ////////////////////////////////////////////////////////
        /// ////////////////////////*聊*天*////////////////////////////////
        /// ////////////////////////////////////////////////////////
       

        //打开表情面板
        private void pictureBoxaFaceBtn_Click(object sender, EventArgs e)
        {
            if (formFace == null)
            {
                formFace = new FormFace(this);
                formFace.TopLevel = false;
                formFace.Parent = FormDialogManager.Instance;
                formFace.Left =110;
                formFace.Top = 350;
                formFace.BringToFront();
                formFace.Show();
            }
        }


        public void showOnePopSafePost(MsgModel mm) {
            m_SyncContext.Post(showOnePop , mm);
        }
       void showOnePop(object content)
        {
            ChatPop chatPop = new ChatPop((MsgModel)content);
            this.flowLayoutPanel1.Controls.Add(chatPop);
            //  this.flowLayoutPanel1.Controls.SetChildIndex(chatPop, 0);
            //this.flowLayoutPanel1.VerticalScroll.Value = 1;
            Point newPoint = new Point(0, 100000);
            flowLayoutPanel1.AutoScrollPosition = newPoint;
        }

        //发送按钮
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (Rich_Edit.Rtf.Length > AppConst.maxReceiveSize)
            {
                Debug.Print("发送的消息过长！！！" + AppConst.maxReceiveSize);
                labelTip.Text = "发送的消息太长了";
                System.Windows.Forms.Timer disPlayLabelTipTimer = new System.Windows.Forms.Timer();
                disPlayLabelTipTimer.Interval = 3000;
                disPlayLabelTipTimer.Enabled = true;
                disPlayLabelTipTimer.Tick += new EventHandler((send, ev) => {
                    labelTip.Text = "";
                    ((System.Windows.Forms.Timer)send).Stop();
                    ((System.Windows.Forms.Timer)send).Dispose();
                });
                disPlayLabelTipTimer.Start();
                return;
            }

            switch (this.m_dialogType)
            {
                case 1://和群聊天
                    MsgModel groupMm = new MsgModel(MessageProtocol.CHAT_ME_TO_GROUP_CREQ, PlayerPrefs.GetString("username"), m_groupOrFriendId.ToString(), Rich_Edit.Rtf, DateTime.Now.ToString());
                    string groupMessage = Coding<MsgModel>.encode(groupMm);
                    Debug.Print("发出的聊天消息是:" + Rich_Edit.Rtf);
                    NetWorkManager.Instance.sendMessage(Protocol.MESSAGE, -1, MessageProtocol.CHAT, groupMessage);
                    Rich_Edit.Rtf = "";
                    break;
                case 3://和朋友聊天              
                    MsgModel mm = new MsgModel(MessageProtocol.CHAT_ME_TO_FRIEND_CREQ, PlayerPrefs.GetString("username"), m_groupOrFriendId.ToString(), Rich_Edit.Rtf, DateTime.Now.ToString());
                    string message = Coding<MsgModel>.encode(mm);
                    Debug.Print("发出的聊天消息是:" + Rich_Edit.Rtf);
                    NetWorkManager.Instance.sendMessage(Protocol.MESSAGE, -1, MessageProtocol.CHAT, message);
                    Rich_Edit.Rtf = "";
                    break;
                default:
                    Debug.Print("窗口类型错误");
                    break;
            }
        }
        //当编辑的文本发生变化
        private void Rich_Edit_TextChanged(object sender, EventArgs e)
        {
           // Debug.Print("编辑的文本是：" + Rich_Edit.Text + "长度" + Rich_Edit.Text.Length);
           // Debug.Print("编辑的富文本是：" + Rich_Edit.Rtf);
        }

        string noRtfString = "";
        public const string fennu = "/fn";

      
    }
}