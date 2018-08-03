using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ToolLib;

namespace Mgr
{
    public partial class FormDDChatMgr : Form
    {
        public SynchronizationContext m_SyncContext = null;

        public FormDDChatMgr()
        {
            InitializeComponent();
        }

        private void FormMgr_Load(object sender, EventArgs e)
        {
            InitApp();
//#if DEBUG
//        this.labelRunMode.Text ="v" + AppConst.APP_VERSION;
//#else
//            this.labelRunMode.Text = "发布版";
//#endif
        }

        public void InitApp()
        {       
           // Debug.Print("mgr线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            PlayerPrefs.Init();
            NetWorkManager.Instance.Start();
            Thread th = new Thread(new ThreadStart(checkNetMsg));

            th.Start();
            Login.LoginMgr.Instance.Init();
            m_SyncContext = SynchronizationContext.Current;
            FaceMgr.Instance.Init();
            
        }


        void checkNetMsg()
        {
            while (true)
            {
                List<SocketModel> list = NetWorkManager.Instance.getList();
                if (list!=null)
                {
                    if (list.Count > 0)
                    {
                        //  Debug.Print("待处理消息长度是：" + list.Count);
                        for (int i = 0; i < list.Count; i++)
                        {
                            SocketModel model = list[i];
                            if (model != null)
                            {
                                OnMessage(model);
                            }
                        }
                    }
                }                
                Thread.Sleep(1);
            }
        }

        public void OnMessage(SocketModel model)
        {
            switch (model.Type)
            {
                case Protocol.LOGIN:                                    
                    Login.LoginMgr.Instance.formLogin.OnMessage(model);
                    //登录成功
                    if (model.Command == LoginProtocol.LOGIN_SRES && model.Message !="10" && model.Message != "11" && model.Message != "12" && model.Message!="")
                    {                      
                        openMainProgramSafePost();
                    }
                    break;
                case Protocol.MESSAGE://消息相关
                    MainProgram.MainMgr.Instance.msgMgr.onMessage(model);
                    break;
                case Protocol.SETTING://有设置被改变
                    if (model.Command==1)//有群模型发生改变
                    {
                        DataMgr.Instance.markGroupInfoInvalid(int.Parse(model.Message));
                    }
                    if (model.Command == 2)//有群头像发生改变
                    {
                        FaceMgr.Instance.faceUpdateFace("group"+model.Message+".jpg");
                    }
                    break;
                default:
                    Debug.Print("网络协议类型错误：" + model.Type, 5);
                    break;
            }
        }

        void openMainProgramSafePost()
        {
            m_SyncContext.Post(openMainProgram, null);
        }

        void openMainProgram(object state)
        {
            MainProgram.MainMgr.Instance.Init();
        }

  

        private void FormMgr_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }
    }
}
