using System;
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
        public Dictionary<int, Form> formGroupDictionary = new Dictionary<int, Form>();
        public Dictionary<int, Form> formFriendDictionary = new Dictionary<int, Form>();
        public Form formSelf = null;
        public Form formShop = null;
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
            Debug.Print("对话管理器加载完毕");
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

        public void openDialog(int dialogType, int id = -1)
        {
            switch (dialogType)
            {
                case 0://请求打开商城
                    UnityManager.Instance.resourceMode = 0;
                   // Debug.Print(formShop.IsDisposed.ToString());

                    if (formShop == null || formShop.IsDisposed==true)
                    {
                        formShop = new FormDialog(dialogType, id);
                        setParent(formShop);
                        formShop.Show();
                        childFromAmount++;
                    }
                    else {//已经打开商城
                        UnityManager.Instance.changeUnityScene(4);
                        Debug.Print("尚城已经打开了");
                    }
                    break;
                case 1://请求打开群
                    UnityManager.Instance.resourceMode = 1;
                    if (formGroupDictionary.ContainsKey(id) == false)
                    {
                        FormDialog formGroup = new FormDialog(dialogType, id);
                        formGroup.Show();
                        formGroupDictionary.Add(id, formGroup);
                    }
                    break;
                case 2://请求打开个人
                    UnityManager.Instance.resourceMode = 2;
                    if (formSelf == null)
                    {
                        formSelf = new FormDialog(dialogType, id);
                        setParent(formSelf);
                        formSelf.Show();
                        childFromAmount++;
                    }
                    else {//已经打开个人
                        UnityManager.Instance.changeUnityScene(4);
                    }
                    break;
                case 3://请求打开朋友
                    UnityManager.Instance.resourceMode = 3;
                    if (formFriendDictionary.ContainsKey(id) == false)
                    {
                        FormDialog formFriend = new FormDialog(dialogType, id);
                        formFriend.Show();
                        formFriendDictionary.Add(id, formFriend);
                    }
                    break;
            }        
        }


        void onUnityCanRunEvent(bool result) {
            if (result) {
                //打开Unity
                findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");
                Debug.Print("准备打开Unity客户端哈：" + exe);
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
            if (childFromAmount == 0)
            {
                child.Location = new Point(this.panelTab.Width+2, this.panelTop.Height+2);
                child.Size = new Size(this.Width - this.panelTab.Width-5, this.Height-this.panelTop.Height-5);
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
    

        private void FormDialogManager_FormClosing(object sender, FormClosingEventArgs e)
        {
         
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
    }
}
