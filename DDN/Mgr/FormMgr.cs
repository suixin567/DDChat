﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mgr
{
    public partial class FormMgr : Form
    {
        public SynchronizationContext m_SyncContext = null;

        public FormMgr()
        {
            InitializeComponent();
        }

        private void FormMgr_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2-50);
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
            
            InitApp();
        }

        public void InitApp()
        {
       
            Debug.Print("mgr线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

            PlayerPrefs.Init();
            NetWorkManager.Instance.Start();
            Thread th = new Thread(new ThreadStart(checkNetMsg));
            th.Start();
            Login.LoginMgr.Instance.Init();
            m_SyncContext = SynchronizationContext.Current;
        }


        void checkNetMsg()
        {
            while (true)
            {
                List<SocketModel> list = NetWorkManager.Instance.getList();

                //  Debug.Print("消息检查线程");
                if (list.Count > 0)
                {
                  //  Debug.Print("待处理消息长度是：" + list.Count);
                    for (int i = 0; i < list.Count; i++)
                    {
                        SocketModel model = list[i];
                        OnMessage(model);

                    }
                    list.Clear();
                }
                Thread.Sleep(1);
            }
        }

        public void OnMessage(SocketModel model)
        {
            switch (model.Type)
            {
                case Protocol.LOGIN:
                    Debug.Print("formMgr---->>>登陆结果是：" + model.Message+"    比对"+ PlayerPrefs.GetString("account"));
                    Login.LoginMgr.Instance.formLogin.OnMessage(model);
                    if (model.Message == PlayerPrefs.GetString("account"))
                    {
                        Debug.Print("登陆成功了");
                        PlayerPrefs.SetString("username", model.Message);
                        openMainProgramSafePost();
                    }
                    break;
                case Protocol.MESSAGE://消息相关
                    MainProgram.MainMgr.Instance.msgMgr.onMessage(model);
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

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormMgr_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }
    }
}