//using Mgr;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Drawing;
//using Login;
//using System.Threading;
//using MainProgram;

//namespace Mgr
//{
//    public class Manager
//    {
//        private static Manager instance;
//        public static Manager Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    instance = new Manager();
//                }
//                return instance;
//            }
//        }

//        public SynchronizationContext m_SyncContext = null;

//        public void InitApp()
//        {
         
//            Debug.Print("mgr线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            
//         PlayerPrefs.Init();
//         NetWorkManager.Instance.Start();
//         Thread th = new Thread(new ThreadStart(checkNetMsg));
//         th.Start();
//         Login.LoginMgr.Instance.Init();
        
//           // Login.ServerForUnity.ServerForUnity.Instance.Start();
            
//            //if(Login.LoginMgr.Instance.formLogin.DialogResult == DialogResult.OK)
//            //{
//            //  //  Main.MainMgr.Instance.Init();
//            //    Debug.Print("登陆成功3");
//            //}
//            //else
//            //{
//            //    return;
//            //}

//            m_SyncContext = SynchronizationContext.Current;
//            Thread.Sleep(10000);
//        }


//        void checkNetMsg() {
//            while (true)
//            {
//                List<SocketModel> list = NetWorkManager.Instance.getList();

//              //  Debug.Print("消息检查线程");
//                if (list.Count > 0)
//                {
//                    Debug.Print("待处理消息长度是：" + list.Count);
//                    for (int i = 0; i < list.Count; i++)
//                    {
//                        SocketModel model = list[i];
//                        OnMessage(model);

//                    }
//                    list.Clear();
//                }
               
//                Thread.Sleep(1); 
//            }
//        }

//        public void OnMessage( SocketModel model)
//        {
//            switch (model.Type)
//            {
//                case Protocol.LOGIN:
//                  //  Debug.Print("登陆结果是aaaa：" + model.Message);
//                           Login.LoginMgr.Instance.formLogin.OnMessage(model);
//                           if (model.Message == "1&惠佳科技")
//                           {
//                               Debug.Print("登陆成功了啊啊pp");
//                               PlayerPrefs.SetString("username", "qqqqqq");
//                               openMainProgramSafePost();
//                           }
//                    break;
//                case Protocol.MESSAGE://消息相关
//                    MainMgr.Instance.msgMgr.onMessage(model);
//                    break;
//                default:
//                    Debug.Print("网络协议类型错误：" + model.Type, 5);
//                    break;
//            }
//        }


//        public void ExitApp()
//        {
//       //     UnityManager.Instance.CloseUnity(); 
//        }

//        void openMainProgramSafePost() {
//            m_SyncContext.Post(openMainProgram,null);
//        }

//        void openMainProgram(object state) {
//            MainProgram.MainMgr.Instance.Init();
//        }
//    }
//}
