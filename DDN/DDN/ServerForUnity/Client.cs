using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDN.ServerForUnity
{
    class Client
    {
        static int maxBufferSize = 1024;
        private Socket clientSocket;
        Thread t;
        private byte[] data = new byte[maxBufferSize];//存放客户端发来的数据

        public Client(Socket s)
        {
            clientSocket = s;
            //启动线程处理
            t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                //接收消息之前先判断客户端是否断开连接了，如果断开了，就结束此线程
                if (clientSocket.Poll(100, SelectMode.SelectRead))//100毫秒内读不到客户端的消息就是断开了
                {
                    clientSocket.Close();
                    Debug.Print("客户端断开");
                    break;
                }
                int length = clientSocket.Receive(data);
                if (length >= maxBufferSize)
                {
                    Debug.Print("收到超长数据");
                }
                string message = Encoding.UTF8.GetString(data, 0, length);
                Debug.Print("收到：" + message);
                SocketModel model = Coding<SocketModel>.decode(message);
                onMessage(model);              
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

        void onMessage(SocketModel model) {
            Debug.Print("收到：" + model.Message);          
        }
    }
}
