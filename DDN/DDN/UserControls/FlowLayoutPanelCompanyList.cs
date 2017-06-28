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
using DDN.Tools;

namespace DDN.UserControls
{
    public partial class FlowLayoutPanelCompanyList : UserControl
    {

        FormCreateGroup formCreateGroup;

        public SynchronizationContext m_SyncContext = null;
        private int amount = 0;//群组个数        

        public FlowLayoutPanelCompanyList()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void flowLayoutPanelCompanyList_Load(object sender, EventArgs e)
        {
            pullGroupList();
        }
        //拉取群列表
        void pullGroupList()
        {
            string pullGroupList = HttpReqHelper.request(AppConst.WebUrl + "groupList?username=" + GameInfo.ACC_ID);
            Debug.Print("我的群列表" + pullGroupList);
            string[] groupArr = pullGroupList.Split(',');
            foreach (var group in groupArr)
            {
                if (group != "")
                {
                    addItemSafePost(group);
                }
            }
        }


        //创建公司
        private void 创建群ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Print("创建公司");
            if (formCreateGroup == null)
            {
                formCreateGroup = new FormCreateGroup();
                formCreateGroup.Show();
            }
            else {
                if (formCreateGroup.IsDisposed) {
                    formCreateGroup = new FormCreateGroup();
                    formCreateGroup.Show();
                }
                formCreateGroup.Activate();
            }            
        }


        //添加item
        public void addItemSafePost(string groupID)
        {
            m_SyncContext.Post(addItem, groupID);
        }
        void addItem(object state)
        {
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is GroupItem)
                {
                    var oldItem = (GroupItem)item;
                    if (oldItem.m_groupID == state.ToString())
                    {//已经存在这个item
                        Debug.Print("已经存在这个群组的item，这不该发生");
                        return;
                    }
                }
            }
            GroupItem groupItem = new GroupItem(state.ToString());
            if (groupItem != null && groupItem.IsDisposed == false)
            {
                this.flowLayoutPanel.Controls.Add(groupItem);
                amount++;
                this.labelTitle.Text = "公司 " + amount;
            }

        }
        //创建公司
        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {

        }

        ////删除item
        //public void removeFriendItemSafePost(string username)
        //{
        //    m_SyncContext.Post(removeFriendItem, username);
        //}
        //void removeFriendItem(object usreName)
        //{
        //    foreach (var item in this.flowLayoutPanel.Controls)
        //    {
        //        if (item is FriendItem)
        //        {
        //            var friendItem = (FriendItem)item;
        //            if (friendItem.FriendUsername == usreName.ToString())
        //            {
        //                friendItem.Dispose();
        //                amount--;
        //                this.labelTitle.Text = "公司 " + amount;
        //                break;
        //            }
        //        }
        //    }
        //}
        ////获取列表
        //public List<string> getFriendList()
        //{
        //    List<string> friendList = new List<string>();
        //    foreach (var item in this.flowLayoutPanel.Controls)
        //    {
        //        if (item is FriendItem)
        //        {
        //            var friendItem = (FriendItem)item;
        //            friendList.Add(friendItem.FriendUsername);
        //        }
        //    }
        //    return friendList;
        //}
    }
}
