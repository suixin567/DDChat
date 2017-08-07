﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityModule;


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
        static string exe = "";
        public int childFromAmount = 0;
        #endregion


        public FormDialogManager()
        {
            InitializeComponent();
            this.Show();
        }

        private void FormDialogManager_Load(object sender, EventArgs e)
        {
            this.Size = new Size(System.Windows.Forms.SystemInformation.WorkingArea.Width / 3, System.Windows.Forms.SystemInformation.WorkingArea.Height / 2);
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            UnityManager.Instance.updateUnityEvent += this.onUnityCanRunEvent;
            UnityManager.Instance.checkUpdate();
        }

        static void findExe(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹  
                {
                    findExe(fsinfo.FullName);//递归调用  
                }
                else
                {
                    if (fsinfo.FullName.EndsWith(".exe"))
                    {
                        exe = fsinfo.FullName;
                        return;
                    }
                }
            }
        }

        //dialogType 资源类型
        //dialogName 表示群的名字 或者好友名字
        //dialogId 表示群号 或者好友的id
        public void openDialog(int dialogType,  int dialogId = -1, string dialogName="",Image face=null)
        {
            switch (dialogType)
            {
                case 0://请求打开商城
                    if (formListDictionary.ContainsKey("shop") == false)
                    {
                        FormDialog formShop = new FormDialog(dialogType, -1, "商城",face);
                        formShop.BackColor = Color.Red;
                        setParent(formShop);                        
                        childFromAmount++;
                        formListDictionary.Add("shop",formShop);
                        //创建选项卡
                        ButtonTab btnTab = new ButtonTab(0,"shop", "商城", null);
                        this.flowLayoutPanelTab.Controls.Add(btnTab);
                    }
                    changeActiveWindow("shop");            
                    break;
                case 1://请求打开群

                    if (formListDictionary.ContainsKey("group"+dialogId) == false)
                    {
                        FormDialog formGroup = new FormDialog(dialogType, dialogId, dialogName, face);
                        setParent(formGroup);
                        childFromAmount++;
                        formListDictionary.Add("group" + dialogId, formGroup);
                        //创建选项卡
                        ButtonTab btnTab1 = new ButtonTab(1,"group" + dialogId, dialogName, face);
                        this.flowLayoutPanelTab.Controls.Add(btnTab1);                        
                    }
                    changeActiveWindow("group" + dialogId);
                    break;
                case 2://请求打开个人
                    if (formListDictionary.ContainsKey("self")==false)
                    {
                        FormDialog formSelf = new FormDialog(dialogType, -1, "我的", face);
                        setParent(formSelf);
                        childFromAmount++;
                        formListDictionary.Add("self", formSelf);
                        //创建选项卡
                        ButtonTab btnTab2 = new ButtonTab(2,"self", "我的", null);
                        this.flowLayoutPanelTab.Controls.Add(btnTab2);
                    }
                    changeActiveWindow("self");
                    break;
                //case 3://请求打开朋友
                //    UnityManager.Instance.resourceMode = 3;
                //    if (formFriendDictionary.ContainsKey(id) == false)
                //    {
                //        FormDialog formFriend = new FormDialog(dialogType, id);
                //        formFriend.Show();
                //        formFriendDictionary.Add(id, formFriend);
                //    }
                //    break;
            }        
        }

        void createDialogWindow() {

        }


        void onUnityCanRunEvent(bool result) {
            if (result) {
                //打开Unity
                findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");
                if (exe == "")
                {
                    MessageBox.Show("3D展示模块不存在！\n请先下载3D模块。", "叮叮鸟提示：");
                    this.Dispose();
                }
                else
                {
                    appContainer.AppFilename = exe;
                    appContainer.Start();
                }
            }
        }

        public void setParent(Form child)
        {
            child.TopLevel = false;
            child.Parent = this;
            child.Location = new Point(this.flowLayoutPanelTab.Width+2, this.panelTop.Height+2);
            child.Size = new Size(this.Width - this.flowLayoutPanelTab.Width-5, this.Height-this.panelTop.Height-5);
            child.Show();
        }

        //设置激活窗体
        public void changeActiveWindow(string activeId) {
            foreach (var item in formListDictionary)
            {
                if (item.Key == activeId)
                {
                    item.Value.Show();
                }
                else {
                    item.Value.Hide();
                }
            }
            foreach (var item in flowLayoutPanelTab.Controls)
            {
                ButtonTab btnTab = (ButtonTab)item;
                if (btnTab.m_id == activeId)
                {
                    btnTab.BackColor = Color.Violet;
                    //切换Unity场景
                    if (btnTab.m_dialogType==0)
                    {
                        UnityManager.Instance.resourceMode = 0;
                        UnityManager.Instance.changeUnityScene(4);
                    }
                    if (btnTab.m_dialogType == 1)
                    {
                        UnityManager.Instance.currentGroup = btnTab.m_dialogTitle;
                        UnityManager.Instance.resourceMode = 1;
                        UnityManager.Instance.changeUnityScene(4);
                    }
                    if (btnTab.m_dialogType == 2)
                    {
                        UnityManager.Instance.resourceMode = 2;
                        UnityManager.Instance.changeUnityScene(4);
                    }
                }
                else {
                    btnTab.BackColor = Color.White;
                }                
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
                case 0x0201: //鼠标左键按下的消息
                    m.Msg = 0x00A1; //更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero; //默认值
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }


        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }    

 

        public void AppExitEvent() {
            buttonClose_Click(null,null);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (this.appContainer.AppProcess != null)
            {
                this.appContainer.AppProcess.Close();
            }
            UnityManager.Instance.updateUnityEvent -= this.onUnityCanRunEvent;
            instance = null;
            this.Close();
            this.Dispose();
        }

        private void flowLayoutPanelTab_Paint(object sender, PaintEventArgs e)
        {
            Debug.Print(this.flowLayoutPanelTab.Controls.Count.ToString());
        }
    }
}