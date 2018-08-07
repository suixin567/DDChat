using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolLib;

namespace Login
{
    public partial class FormForget2 : Form
    {
        FormForget1 formForget1;
        FormForget3 formForget3;
        string phoneNum;
        string phoneCode = "";
        SynchronizationContext m_SyncContext = null;//线程上下文
        string acc;

        public FormForget2(int x, int y, string _acc)
        {
            acc = _acc;
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            //拉取账号关联的电话号           
            Debug.Print(acc + AppConst.WebUrl + "forgetPsd?protocol=1&acc=" + acc);
            HttpReqHelper.requestSync(AppConst.WebUrl + "forgetPsd?protocol=1&acc=" + acc, delegate (string callback)
                {
                    if (callback != "" && callback != "error")
                    {
                        phoneNum = callback;
                        SetPhonetipSafePost("提示：" + phoneNum.Substring(0, 4) + "*******");
                    }
                    else
                    {
                        MessageBoxSafePost("此账号不存在！请核对后重试");
                    }
                });
        }


        private void FormForget2_Load(object sender, EventArgs e)
        {
            this.textBoxPhoneCode.Hide();
            this.buttonGetPhoneCode.Hide();
            this.buttonNext.Hide();
        }


        public void SetPhonetipSafePost(string content)
        {
            m_SyncContext.Post(SetPhonetip, content);
        }

        public void SetPhonetip(object state)
        {
            this.labelHponeTip.Text = (string)state;
        }


        public void MessageBoxSafePost(string content)
        {
            m_SyncContext.Post(MessageBox, content);
        }

        public void MessageBox(object state)
        {
            int x = this.Location.X;
            int y = this.Location.Y;
            this.Location = new Point(10000,0);
            System.Windows.Forms.MessageBox.Show((string)state, "提示：");

            formForget1 = new FormForget1(x, y);                                         
            this.Close();
            this.Dispose();
            formForget1.ShowDialog();
        }



        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (textBoxPhoneCode.Text != phoneCode || phoneCode == "")
            {
                System.Windows.Forms.MessageBox.Show("短信验证码错误！");
                return;
            }
            int x = this.Location.X;
            int y = this.Location.Y;
            formForget3 = new FormForget3(x, y, acc);
            this.Close();
            this.Dispose();         
            formForget3.ShowDialog();
        }

        //获取验证码按钮 被点击
        private void ButtonGetPhoneCode_Click(object sender, EventArgs e)
        {
            //1检查手机号
            //2发送短信
            //3点击注册按钮时对比验证码是否是发送出去的验证码。及时间是否在有效期内。

           

            if (!IsPhoneset(textBoxPhone.Text))
            {
                System.Windows.Forms.MessageBox.Show("请输入正确的手机号", "提示：");
                return;
            }
            //禁用验证码按钮
            this.buttonGetPhoneCode.Enabled = false;

            //随机验证码
            Random rd = new Random();
            int a = rd.Next(0, 10);
            int b = rd.Next(0, 10);
            int c = rd.Next(0, 10);
            int d = rd.Next(0, 10);
            phoneCode = a.ToString() + b.ToString() + c.ToString() + d.ToString();
            int result = SendPhoneCode.sendVerifyPhoneMsg(phoneNum, "注册验证码" + phoneCode + "，2分钟内有效。");
            if (result != 0)
            {
                System.Windows.Forms.MessageBox.Show("密码找回功能维护中！稍后再试！" + result);
                return;
            }
            else
            {
                int waitCount = 120;
                //开启一个计时器
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Start();
                timer.Tick += (sen, eve) =>
                {
                    waitCount--;
                    this.buttonGetPhoneCode.Text = waitCount + "(s)内有效";
                    if (waitCount == 0)
                    {
                        phoneCode = "";
                        this.buttonGetPhoneCode.Enabled = true;//恢复验证码按钮
                        this.buttonGetPhoneCode.Text = "获取短信验证码";
                        ((System.Windows.Forms.Timer)sen).Stop();
                        ((System.Windows.Forms.Timer)sen).Dispose();
                    }
                };
            }
        }





        //电话格式校验
        public bool IsPhoneset(string str_handset)
        {
            bool temp = false;
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5,8]+\d{9}");
            if (res == true)
            {
                temp = res;
            }
            return temp;
        }


        private void TextBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == phoneNum)
            {
                this.textBoxPhoneCode.Show();
                this.buttonGetPhoneCode.Show();
                this.buttonNext.Show();
            }
            else {
                this.textBoxPhoneCode.Hide();
                this.buttonGetPhoneCode.Hide();
                this.buttonNext.Hide();
            }
        }
    }
}
