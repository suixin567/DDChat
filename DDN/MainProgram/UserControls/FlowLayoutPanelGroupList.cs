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

namespace MainProgram.UserControls
{
    public partial class FlowLayoutPanelGroupList : UserControl
    {

        public FormCreateGroup formCreateGroup;

        public SynchronizationContext m_SyncContext = null;
        public int amount = 0;//群组个数        

        public FlowLayoutPanelGroupList()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            pullGroupList();
        }

        private void flowLayoutPanelCompanyList_Load(object sender, EventArgs e)
        {
            this.labelTip.Text = "";           
        }
        //拉取群列表
        void pullGroupList()
        {
            HttpReqHelper.requestSync(AppConst.WebUrl + "groupList?username=" + PlayerPrefs.GetString("username"),delegate(string pullGroupList) {
                Debug.Print("我的群列表------>>>>>>" + pullGroupList);
                if (pullGroupList=="") {
                    return;
                }
                try
                {
                    MyGroupModel[] myGroupModels = Coding<MyGroupModel[]>.decode(pullGroupList);
                    foreach (var group in myGroupModels)
                    {
                        addItemSafePost(group);
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
            });        
           
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
        public void addItemSafePost(MyGroupModel model)
        {
            m_SyncContext.Post(addItem, model);
        }
        void addItem(object state)
        {
            MyGroupModel model = (MyGroupModel)state;
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is GroupItem)
                {
                    var oldItem = (GroupItem)item;
                    if (oldItem.m_myGroupModel.GroupID == model.GroupID)
                    {//已经存在这个item
                        Debug.Print("已经存在这个群组的item");
                        return;
                    }
                }
            }
            GroupItem groupItem = new GroupItem(model);
            if (groupItem != null && groupItem.IsDisposed == false)
            {
                this.flowLayoutPanel.Controls.Add(groupItem);
                amount++;
                this.buttonGroup.Text = "我的群 " + amount;
            }
        }
        //创建公司
        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {
            创建群ToolStripMenuItem_Click(null,null);
        }

        //删除item
        public void removeItemSafePost(int gid)
        {
            m_SyncContext.Post(removeItem, gid);
        }
        void removeItem(object gid)
        {
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is GroupItem)
                {
                    var groupItem = (GroupItem)item;
                    if (groupItem.m_myGroupModel.GroupID ==int.Parse(gid.ToString()) )
                    {
                        //关闭对话窗体
                        Dialog.FormDialogManager.Instance.closeDialogueWindow("group" + groupItem.m_myGroupModel.GroupID);
                        groupItem.Dispose();
                        amount--;
                        this.buttonGroup.Text = "公司 " + amount;                      
                        break;
                    }
                }
            }
        }

        //获取列表
        public List<int> getGroupList()
        {
            List<int> glist = new List<int>();
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is GroupItem)
                {
                    var groupItem = (GroupItem)item;
                    glist.Add(groupItem.m_myGroupModel.GroupID);
                }
            }
            return glist;
        }


        //显示操作结果
        public void showOpreationResultSafePost(string content)
        {
            m_SyncContext.Post(showOpreationResult, content);
        }

        int delay = 0;
        int currentCount = 0;
        void showOpreationResult(object content)
        {
            this.labelTip.Text = content.ToString();
            delay = 4;
            currentCount = 0;
            this.timerOpreationResult.Start();
        }

        private void timerOpreationResult_Tick(object sender, EventArgs e)
        {
            currentCount++;
            if (currentCount >= delay)
            {
                this.timerOpreationResult.Stop();
                this.labelTip.Text = "";
            }
        }
        bool isGroupExpend = true;
        private void buttonGroup_Click(object sender, EventArgs e)
        {
            isGroupExpend = !isGroupExpend;
            if (isGroupExpend)
            {
                this.buttonGroup.Image = MainProgram.Properties.Resources._3_1;
                foreach (var item in this.flowLayoutPanel.Controls)
                {
                    if (item is GroupItem)
                    {
                        ((GroupItem)item).Show();
                    }
                }
            }
            else
            {
                this.buttonGroup.Image = MainProgram.Properties.Resources._3;
                foreach (var item in this.flowLayoutPanel.Controls)
                {
                    if (item is GroupItem)
                    {
                        ((GroupItem)item).Hide();
                    }
                }
            }
        }
    }
}
