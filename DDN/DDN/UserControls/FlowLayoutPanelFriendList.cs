using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DDN.Tools;
using System.Threading;

namespace DDN.UserControls
{
    public partial class FlowLayoutPanelFriendList : UserControl
    {
        public SynchronizationContext m_SyncContext = null;
        private int friendAmount = 0;//好友个数                       

        public FlowLayoutPanelFriendList()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void FlowLayoutPanelFriendList_Load(object sender, EventArgs e)
        {
            //拉取好友列表
            pullFriendList();
        }

        void pullFriendList()
        {
            string pullFriendList = HttpReqHelper.request(AppConst.WebUrl + "friendList?username=" + GameInfo.ACC_ID);
            Debug.Print("我的好友列表" + pullFriendList);
            string[] friendArr = pullFriendList.Split(',');
            foreach (var friend in friendArr)
            {
                if (friend != "")
                {
                    addFriendItemSafePost(friend);
                }
            }
        }


        //添加好友item
        public void addFriendItemSafePost(string friendUsername)
        {
            m_SyncContext.Post(addFriendItem, friendUsername);
        }
        void addFriendItem(object state)
        {
            //添加好友item
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is FriendItem)
                {
                    var oldItem = (FriendItem)item;
                    if (oldItem.FriendUsername == state.ToString())
                    {//已经存在这个好友的item
                        Debug.Print("已经存在这个好友的item，这不该发生");
                        return;
                    }
                }
            }
            FriendItem friendItem = new FriendItem(state.ToString());
            if (friendItem != null && friendItem.IsDisposed == false)
            {
                this.flowLayoutPanel.Controls.Add(friendItem);
                friendAmount++;
                this.labelTitle.Text = "好友 " + friendAmount;
            }

        }

        //删除好友item
        public void removeFriendItemSafePost(string username)
        {
            m_SyncContext.Post(removeFriendItem, username);
        }
        void removeFriendItem(object usreName)
        {
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is FriendItem)
                {
                    var friendItem = (FriendItem)item;
                    if (friendItem.FriendUsername == usreName.ToString())
                    {
                        friendItem.Dispose();
                        friendAmount--;
                        this.labelTitle.Text = "好友 " + friendAmount;
                        break;
                    }
                }
            }
        }
        //获取好友列表
        public List<string> getFriendList()
        {
            List<string> friendList = new List<string>();
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is FriendItem)
                {
                    var friendItem = (FriendItem)item;
                    friendList.Add(friendItem.FriendUsername);
                }
            }
            return friendList;
        }
    }
}
