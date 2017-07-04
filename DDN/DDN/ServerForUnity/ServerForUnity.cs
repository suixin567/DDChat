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

        void startServer() {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse(ipAddress), port));
            tcpServer.Listen(1);//最大连接数
            Debug.Print("Unity服务器开启");
            while (true)
            {
                Socket clientSocket = tcpServer.Accept();
                Debug.Print("客户端已连接");
                Client client = new Client(clientSocket);
            }
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="message"></param>
        public static void BroadCast(string message)
        {
          //  var disConnectedClient = new List<Client>();//断开连接的客户端
            //foreach (var client in clientList)
            //{
            //    if (client.Connected)
            //        client.SendMessage(message);
            //  //  else//计入断开连接的集合
            //   //     disConnectedClient.Add(client);
            //}

            //foreach (var temp in disConnectedClient)
            //{
            //    clientList.Remove(temp);
            //}

        }
    }
}
