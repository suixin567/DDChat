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
using System.Threading;
using Mgr;
using UnityModule;
using Dialog;

namespace MainProgram.UserControls
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

        public void InitSelfInfoSafePost(PersonalInfoModel model)
        {
            m_SyncContext.Post(InitSelfInfo, model.Nickname);
        }

        public void InitSelfInfo(object state) {
            this.labelSelf.Text = state.ToString()+ " (自己)";
        }

        public void InitSelfFace(Image face)
        {
            this.pictureBoxSelfFace.Image = face;        
        }

        void pullFriendList()
        {
             HttpReqHelper.requestSync(AppConst.WebUrl + "friendList?username=" + PlayerPrefs.GetString("username") , delegate(string pullFriendList) {
                 Debug.Print("我的好友列表------>>>>>>" + pullFriendList);
                 string[] friendArr = pullFriendList.Split(',');
                 foreach (var friend in friendArr)
                 {
                     if (friend != "")
                     {
                         addFriendItemSafePost(friend);
                     }
                 }
             });
           
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
                this.buttonFriend.Text = "好友 " + friendAmount;
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
                        //关闭对话窗体
                        Dialog.FormDialogManager.Instance.closeDialogueWindow("friend" + friendItem.FriendUsername);
                        friendItem.Dispose();
                        friendAmount--;
                        this.buttonFriend.Text = "好友 " + friendAmount;                                                
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

        bool isFirendExpend = true;
        //好友展开与折叠
        private void buttonFriend_Click(object sender, EventArgs e)
        {
            isFirendExpend = !isFirendExpend;
            if (isFirendExpend)//展开时
            {
                this.buttonFriend.Image = MainProgram.Properties.Resources._3_1;
                this.panelSelf.Show();
                foreach (var item in this.flowLayoutPanel.Controls)
                {
                    if (item is FriendItem) {
                        ((FriendItem)item).Show();
                    }
                }
                
            }
            else//收起时
            {
                this.buttonFriend.Image = MainProgram.Properties.Resources._3;
                this.panelSelf.Hide();
                foreach (var item in this.flowLayoutPanel.Controls)
                {
                    if (item is FriendItem)
                    {
                        ((FriendItem)item).Hide();
                    }                  
                }
            }
        }

        //自己选项被双击
        private void panelSelf_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormDialogManager.Instance.openDialog(2,-1,"我的", pictureBoxSelfFace.Image);

          //  UnityManager.Instance.changeUnityScene(4);
          //  UnityManager.Instance.resourceMode = 2;
        }

        private void pictureBoxSelfFace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormDialogManager.Instance.openDialog(2, -1, "我的", pictureBoxSelfFace.Image);
            //  UnityManager.Instance.changeUnityScene(4);
            //  UnityManager.Instance.resourceMode = 2;
        }

        private void labelTip_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormDialogManager.Instance.openDialog(2, -1, "我的", pictureBoxSelfFace.Image);
            //   UnityManager.Instance.changeUnityScene(4);
            //   UnityManager.Instance.resourceMode = 2;
        }

        private void labelSelf_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormDialogManager.Instance.openDialog(2, -1, "我的", pictureBoxSelfFace.Image);
            //UnityManager.Instance.changeUnityScene(4);
            //UnityManager.Instance.resourceMode = 2;
        }
    }
}
