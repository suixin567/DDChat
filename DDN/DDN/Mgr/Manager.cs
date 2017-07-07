using DDN;
using DDN.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DDN
{
    class Manager
    {
        private static Manager instance;
        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }

        public FormLogin formLogin;//登录窗体
        public FormMain formMain;//主窗体
        public MsgMgr msgMgr;//消息管理器



        public void InitApp()
        {
         
            Debug.Print("mgr线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            
            PlayerPrefs.Init();
            NetWorkManager.Instance.Start();
            DDN.ServerForUnity.ServerForUnity.Instance.Start();

            formLogin = new FormLogin();
            formLogin.ShowDialog();
            if (formLogin.DialogResult == DialogResult.OK)
            {
                msgMgr = new MsgMgr();
                formMain = new FormMain();
                Application.Run(formMain);

            }
            else
            {
                return;
            }
        }

        public void ExitApp()
        {
            UnityManager.Instance.CloseUnity();
            Environment.Exit(0);
        }
    
    }
}
