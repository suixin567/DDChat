
using MainProgram.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace MainProgram
{

    public class MsgProtocol
    {
        public const int FRIEND = 0; //好友相关
        public const int GROUP = 1; //群组相关
        public const int CHAT = 2; //聊天相关

        public const int ADD_FRIEND_CREQ = 10;//申请添加好友
        public const int ADD_FRIEND_SRES = 11;//添加好友的响应
        public const int ONE_ADD_YOU_SRES = 12;//有人加你好友
        public const int AGREE_ADD_FRIEND_CREQ = 13;//同意加好友
        public const int AGREE_ADD_FRIEND_SRES = 14;//同意加好友的响应
        public const int ONE_AGREED_YOU = 15;        //别人同意了你的申请
        public const int DELETE_FRIEND_CREQ = 16;//删除好友
        public const int DELETE_FRIEND_SRES = 17;//删除好友的响应
        public const int YOU_BE_DELETED = 18;//你被删除好友了

        public const int CREATE_GROUP_CREQ = 30; //创建群
        public const int CREATE_GROUP_SRES = 31;//建群的响应
        public const int ADD_GROUP_CREQ = 32;//申请入群
        public const int ADD_GROUP_SRES = 33;//申请响应
        public const int ONE_WANT_ADD_GROUP_SRES = 34;//有人申请入群
        public const int AGREE_ADD_GROUP_CREQ = 35;//群主同意申请入群
        public const int AGREE_ADD_GROUP_SRES = 36;//群主同意申请入群的响应
        public const int YOU_BE_AGREED_ENTER_GROUP = 37;//你被同意入群
        public const int QUIT_GROUP_CREQ = 38;//退出一个群
        public const int QUIT_GROUP_SRES = 39;//退出一个群的响应

        public const int CHAT_ME_TO_FRIEND = 100;
        public const int CHAT_FRIEND_TO_ME = 101;

        public const int CHAT_ME_TO_GROUP = 110;
        public const int CHAT_GROUP_TO_ME = 111;
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
        //需要tip的消息
        public MsgMgr()
        {
            //拉取离线消息
            pullOfflineMsg();
        }

        public void onMessage(SocketModel sm)
        {
            MsgModel mModel = new MsgModel();
            try
            {
                mModel = Coding<MsgModel>.decode(sm.Message);
            }
            catch (Exception e)
            {
                Debug.Print("MsgMgr.onMessage解析错误" + e.ToString());               
            }
            onNewMessage(mModel);
        }


        public void onNewMessage(MsgModel mModel)
        {
            switch (mModel.MsgType)
            {
                case MsgProtocol.ADD_FRIEND_SRES://添加好友的响应  (《《《无需闪烁》》》)
                    MainMgr.Instance.formMain.FormAddFriend.showOpreationResultSafePost("好友申请已经发出，请等待对方处理。");
                    //验证消息窗体加入这条信息         
                    VerifyMsgMgr.Instance.addOneVerifyMsg(mModel);
                    break;
                case MsgProtocol.ONE_ADD_YOU_SRES://有人添加你      (闪烁~~~)      (需要操作。点击同意按钮)       
                                                  //foreach (var item in mList)
                                                  //{
                                                  //    if (item.From == mModel.From && item.MsgType == MsgProtocol.ONE_ADD_YOU_SRES)
                                                  //    {//要判断是否有同样的申请，过滤一下
                                                  //        return;
                                                  //    }
                                                  //}                                                 
                    VerifyMsgMgr.Instance.addOneVerifyMsg(mModel);
                    msgTip(mModel);
                    break;
                case MsgProtocol.AGREE_ADD_FRIEND_SRES://我同意别人的加好友申请的响应，删除mlist ,并添加好友 (《《《无需闪烁》》》)                                             
                    VerifyMsgMgr.Instance.formMessageVerify.showOpreationResultSafePost(mModel.To + "是你的好友了");
                    MainMgr.Instance.formMain.flowLayoutPanelFriendList.addFriendItemSafePost(mModel.To);
                    //把验证消息里的这条消息标记为已处理
                    VerifyMsgMgr.Instance.markProcessed(mModel);
                    break;
                case MsgProtocol.ONE_AGREED_YOU://别人同意了你的申请   (闪烁~~~)  
                    MainMgr.Instance.formMain.flowLayoutPanelFriendList.addFriendItemSafePost(mModel.From);//添加好友
                    msgTip(mModel);
                    break;
                case MsgProtocol.DELETE_FRIEND_SRES://删除好友的响应，删除好友item及好友列表  (《《《无需闪烁》》》)
                    MainMgr.Instance.formMain.flowLayoutPanelFriendList.removeFriendItemSafePost(mModel.To);
                    //MessageBox.Show("好友删除完毕。");
                    break;
                case MsgProtocol.YOU_BE_DELETED://你被别人删除好友了,删除item、list、添加消息列表     (闪烁~~~)  
                    MainMgr.Instance.formMain.flowLayoutPanelFriendList.removeFriendItemSafePost(mModel.From);
                  //  msgTip(mModel);
                    break;


                    ////群组相关
                case MsgProtocol.CREATE_GROUP_SRES://建群的响应       (《《《无需闪烁》》》)
                    MyGroupModel myGroupModel = Coding<MyGroupModel>.decode(mModel.Content);
                    Debug.Print("我新建的群号是：" + myGroupModel.GroupID);
                    MainMgr.Instance.formMain.flowLayoutPanelGroupList.addItemSafePost(myGroupModel);
                    //更新提示文字
                    MainMgr.Instance.formMain.flowLayoutPanelGroupList.formCreateGroup.showOpreationResultSafePost("创建成功！，群号是：" + myGroupModel.GroupID);
                    break;
                case MsgProtocol.ADD_GROUP_SRES://加群的响应 (《《《无需闪烁》》》)
                    Debug.Print("申请加群的响应" + mModel.Content);
                    if (mModel.Content == "too many member")
                    {//群员太多
                        MainMgr.Instance.formMain.FormAddFriend.showOpreationResultSafePost("此群员已满，加入失败！");
                        return;
                    }
                    if (mModel.Content == "申请已经发出，请等待群主审核。")
                    {
                        MainMgr.Instance.formMain.FormAddFriend.showOpreationResultSafePost(mModel.Content);
                        //验证消息窗体加入这条信息         
                        VerifyMsgMgr.Instance.addOneVerifyMsg(mModel);
                        return;
                    }
                    MyGroupModel myAddGroupModel = Coding<MyGroupModel>.decode(mModel.Content);
                    Debug.Print("我加入的群号是：" + myAddGroupModel.GroupID);
                    //增加item
                    MainMgr.Instance.formMain.flowLayoutPanelGroupList.addItemSafePost(myAddGroupModel);
                    //更新提示文字
                    MainMgr.Instance.formMain.FormAddFriend.showOpreationResultSafePost("成功加入！");
                    break;
                case MsgProtocol.ONE_WANT_ADD_GROUP_SRES://有人想申请入群       (闪烁~~~)          (需要操作。点击同意入群按钮)                             
                                                         //foreach (var item in mList)
                                                         //{
                                                         //    if (item.From == mModel.From && item.MsgType == MsgProtocol.ONE_WANT_ADD_GROUP_SRES)
                                                         //    {//要判断是否有同样的申请，过滤一下
                                                         //        return;
                                                         //    }
                                                         //}
                    VerifyMsgMgr.Instance.addOneVerifyMsg(mModel);
                    msgTip(mModel);
                    break;
                case MsgProtocol.AGREE_ADD_GROUP_SRES://群主同意申请入群的响应  (《《《无需闪烁》》》)
                    VerifyMsgMgr.Instance.formMessageVerify.showOpreationResultSafePost(mModel.From + "加入成功！");
                    //把验证消息里的这条消息标记为已处理
                    VerifyMsgMgr.Instance.markAddGroupProcessed(mModel);
                    break;
                case MsgProtocol.YOU_BE_AGREED_ENTER_GROUP://你被同意入群             (闪烁~~~)  
                                                           //  MainMgr.Instance.formMain.notifyIonFlashSafePost();//icon闪烁 
                                                           // this.mList.Add(mModel);
                    msgTip(mModel);
                    //增加item
                    MyGroupModel beAgreedEnterGroupModel = new MyGroupModel();
                    beAgreedEnterGroupModel.GroupID = int.Parse(mModel.To);
                    beAgreedEnterGroupModel.ReceiveModel = 0;
                    MainMgr.Instance.formMain.flowLayoutPanelGroupList.addItemSafePost(beAgreedEnterGroupModel);
                    break;
                case MsgProtocol.QUIT_GROUP_SRES://退群响应  (《《《无需闪烁》》》)
                    MainMgr.Instance.formMain.flowLayoutPanelGroupList.removeItemSafePost(int.Parse(mModel.To));
                    break;
                default:
                    Debug.Print("未知消息协议类型" + mModel.MsgType);
                    break;
            }
        }

        public void sendMessage(int command , MsgModel m)
        {
            string message = Coding<MsgModel>.encode(m);
            Debug.Print("消息管理器发出的消息是:" + message);
            NetWorkManager.Instance.sendMessage(Protocol.MESSAGE, -1, command, message);
        }





        public MsgModel[] offlineMsgArr;
        //拉取离线消息
        void pullOfflineMsg()
        {
           HttpReqHelper.requestSync(AppConst.WebUrl + "offlinemsg?protocol=0&username=" + PlayerPrefs.GetString("username"),delegate(string offlineMsg) {
               Debug.Print("我的离线消息------>>>>>>" + offlineMsg);
               try
               {
                   offlineMsgArr = Coding<MsgModel[]>.decode(offlineMsg);
               }
               catch (Exception e)
               {
                   Debug.Print("MsgMgr.pullOfflineMsg()解析离线消息失败" + e.ToString());
               }

               //告诉服务器可以删除离线消息
               if (offlineMsgArr != null)
               {
                   if (offlineMsgArr.Length > 0)
                   {
                       clearOfflineMsg();
                   }
               }
           });

           
        }

        void clearOfflineMsg()
        {
            HttpReqHelper.requestSync(AppConst.WebUrl + "offlinemsg?protocol=1&username=" + PlayerPrefs.GetString("username"),delegate(string offlineMsg) {
                if (offlineMsg == "false")
                {
                    clearOfflineMsg();
                }
            });           
        }


        void msgTip(MsgModel mode) {
            MainMgr.Instance.msgTip. addNewTip(mode);
        }

    
    }
}
