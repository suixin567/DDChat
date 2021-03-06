﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using MainProgram.UserControls;
using Mgr;
using ToolLib;

namespace MainProgram
{
    public partial class FormAddFriend : Form
    {

        SynchronizationContext m_SyncContext = null;//线程上下文
                

        //构造
        public FormAddFriend()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }


        private void FormAddFriend_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width/2 - this.Size.Width/2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height/2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)    
            labelOpreationResult.Text = "";
        }

        //查找好友TODO：字符过滤
        private void buttonFindFriend_Click(object sender, EventArgs e)
        {
            if(textBoxFindFriend.Text == ""){
            showOpreationResultSafePost("输入不能为空。");
            return;
            }
            if (textBoxFindFriend.Text == AppInfo.USER_NAME)
            {
             showOpreationResultSafePost("不可以添加自己。");
             return;
            }

            if (textBoxFindFriend.Text != "")
            {
                this.flowLayoutPanelStrangers.Controls.Clear();
                HttpReqHelper.requestSync(AppConst.WebUrl+"findFriend?username="+textBoxFindFriend.Text,delegate(string friends) {
                   try
                   {
                       
                       PersonalInfoModel[] model = Coding<PersonalInfoModel[]>.decode(friends);
                       foreach (var item in model)
                       {
                           AddFriendItem otherItem = new AddFriendItem(item.Username, item.Nickname, item.Face);
                          // this.flowLayoutPanelStrangers.Controls.Add(otherItem);
                           addItemSafePost(otherItem);
                       }
                   }
                   catch (Exception)
                   {
                   }
               });                                    
            }
        }

        void addItemSafePost(AddFriendItem addFriendItem) {
            m_SyncContext.Post(addItem, addFriendItem);
        }
        void addItem(object state) {
            this.flowLayoutPanelStrangers.Controls.Add((AddFriendItem)state);
        }

        void addGroupItemSafePost(AddGroupItem _addGroupItem)
        {
            m_SyncContext.Post(addGroupItem, _addGroupItem);
        }
        void addGroupItem(object state)
        {
            this.flowLayoutPanelStrangers.Controls.Add((AddGroupItem)state);
        }

        #region 显示操作结果
        public void showOpreationResultSafePost(string content) {
            m_SyncContext.Post(showOpreationResult,content);
        }

        int delay = 0;
        int currentCount = 0;
       void showOpreationResult(object content) {
            this.labelOpreationResult.Text = content.ToString();
            delay = 4;
            currentCount = 0;
            this.timerOpreationResult.Start();
        }

        private void timerOpreationResult_Tick(object sender, EventArgs e)
        {
            currentCount++;
            if (currentCount>=delay) {
                this.timerOpreationResult.Stop();
                this.labelOpreationResult.Text = "";
            }
        }
        #endregion

        //查找公司
        private void buttonFindCompany_Click(object sender, EventArgs e)
        {
            if (textBoxFindCompany.Text != "")
            {
                this.flowLayoutPanelStrangers.Controls.Clear();
                DataMgr.Instance.getGroupByID(int.Parse(textBoxFindCompany.Text),delegate(GroupInfoModel model) {
                    if (model.Gid == 0)
                    {
                        return;
                    }
                    AddGroupItem otherItem = new AddGroupItem(model.Name, model.Gid, model.Face);
                    addGroupItemSafePost(otherItem);
                });                               
            }
        }


        private void closed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
