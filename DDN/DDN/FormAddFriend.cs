using DDN.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DDN
{
    public partial class FormAddFriend : Form
    {

        SynchronizationContext m_SyncContext = null;//线程上下文
                

        //构造
        public FormAddFriend()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            Debug.Print("添加好友窗体线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
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
            if (textBoxFindFriend.Text!="" && textBoxFindFriend.Text!= GameInfo.ACC_ID) {
              string friends =  HttpReqHelper.request(AppConst.WebUrl+"findFriend?username="+textBoxFindFriend.Text);
                if (friends!="null")
                {
                    this.flowLayoutPanelStrangers.Controls.Clear();
                    PersonalInfoModel[] model = Coding<PersonalInfoModel[]>.decode(friends);                  
                    foreach (var item in model)
                    {
                        AddFriendItem otherItem = new AddFriendItem(item.Username,item.Nickname,item.Face);
                        this.flowLayoutPanelStrangers.Controls.Add(otherItem);
                    }
                }               
            }
            //Debug.Print("找到几个陌生人"+ this.flowLayoutPanelStrangers.Controls.Count);
        }
        //查找公司
        private void buttonFindCompany_Click(object sender, EventArgs e)
        {
            Debug.Print("线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        //收到消息
        public void onMessage(MsgModel model) {
            m_SyncContext.Post(addFriendSafePost, model.To);
        }


        public void addFriendSafePost(object state)
        {
            //Debug.Print("22响应线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            //Debug.Print("22添加好友的响应" + state);
            //Debug.Print("22找到几个陌生人" + this.flowLayoutPanelStrangers.Controls.Count);
            foreach (Control ctl in this.flowLayoutPanelStrangers.Controls)
            {
                if (ctl is AddFriendItem)
                {
                    AddFriendItem t = (AddFriendItem)ctl;
               //     Debug.Print("正在遍历");
                    if (t.labelUsername.Text == state.ToString())
                    {
                        showOpreationResult("好友申请已经发出，请等待对方处理。",3);
                        t.Dispose();
                    }
                }

            }
        }

        int delay = 0;
        int currentCount = 0;
       public void showOpreationResult(string content,int _delay) {
            this.labelOpreationResult.Text = content;
            delay = _delay;
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
    }
}
