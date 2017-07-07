using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDN.ServerForUnity
{
    class ServerForUnity
    {

        //单例
        private static ServerForUnity instance;
        public static ServerForUnity Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerForUnity();
                }
                return instance;
            }
        }

        private static string ipAddress = "127.0.0.1";
        private static int port = 7898;

        Thread th;

        public void Start()
        {
            th = new Thread(new ThreadStart(startServer));
            th.Start();
        }

        void startServer()
        {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse(ipAddress), port));
            tcpServer.Listen(1);//最大连接数
            Debug.Print("Unity服务器开启");
            while (true)
            {
                clientSocket = tcpServer.Accept();
                Debug.Print("客户端已连接");
                ReceiveMessage();
                // clientSocket = new UnityClient(clientSocket);
            }
        }
        private Socket clientSocket;

        static int maxBufferSize = 1024;
        private byte[] data = new byte[maxBufferSize];//存放客户端发来的数据

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    int length = clientSocket.Receive(data);
                    if (length >= maxBufferSize)
                    {
                        Debug.Print("收到超长数据");
                    }
                    string message = Encoding.UTF8.GetString(data, 0, length);
                    SocketModel model = Coding<SocketModel>.decode(message);
                    onMessage(model);
                }
                catch (Exception)
                {
                    Debug.Print("unity断开");
                    break;
                }

            }
        }

        public void SendMessage(int type, int area, int command, string message)
        {
            SocketModel model = new SocketModel();
            model.Type = type;
            model.Area = area;
            model.Command = command;
            model.Message = message;

            string message2 = Coding<SocketModel>.encode(model);
            byte[] data = Encoding.UTF8.GetBytes(message2);
            clientSocket.Send(data);
        }

        void onMessage(SocketModel model)
        {
            Debug.Print("收到：" + model.Message);
            switch (model.Type)
            {
                case UnityProtocol.SELF_INFO:
                    Debug.Print("unity请求个人信息");
                    if (model.Command ==0) {
                        Debug.Print("编辑器模式");
                        UnityManager.Instance.unityMode = 0;
                    }
                    if (model.Command == 1)
                    {
                        Debug.Print("exe模式");
                        UnityManager.Instance.unityMode = 1;
                        if (UnityManager.Instance.isUnityShow==false) {//还没开启unity，unity就来了
                            SendMessage(UnityProtocol.CLOSE_UNITY,0,0,"");
                        }
                    }
                    //返回个人信息
                    SendMessage(UnityProtocol.SELF_INFO, 0, 0, GameInfo.ACC_ID);
                    break;
                case UnityProtocol.SCENE:
                    Debug.Print("unity请求场景信息");
                  //  if (model.Command == SceneProtocol.INIT)
                  //  {
                      UnityManager.Instance.changeUnityScene(UnityManager.Instance.sceneIndex);
                  //  }
                    break;
                case UnityProtocol.RESOUCE_MODE:
                    SendMessage(UnityProtocol.RESOUCE_MODE, 0, UnityManager.Instance.resourceMode, UnityManager.Instance.currentGroup);
                    break;
                case UnityProtocol.UNITY_QUIT:
                    Debug.Print("unity退出...");
                    UnityManager.Instance.CloseUnity();

                    break;
                default:
                    Debug.Print("未知unity协议...");
                    break;
            }
        }
    }
}
