using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mgr;
using ToolLib;


namespace Login
{
    public partial class FormRegist : Form
    {

        bool accRight = false;
        bool psdRight = false;
        bool phoneRight = false;
        bool zeroBegin = false;

        FormLogin formLogin;

        string phoneCode = "";

        public FormRegist(int x, int y, FormLogin login)
        {
            formLogin = login;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }

        private void FormRegist_Load(object sender, EventArgs e)
        {
            pictureBoxUserNameTip.Hide();
            pictureBoxPsdTip.Hide();
            pictureBoxPhoneTip.Hide();
            labelregistResult.Text = "";
        }

        //注册提交按钮被点击
        private void buttonRegistCommit_Click(object sender, EventArgs e)
        {
            if (NetWorkManager.NET_STATE == NetState.WAIT)
            {
                return;
            }
            if (textBoxPhoneCode.Text != phoneCode || phoneCode=="")
            {
                labelregistResult.Text = "短信验证码错误！";
                return;
            }

            if (accRight == true && psdRight == true && phoneRight == true && zeroBegin == false)
            {
                //变为等待状态
                NetWorkManager.NET_STATE = NetState.WAIT;
                //T送 注册数据
                LoginDTO dto = new LoginDTO();
                dto.userName = textBoxRegistUserName.Text;
                dto.passWord = textBoxRegistPsd.Text;
                dto.phone = textBoxRegistPhone.Text;
                string message = Coding<LoginDTO>.encode(dto);
                //print("json格式的注册账号与密码"+message );
                NetWorkManager.Instance.sendMessage(Protocol.LOGIN, 2, LoginProtocol.REG_CREQ, message);
            }
            else
            {
                labelregistResult.Text = "输入格式错误！";
            }
        }


        //账户格式校验
        public bool IsRightFormat(string str_handset)
        {
            bool temp = false;
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"(^[0-9]{6,10}$)");

            if (res == true)
            {
                temp = res;
                labelregistResult.Text = "";
            }
            return temp;
        }


        //密码格式校验
        public bool IsPsdRightFormat(string str_handset)
        {
            bool temp = false;
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^\w{6,13}$");

            if (res == true)
            {
                temp = res;
            }
            return temp;
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

        public bool IsZeroBegin(string str_handset)
        {
            bool temp = false;
            if (str_handset.Length == 0)
            {
                return false;
            }
            if (str_handset[0].ToString() == "0")
            {
                return true;
            }
            return temp;
        }


        //f纯数字格式校验
        public bool IsNumber(string str_handset)
        {
            bool temp = false;
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"(^[0-9]*$)");
            if (res == true)
            {
                temp = res;
            }
            return temp;
        }



        private void onUserNameChanged(object sender, EventArgs e)
        {
            //账号
            if (IsRightFormat(textBoxRegistUserName.Text))
            {
                pictureBoxUserNameTip.Show();
                accRight = true;
            }
            else
            {
                pictureBoxUserNameTip.Hide();
                accRight = false;
            }
            //判断是否以0开头
            if (IsZeroBegin(textBoxRegistUserName.Text))
            {
                zeroBegin = true;
            }
            else
            {
                zeroBegin = false;
            }


            //判断只能输入数字
            if (IsNumber(textBoxRegistUserName.Text) == false)
            {
                textBoxRegistUserName.Text = "";
            }

            labelregistResult.Text = "";
        }

        private void onPsdChanged(object sender, EventArgs e)
        {
            //密码
            if (IsPsdRightFormat(textBoxRegistPsd.Text))
            {
                pictureBoxPsdTip.Show();
                psdRight = true;
            }
            else
            {
                pictureBoxPsdTip.Hide();
                psdRight = false;
            }
            labelregistResult.Text = "";
        }

        private void onPhoneChanged(object sender, EventArgs e)
        {
            //电话
            if (IsPhoneset(textBoxRegistPhone.Text))
            {
                pictureBoxPhoneTip.Show();
                phoneRight = true;
            }
            else
            {
                pictureBoxPhoneTip.Hide();
                phoneRight = false;
            }
            labelregistResult.Text = "";
        }

        //注册结果
        public void RegResult(string message)
        {
            NetWorkManager.NET_STATE = NetState.RUN;

            if (message == "err")
            {
                formLogin.ThreadProcSafePost_Label("注册失败...err");
            }
            else if (message == "true")
            {
                formLogin.CloseRegistSafePost();
            }
            else if (message == "false")
            {
                formLogin.ThreadProcSafePost_Label("注册失败，此账号已注册！");
            }
            else
            {
                formLogin.ThreadProcSafePost_Label("注册失败，嗯，这不该发生。");
            }
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormRegist_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        //点击获取短信验证码
        private void buttonGetPhoneCode_Click(object sender, EventArgs e)
        {
            this.buttonGetPhoneCode.Enabled = false;//禁用验证码按钮
            //1检查手机号
            //2发送短信
            //3点击注册按钮时对比验证码是否是发送出去的验证码。及时间是否在有效期内。
            if (accRight == false)
            {
                labelregistResult.Text = "注册账号格式不正确！";
                return;

            }
            else if (psdRight == false)
            {
                labelregistResult.Text = "注册密码格式不正确！";
                return;
            }
            else if (phoneRight == false)
            {
                labelregistResult.Text = "手机号格式不正确！";
                return;
            }
            else
            {
                //随机验证码
                Random rd = new Random();
                int a = rd.Next(0, 10);
                int b = rd.Next(0, 10);
                int c = rd.Next(0, 10);
                int d = rd.Next(0, 10);
                phoneCode = a.ToString() + b.ToString() + c.ToString() + d.ToString();
             //   MessageBox.Show(phoneCode+" "+ textBoxRegistPhone.Text);
                int result =SendPhoneCode.sendVerifyPhoneMsg(textBoxRegistPhone.Text, "注册验证码" + phoneCode + "，2分钟内有效。");

                if (result != 0)
                {
                    MessageBox.Show("注册功能维护中！稍后再试！" + result);
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
                        this.buttonGetPhoneCode.Text =  waitCount + "(s)内有效";
                        if (waitCount==0)
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
        }


    }
}