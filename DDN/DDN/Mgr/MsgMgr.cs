
using DDN.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace DDN
{

    public class MsgProtocol
    {
        public const int ADD_FRIEND_CREQ = 0;//申请添加好友
        public const int ADD_FRIEND_SRES = 1;//添加好友的响应
        public const int ONE_ADD_YOU_SRES = 2;//有人加你好友
        public const int AGREE_ADD_FRIEND_CREQ = 3;//同意加好友
        public const int AGREE_ADD_FRIEND_SRES = 4;//同意加好友的响应
        public const int ONE_AGREED_YOU = 5;        //别人同意了你的申请
        public const int DELETE_FRIEND_CREQ = 6;//删除好友
        public const int DELETE_FRIEND_SRES = 7;//删除好友的响应
        public const int YOU_BE_DELETED = 8;//你被删除好友了
    }

    public class MsgModel
    {
        public int MsgType;
        public string From;
        public string To;
        public string Content;
        public string Time;

        public MsgModel() { }

        public MsgModel(int type, string from, string to, string content, string time)
        {
            this.MsgType = type;
            this.From = from;
            this.To = to;
            this.Content = content;
            this.Time = time;
        }
    }

    public class MsgMgr
    {
        public List<MsgModel> mList = new List<MsgModel>();
        public MsgMgr()
        {
            //Debug.Print("消息管理器的构造函数！！！！");
            //拉取离线消息
            pullOfflineMsg();
        }

        public void onMessage(SocketModel sm)
        {
            MsgModel mModel = Coding<MsgModel>.decode(sm.Message);
            onNewMessage(mModel);
            if (Manager.Instance.formMain.formMessageVerify!=null && Manager.Instance.formMain.formMessageVerify.IsDisposed==false) {
                Manager.Instance.formMain.formMessageVerify.reFreshSafePost();
            }


        }


        public void onNewMessage(MsgModel mModel)
        {
            //Debug.Print("消息管理器： 收到一小条消息..........."+ mModel.MsgType);
            //Debug.Print("消息管理器： 收到一小条消息..........." + mModel.From);
            //Debug.Print("消息管理器： 收到一小条消息..........." + mModel.To);
            //Debug.Print("消息管理器： 收到一小条消息..........." + mModel.Time);
            switch (mModel.MsgType)
            {
                case MsgProtocol.ADD_FRIEND_SRES://你添加好友的响应,删除那个item就好了
                    Manager.Instance.formMain.FormAddFriend.onMessage(mModel);
                    break;
                case MsgProtocol.ONE_ADD_YOU_SRES://有人添加你
                    Manager.Instance.formMain.notifyIonFlashSafePost();//icon闪烁  
                    foreach (var item in mList)
                    {
                        if (item.From == mModel.From && item.MsgType == MsgProtocol.ONE_ADD_YOU_SRES)
                        {//要判断是否有同样的申请，过滤一下
                            return;
                        }
                    }
                    this.mList.Add(mModel);
                    break;
                case MsgProtocol.AGREE_ADD_FRIEND_SRES://我同意别人的加好友申请的响应，删除mlist ,并添加好友

                    //移除那条申请加我的消息             
                    for (int i = 0; i < mList.Count; i++)
                    {
                        if (mList[i].MsgType == MsgProtocol.ONE_ADD_YOU_SRES && mList[i].From == mModel.To)
                        {
                            mList.RemoveAt(i);
                        }
                    }
                    Manager.Instance.formMain.formMessageVerify.reFreshSafePost();
                    Manager.Instance.formMain.formMessageVerify.showOpreationResultSafePost(mModel.To + "是你的好友了");
                    Manager.Instance.formMain.flowLayoutPanelFriendList.addFriendItemSafePost(mModel.To);

                    break;
                case MsgProtocol.ONE_AGREED_YOU://别人同意了你的申请
                    Manager.Instance.formMain.flowLayoutPanelFriendList.addFriendItemSafePost(mModel.From);//添加好友
                    this.mList.Add(mModel);
                    Manager.Instance.formMain.notifyIonFlashSafePost();//icon闪烁
                    break;
                case MsgProtocol.DELETE_FRIEND_SRES://删除好友的响应，删除好友item及好友列表
                    Manager.Instance.formMain.flowLayoutPanelFriendList.removeFriendItemSafePost(mModel.To);
                    //MessageBox.Show("好友删除完毕。");
                    break;
                case MsgProtocol.YOU_BE_DELETED://你被别人删除好友了,删除item、list、添加消息列表
                    Manager.Instance.formMain.flowLayoutPanelFriendList.removeFriendItemSafePost(mModel.From);
                    this.mList.Add(mModel);
                    Manager.Instance.formMain.notifyIonFlashSafePost();//icon闪烁
                    Debug.Print("收到我被删除的消息" + mModel.MsgType);
                    break;
                default:
                    Debug.Print("未知消息协议类型" + mModel.MsgType);
                    break;
            }
        }

        public void sendMessage(MsgModel m)
        {
            string message = Coding<MsgModel>.encode(m);
            Debug.Print("消息管理器发出的消息是:" + message);
            NetWorkManager.Instance.sendMessage(Protocol.MESSAGE, -1, m.MsgType, message);
        }

        public MsgModel[] offlineMsgArr;
        //拉取离线消息
        void pullOfflineMsg()
        {
            string offlineMsg = HttpReqHelper.request(AppConst.WebUrl + "offlinemsg?protocol=0&username=" + GameInfo.ACC_ID);
            Debug.Print("我的离线消息" + offlineMsg);
            offlineMsgArr = Coding<MsgModel[]>.decode(offlineMsg);
            //告诉服务器可以删除离线消息
            if (offlineMsgArr != null)
            {
                if (offlineMsgArr.Length > 0)
                {
                    clearOfflineMsg();
                }
            }
        }

        void clearOfflineMsg()
        {
            string offlineMsg = HttpReqHelper.request(AppConst.WebUrl + "offlinemsg?protocol=1&username=" + GameInfo.ACC_ID);
            if (offlineMsg == "false")
            {
                clearOfflineMsg();
            }
        }

    }
}
