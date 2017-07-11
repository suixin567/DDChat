using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using MainProgram.UserControls;
using Mgr;

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
            if (textBoxFindFriend.Text == PlayerPrefs.GetString("username"))
            {
             showOpreationResultSafePost("不可以添加自己。");
             return;
            }

            if (textBoxFindFriend.Text != "" && textBoxFindFriend.Text != PlayerPrefs.GetString("username"))
            {
              string friends =  HttpReqHelper.request(AppConst.WebUrl+"findFriend?username="+textBoxFindFriend.Text);
                try
                {
                    this.flowLayoutPanelStrangers.Controls.Clear();
                    PersonalInfoModel[] model = Coding<PersonalInfoModel[]>.decode(friends);
                    foreach (var item in model)
                    {
                        AddFriendItem otherItem = new AddFriendItem(item.Username, item.Nickname, item.Face);
                        this.flowLayoutPanelStrangers.Controls.Add(otherItem);
                    }
                }
                catch (Exception)
                {
                }                               
            }
        }


        //显示操作结果
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

        //查找公司
        private void buttonFindCompany_Click(object sender, EventArgs e)
        {
            if (textBoxFindCompany.Text != "")
            {
                
                string company = HttpReqHelper.request(AppConst.WebUrl + "groupBaseInfo?gid=" + textBoxFindCompany.Text);
                Debug.Print("找到的公司"+ company);
                try
                {
                    this.flowLayoutPanelStrangers.Controls.Clear();
                    GroupInfoModel model = Coding<GroupInfoModel>.decode(company);
                    if (model.Gid==0) {
                        return;
                    }
                    AddGroupItem otherItem = new AddGroupItem(model.Name, model.Gid, model.Face);
                    this.flowLayoutPanelStrangers.Controls.Add(otherItem);
                }
                catch (Exception)
                {
                }                                   
            }
        }


        private void closed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
