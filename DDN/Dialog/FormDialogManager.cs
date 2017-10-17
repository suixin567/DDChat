using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ToolLib;
//using UnityModule;


namespace Dialog
{
    public partial class FormDialogManager : Form
    {

        #region 单例
        private static FormDialogManager instance;
        public static FormDialogManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormDialogManager();
                }
                return instance;
            }
        }
        #endregion


        #region 属性
        public Dictionary<string, FormDialog> formListDictionary = new Dictionary<string, FormDialog>();

        public const int topHeight = 50;
        public const int leftPanelMaxWidth = 150;
        public FormDialog activeDialog = null;//激活对话窗
        public SynchronizationContext m_SyncContext = null;
        #endregion


        public FormDialogManager()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            
        }


        private void FormDialogManager_Load(object sender, EventArgs e)
        {
            this.Size = new Size(System.Windows.Forms.SystemInformation.WorkingArea.Width / 3, System.Windows.Forms.SystemInformation.WorkingArea.Height / 2);
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            //GraphicsPath path = new GraphicsPath();
            //path.AddArc(pictureBoxFace.DisplayRectangle, 0, 360);
            //pictureBoxFace.Region = new Region(path);
            //this.appContainer.Hide();
       
            //Thread th = new Thread(new ThreadStart(() =>
            //{
            //    m_SyncContext.Post(checkUnitySafePost, null);
            //}));
            //th.Start();
        }

        //void checkUnitySafePost(object state) {
        //    //UnityManager.Instance.checkUpdate(this.Handle);      //这句可以线程内执行。  
        //}

        //void onUnityOpened() {
        //    this.appContainer.UnityOpendSafePost();
        //}
    

        //dialogType 资源类型
        //dialogName 表示群的名字 或者好友名字
        //dialogId 表示群号 或者好友的id
        public void openDialog(int dialogType, int dialogId = -1, string dialogName = "", Image face = null)
        {
            if (NetWorkManager.Instance.IsConnected == false)
            {
                MessageBox.Show("没有网络，请联网后重试","叮叮鸟提示：");
                return;
            }        
            switch (dialogType)
            {
                case 0://请求打开商城
                    if (formListDictionary.ContainsKey("shop") == false)
                    {
                        FormDialog formShop = new FormDialog(dialogType, -1, "商城", face);
                        setParent(formShop);
                        formListDictionary.Add("shop", formShop);
                        //创建选项卡
                        ButtonTab btnTab = new ButtonTab(0, "shop", "商城", null);
                        this.flowLayoutPanelTab.Controls.Add(btnTab);
                    }
                    changeActiveWindow("shop");
                    break;
                case 1://请求打开群
                       //确认在群中
                    DataMgr.Instance.getGroupByID(dialogId, delegate (GroupInfoModel mode) {
                        if (mode.Member.Contains(AppInfo.PERSONAL_INFO.Username) || mode.Master.Contains(AppInfo.PERSONAL_INFO.Username) || mode.Manager.Contains(AppInfo.PERSONAL_INFO.Username))
                        {
                            //打开群对话
                            if (formListDictionary.ContainsKey("group" + dialogId) == false)
                            {
                                FormDialog formGroup = new FormDialog(dialogType, dialogId, dialogName, face);
                                setParent(formGroup);
                                formListDictionary.Add("group" + dialogId, formGroup);
                                //创建选项卡
                                ButtonTab btnTab1 = new ButtonTab(1, "group" + dialogId, dialogName, face);
                                this.flowLayoutPanelTab.Controls.Add(btnTab1);
                            }
                            changeActiveWindow("group" + dialogId);
                        }
                        else {
                            //DialogResult dr = MessageBox.Show("已经不在这个群中","提示：");
                            //if (dr == DialogResult.OK)
                            //{
                            //    Debug.Print("怎么还不停止呢");
                            //    return;
                            //}
                            return;
                        }
                    });                                  
                    break;
                case 2://请求打开个人
                    if (formListDictionary.ContainsKey("self") == false)
                    {
                        FormDialog formSelf = new FormDialog(dialogType, -1, "我的", face);
                        setParent(formSelf);
                        formListDictionary.Add("self", formSelf);
                        //创建选项卡
                        ButtonTab btnTab2 = new ButtonTab(2, "self", "我的", face);
                        this.flowLayoutPanelTab.Controls.Add(btnTab2);
                    }
                    changeActiveWindow("self");
                    break;
                case 3://请求打开朋友
                       //确定拥有这个好友                     
                    if (AppInfo.MyFriendList.Contains(dialogId.ToString()))
                    {
                        if (formListDictionary.ContainsKey("friend" + dialogId) == false)
                        {
                            FormDialog formFriend = new FormDialog(dialogType, dialogId, dialogName, face);
                            setParent(formFriend);
                            formListDictionary.Add("friend" + dialogId, formFriend);
                            //创建选项卡
                            ButtonTab btnTab1 = new ButtonTab(3, "friend" + dialogId, dialogName, face);
                            this.flowLayoutPanelTab.Controls.Add(btnTab1);
                        }
                        changeActiveWindow("friend" + dialogId);
                    }
                    else {
                       // MessageBox.Show("对方已不是你的好友！", "提示：");
                        return;
                    }
                    break;
                default:
                    Debug.Print("错误的窗口类型！");
                    break;
            }
            this.Show();
            this.WindowState = FormWindowState.Normal;
            Debug.Print("hais是展示了！");
        }

        //unity更新完毕
        //void onUnityCanRunEvent(bool result)
        //{
        //    if (result)
        //    {
        //        //打开Unity
        //        findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");
        //        if (exe == "")
        //        {
        //            MessageBox.Show("3D展示模块不存在！\n请先下载3D模块。", "叮叮鸟提示：");
        //            this.Dispose();
        //        }
        //        else
        //        {
        //            if (UnityManager.Instance.unityMode != 0)
        //            {
        //                openUnitySafePost();
        //            }
  
        //        }
        //    }
        //}


        //public void openUnitySafePost()
        //{
        //    m_SyncContext.Post(openUnity, null);
        //}
        //void openUnity(object state)
        //{
        //    appContainer.AppFilename = exe;
        //    appContainer.Start();
        //}




        public void setParent(FormDialog child)
        {
            child.TopLevel = false;
            this.splitContainer.Panel2.Controls.Add(child);
            child.Location = new Point(0, topHeight);
            child.Size = this.splitContainer.Panel2.Size;
            
            activeDialog = child;
          //  child.TopLevel = false;
          //  child.Parent = this;
            
        //    child.Size = new Size(this.Width - this.flowLayoutPanelTab.Width - 5, this.Height - topHeight - 3);
            child.Show();
            Debug.Print("服务提示" + child.Parent);
            Debug.Print("服务提示" + child.Location.X);
        }

        //设置激活窗体
        public void changeActiveWindow(string activeId)
        {
            this.Activate();
            //窗体切换
            foreach (var item in formListDictionary)
            {
                if (item.Key == activeId)
                {
                    item.Value.Show();
                    activeDialog = item.Value;
                }
                else
                {
                    item.Value.Hide();
                }
            }
            //选项卡切换
            foreach (var item in flowLayoutPanelTab.Controls)
            {
                ButtonTab btnTab = (ButtonTab)item;
                if (btnTab.m_id == activeId)
                {
                    btnTab.BackColor = btnTab.oriColor;
                    //顶部信息切换
                    //if (btnTab.m_face != null)
                    //{
                    //    this.pictureBoxFace.Image = btnTab.m_face;
                    //}
                    this.labelTitle.Text = btnTab.m_dialogTitle;
                }
                else
                {
                    btnTab.BackColor = Color.SteelBlue;
                }
            }
        }

        //关闭一个对话窗体
        public void closeDialogueWindow(string windowId)
        {
            this.Activate();
            //销毁窗体
            foreach (var item in formListDictionary)
            {
                if (item.Key == windowId)
                {
                    item.Value.Close();
                    item.Value.Dispose();
                    //  activeDialog = item.Value;//设置激活对话
                   // Debug.Print("关闭这个对话" + windowId);
                    formListDictionary.Remove(windowId);                  
                    break;
                }
            }
            foreach (var item in this.flowLayoutPanelTab.Controls)
            {
                ButtonTab btn = (ButtonTab)item;
                if (btn.m_id == windowId)
                {
                    btn.Dispose();
                    //设置一个新的激活窗体
                    if (flowLayoutPanelTab.Controls.Count > 0)
                    {
                        string nextActiveId = ((ButtonTab)flowLayoutPanelTab.Controls[flowLayoutPanelTab.Controls.Count - 1]).m_id;
                        changeActiveWindow(nextActiveId);
                    }
                    else
                    {
                        buttonClose_Click(null, null);
                    }
                    break;
                }
            }
        }


        //把一条消息放在相应的对话窗口里
        public void onChatMsg(MsgModel mm) {

            switch (mm.MsgType)
            {
                case MessageProtocol.CHAT_ME_TO_FRIEND_SRES:
                    foreach (var item in formListDictionary)
                    {
                        if (item.Key == "friend" + mm.To)//自己发出去的消息
                        {
                            item.Value.showOnePopSafePost(mm);
                            return;
                        }
                    }
                    break;
                case MessageProtocol.CHAT_FRIEND_TO_ME_SRES://朋友发来的消息
                    if (formListDictionary.ContainsKey("friend" + mm.From))
                    {
                        formListDictionary["friend" + mm.From].showOnePopSafePost(mm);
                    }
                    else {
                        Debug.Print("发生错误：收到朋友和我聊天，却找不到这个人的对话窗体。");
                    }
                    break;
                case MessageProtocol.CHAT_GROUP_TO_ME_SRES://收到群聊                  
                    if (formListDictionary.ContainsKey("group" + mm.To))
                    {
                        formListDictionary["group" + mm.To].showOnePopSafePost(mm);
                    }
                    else {
                        Debug.Print("发生错误：收到群聊，却找不到这个群的对话窗体。");
                    }
                    break;
                default:
                    Debug.Print("聊天协议错误");
                    break;
            }
       
        }



        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                    (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                //case 0x0201: //鼠标左键按下的消息
                //    m.Msg = 0x00A1; //更改消息为非客户区按下鼠标
                //    m.LParam = IntPtr.Zero; //默认值
                //    m.WParam = new IntPtr(2);//鼠标放在标题栏内
                //    base.WndProc(ref m);
                //    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }


        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //最大化
        bool isMaxSize = false;
        Size nnormalSize = new Size();
        Point normalPoint = new Point();
        private void buttonMax_Click(object sender, EventArgs e)
        {
            isMaxSize = !isMaxSize;
            if (isMaxSize)//变最大
            {
                //记录之前的大小
                normalPoint = this.Location;
                nnormalSize = this.Size;
                this.Size = new Size(System.Windows.Forms.SystemInformation.WorkingArea.Width, System.Windows.Forms.SystemInformation.WorkingArea.Height);
                this.StartPosition = FormStartPosition.Manual;
                this.Location = (Point)new Size(0, 0);
            }
            else {
                // this.WindowState = FormWindowState.Normal;   
                this.Location = normalPoint;
                this.Size = nnormalSize;
            }    
        }


        public void AppExitEvent()
        {
            buttonClose_Click(null, null);
        }

        //关闭对话框
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //if (this.appContainer.AppProcess != null)
            //{
            //    this.appContainer.Stop();
            //}
         //   UnityManager.Instance.updateUnityEvent -= this.onUnityCanRunEvent;
            instance = null;
            this.Close();
            this.Dispose();
        }

        //查看某个窗体是否已经打开，需要遍历朋友聊天窗体，和群聊天窗体。
        public bool isDialogOpend(string friendOrGroupID) {
            foreach (var item in formListDictionary)
            {
                if (item.Key == friendOrGroupID)
                {
                    return true;
                }
            }
            return false;
        }


        private void splitContainer_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            splitContainer.Panel2MinSize = splitContainer.Size.Width - leftPanelMaxWidth;
        }
        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer.Panel2MinSize = 1;
        }


        /// ///////////////////////////////////////////////
        /// 工具方法
        /// ///////////////////////////////////////////////
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormDialogManager_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


    }
}
