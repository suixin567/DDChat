using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ToolLib;

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

        List<object> popCache = new List<object>();//气泡缓存
        object locker = new object();
        #endregion



        public FormDialog(int type , int dialogId, string dialogName, Image face)
        {
            InitializeComponent();
            #region 颜色
            this.BackColor = Color.FromArgb(AppConst.panelColor.R + 10, AppConst.panelColor.G + 10, AppConst.panelColor.B + 10);
            this.panelRight.BackColor = this.BackColor;
            this.groupMemberPanel1.BackColor = this.BackColor;
            this.panelTakeEdit.BackColor = this.BackColor;
            #endregion

            m_SyncContext = SynchronizationContext.Current;
            m_dialogType = type;
            m_groupOrFriendId = dialogId;
            m_title = dialogName;
            m_face = face;
            Fmx = FormDialogManager.Instance.Left;
            Fmy = FormDialogManager.Instance.Top;

            Thread showPopTh = new Thread(showOnePop);
            showPopTh.Start();
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
                    this.groupMemberPanel1.refreshMembers(m_groupOrFriendId.ToString());
                    break;
                case 2://个人
                    this.labelChat.Dispose();
                    break;
                case 3://朋友     
                    this.groupMemberPanel1.Hide();
                    this.pictureBoxAd.Size = new Size(pictureBoxAd.Size.Width, pictureBoxAd.Size.Height*2);
                    break;
                default:
                    break;
            }
            
            //信息编辑框属性
            Rich_Edit.BorderStyle = BorderStyle.None;
            Rich_Edit.ScrollBars = RichTextBoxScrollBars.None;
          //  Rich_Edit.KeyUp += new KeyEventHandler(RichEdit_KeyUp);
            Rich_Edit.TextChanged += new EventHandler(RichEdit_TextChanged);
            labelTip.Text = "";
            SetLineSpace(richTextBoxChat, 300);
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
                this.Size = new Size(FormDialogManager.Instance.splitContainer.Panel2.Width, Parent.Height - 50);
            }
            //switch (m_dialogType)
            //    {
            //        case 0:
            //            if (this.Size.Width > 300 && this.Size.Height > 200)
            //            {
            //            //    FormDialogManager.Instance.appContainer.Size = this.Size;
            //            }
            //            break;
            //        case 1://群
            //            if (this.Size.Width > 300 && this.Size.Height > 200)
            //            {
            //            //    FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
            //            }
            //            break;
            //        case 2:
            //            if (this.Size.Width > 300 && this.Size.Height > 200)
            //            {
            //              //  FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
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
                  //  FormDialogManager.Instance.appContainer.Show();
                 //   FormDialogManager.Instance.appContainer.Location = this.Location;
                    //UnityManager.Instance.resourceMode = 0;
                    //UnityManager.Instance.changeUnityScene(4);
                    break;
                case 1:
                  //  FormDialogManager.Instance.appContainer.Hide();
                    //UnityManager.Instance.currentGroup = m_title;
                    //UnityManager.Instance.resourceMode = 1;
                    if (UIState == 0)//资源
                    {
                   //     FormDialogManager.Instance.appContainer.Show();
                   //     FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                 //       UnityManager.Instance.changeUnityScene(4);
                    }
                    else if (UIState == 1)//聊天
                    {
                        this.panelChat.Show();
                    //    FormDialogManager.Instance.appContainer.Hide();
                    }
                    else//绘制
                    {
                      //  FormDialogManager.Instance.appContainer.Show();
                      //  FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                  //      UnityManager.Instance.changeUnityScene(3);
                    }
                    break;
                case 2://个人
                    this.panelChat.Hide();
                 //   UnityManager.Instance.resourceMode = 2;
                  //  FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                 //   FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
                 //   FormDialogManager.Instance.appContainer.Show();
                 //   UnityManager.Instance.changeUnityScene(4);
                    break;
                case 3://朋友
                    this.panelChat.Show();
                  //  FormDialogManager.Instance.appContainer.Hide();
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
            labelChat.BackColor = Color.White;
            UIState = 1;
            panelChat.Show();
         //   FormDialogManager.Instance.appContainer.Hide();
        }
       // //资源选项卡
       // private void labelRes_Click(object sender, EventArgs e)
       // {
       //     foreach (var item in flowLayoutPanelTop.Controls)
       //     {
       //         ((Label)item).BackColor = Color.Transparent;
       //     }
       //  /   labelRes.BackColor = Color.SteelBlue;
       //     UIState = 0;
       //     panelChat.Hide();
       //  //   UnityManager.Instance.changeUnityScene(4);
       //  //   FormDialogManager.Instance.appContainer.Show();
       //  //   FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
       //  //   FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
       // }

       // //画房子选项卡
       // private void labelDraw_Click(object sender, EventArgs e)
       // {
       //     foreach (var item in flowLayoutPanelTop.Controls)
       //     {
       //         ((Label)item).BackColor = Color.Transparent;
       //     }
       //     labelDraw.BackColor = Color.SteelBlue;
       //     UIState = 2;
       //     panelChat.Hide();
       ////     UnityManager.Instance.changeUnityScene(3);
       //  //   FormDialogManager.Instance.appContainer.Show();
       //  //   FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
       //  //   FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
       // }


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
   

        public void catcheOnePop(object content)
        {
            lock (locker) {
                popCache.Add(content);
           //     Debug.Print("添加一个气泡缓存");
            }
        }

        void showOnePop()
        {

            while (true)
            {
                lock (locker)
                {
                    if (popCache.Count > 0)
                    {
                        MsgModel mm = (MsgModel)popCache[0];
                   //     Debug.Print("展示做泡泡：" + mm.Content);
                        //获取发言人的昵称
                        DataMgr.Instance.getPersonalByID(mm.From, delegate (PersonalInfoModel personalInfoModel)
                        {
                            appendTitleSafePost(personalInfoModel.Nickname + "(" + mm.From + ")" + " " + mm.Time + "\n");
                            //具体内容               
                            appendContentSafePost(mm.Content + "\n");
                        });
                        popCache.RemoveAt(0);
                    }
                }
                Thread.Sleep(10);
            }
        }

        //显示消息头
        void appendTitleSafePost(string title)
        {
            m_SyncContext.Post(appendTitle, title);
        }
        void appendTitle(object content) {
            string fromName = ((string)content);
            int a = fromName.IndexOf("(");
            int b = fromName.LastIndexOf(")");
            fromName = fromName.Substring(a+1,b-a-1);           
            if (fromName == AppInfo.PERSONAL_INFO.Username)//自己发出去的
            {
                this.richTextBoxChat.SelectionColor = Color.Green;
            }
            else
            {
                this.richTextBoxChat.SelectionColor = Color.Blue;
            }
            this.richTextBoxChat.AppendText((string)content);
        }
        //显示消息体
        void appendContentSafePost(string content)
        {
            m_SyncContext.Post(appendContent, content);
        }
        void appendContent(object content)
        {
            this.richTextBoxChat.SelectionColor = Color.Black;
            this.richTextBoxChat.AppendText((string)content);
            //设置滚动条位置
            this.richTextBoxChat.ScrollToCaret();
        }






        //发送按钮
        private void buttonSend_Click(object sender, EventArgs e)
        {
            //   if (Rich_Edit.Rtf.Length > AppConst.maxReceiveSize)
            if (Rich_Edit.Text.Length > AppConst.maxReceiveSize)
            {
                Debug.Print("发送的消息过长！！！" + AppConst.maxReceiveSize);
                labelTip.Text = "发送的消息太长了";
                System.Windows.Forms.Timer disPlayLabelTipTimer = new System.Windows.Forms.Timer();
                disPlayLabelTipTimer.Interval = 3000;
                disPlayLabelTipTimer.Enabled = true;
                disPlayLabelTipTimer.Tick += new EventHandler((send, ev) =>
                {
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
                 //   MsgModel groupMm = new MsgModel(MessageProtocol.CHAT_ME_TO_GROUP_CREQ, AppInfo.USER_NAME, m_groupOrFriendId.ToString(), Rich_Edit.Rtf, DateTime.Now.ToString());
                    MsgModel groupMm = new MsgModel(MessageProtocol.CHAT_ME_TO_GROUP_CREQ, AppInfo.USER_NAME, m_groupOrFriendId.ToString(), Rich_Edit.Text, DateTime.Now.ToString());
                    string groupMessage = Coding<MsgModel>.encode(groupMm);
                    Debug.Print("发出的聊天消息是:" + Rich_Edit.Text);
                    NetWorkManager.Instance.sendMessage(Protocol.MESSAGE, -1, MessageProtocol.CHAT, groupMessage);
                    Rich_Edit.Rtf = "";
                    break;
                case 3://和朋友聊天              
                  //  MsgModel mm = new MsgModel(MessageProtocol.CHAT_ME_TO_FRIEND_CREQ, AppInfo.USER_NAME, m_groupOrFriendId.ToString(), Rich_Edit.Rtf, DateTime.Now.ToString());
                    MsgModel mm = new MsgModel(MessageProtocol.CHAT_ME_TO_FRIEND_CREQ, AppInfo.USER_NAME, m_groupOrFriendId.ToString(), Rich_Edit.Text, DateTime.Now.ToString());
                    string message = Coding<MsgModel>.encode(mm);
                    Debug.Print("发出的聊天消息是:" + Rich_Edit.Text);
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


        public const int WM_USER = 0x0400;
        public const int EM_GETPARAFORMAT = WM_USER + 61;
        public const int EM_SETPARAFORMAT = WM_USER + 71;
        public const long MAX_TAB_STOPS = 32;
        public const uint PFM_LINESPACING = 0x00000100;
        [StructLayout(LayoutKind.Sequential)]
        private struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }

        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT2 lParam);

        /// <summary>
        /// 设置行距
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <param name="dyLineSpacing">间距</param>
        public static void SetLineSpace(Control ctl, int dyLineSpacing)
        {
            PARAFORMAT2 fmt = new PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.bLineSpacingRule = 4;// bLineSpacingRule;
            fmt.dyLineSpacing = dyLineSpacing;
            fmt.dwMask = PFM_LINESPACING;
            try
            {
                SendMessage(new HandleRef(ctl, ctl.Handle), EM_SETPARAFORMAT, 0, ref fmt);
            }
            catch
            {
            }
        }
    }
}