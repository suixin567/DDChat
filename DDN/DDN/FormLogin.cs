﻿using DDN.Tools;
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

namespace DDN
{
    public partial class FormLogin : Form
    {

        private static FormLogin instance;
        public static FormLogin Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormLogin();
                }
                return instance;
            }
        }


        SynchronizationContext m_SyncContext = null;//线程上下文
        bool accRight = false;
        bool psdRight = false;

        //注册窗体
        public FormRegist formRegist;


        public FormLogin()
        {
            InitializeComponent();
            Debug.Print("登录窗体线程" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
            pictureBoxUserNameTip.Hide();
            pictureBoxPsdTip.Hide();
            this.labelOpreationResult.Text = "";
            //判断是否记住密码
            if (PlayerPrefs.GetInt("remeberAcc") == 0)
            {
                checkBoxRemmberPsd.Checked = false;
            }
            else
            {
                checkBoxRemmberPsd.Checked = true;
                textBoxUserName.Text = PlayerPrefs.GetString("account");
                textBoxPassword.Text = PlayerPrefs.GetString("passWord");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (NetWorkManager.NET_STATE == NetState.WAIT)
            {
                return;
            }
            //联网模式
            //    GameInfo.LOGIN_MODEL = 0;
            if (accRight == true && psdRight == true)
            {
                NetWorkManager.NET_STATE = NetState.WAIT;
                GameInfo.ACC_ID = textBoxUserName.Text;
                GameInfo.ACC_PSD = textBoxPassword.Text;
                //发送登陆到服务器
                LoginDTO dto = new LoginDTO();
                dto.userName = textBoxUserName.Text;
                dto.passWord = textBoxPassword.Text;
                string message = Coding<LoginDTO>.encode(dto);
                NetWorkManager.Instance.sendMessage(Protocol.LOGIN, 0, LoginProtocol.LOGIN_CREQ, message);
                PlayerPrefs.SetString("account", textBoxUserName.Text);
                PlayerPrefs.SetString("passWord", textBoxPassword.Text);
                if (checkBoxRemmberPsd.Checked == true)
                {
                    PlayerPrefs.SetInt("remeberAcc", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("remeberAcc", 0);
                }
                //增加菊花
                //    LoadingPanelManager.instance.setLoadingPanel("login", transform, Vector2.zero, Vector2.one);
            }
            else
            {
                showOpreationResult("输入格式错误，请检查后重试！",3);
            }
        }

        public void OnMessage(SocketModel model)
        {
            NetWorkManager.NET_STATE = NetState.RUN;
            switch (model.Command)
            {
                case LoginProtocol.REG_SRES://注册结果
                    formRegist.RegResult(model.Message);
                    break;
                case LoginProtocol.LOGIN_SRES://登陆结果
                    LoginResult(model.Message);
                    break;
                case LoginProtocol.RELOGIN_SRES://重新登陆的结果
                    reLoginResult(model.Message);
                    break;
                default:
                    Debug.Print("登陆消息类型错误");
                    break;
            }
        }

        //重新登陆的结果
        void reLoginResult(string message)
        {
            Debug.Print("重新登陆结果" + message);
            //TODO:
        }
        //正常登陆的结果
        void LoginResult(string message)
        {
            if (message == "err")
            {
                showOpreationResult("登陆未知错误...err",3);
                return;
            }
            switch (message)
            {
                case "10"://用户名不存在
                    DDN.Tools.DDMsgBox.Show(new Point(Location.X + 100, Location.Y + 100), "用户名不存在...", null);
                    break;
                case "11"://已登录
                    DDN.Tools.DDMsgBox.Show(new Point(Location.X + 100, Location.Y + 100), "此账号已登录...", null);
                    break;
                case "12"://密码错误
                    DDN.Tools.DDMsgBox.Show(new Point(Location.X + 100, Location.Y + 100), "密码错误...", null);
                    break;
                default:
                    loginOK(message);
                    break;
            }
        }

        void loginOK(string userInfo)
        {
            //登陆成功
            Debug.Print("登录结果是：" + userInfo);
            GameInfo.IS_LOGIN = 1;//已登录
            //跳转场景 ,不需要销毁自己
            Manager.Instance.formLogin.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态                                                                     
        }

        private void FormLoginClose(object sender, FormClosedEventArgs e)
        {
            if (GameInfo.IS_LOGIN == 0)
            {
                Manager.Instance.ExitApp();
            }
        }

        private void labelRegist_Click(object sender, EventArgs e)
        {
            int x = this.Location.X - 200;
            int y = this.Location.Y - 200;
            Debug.Print("已经赋值");
            formRegist = new FormRegist(x, y, this);
            m_SyncContext = SynchronizationContext.Current;
            formRegist.ShowDialog();
        }

        //账户密码格式校验
        public bool IsRightFormat(string str_handset)
        {
            bool temp = false;
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^\w{6,13}$");
            if (res == true)
            {
                temp = res;
            }
            return temp;
        }
        //输入账号时
        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            //账号
            if (IsRightFormat(textBoxUserName.Text))
            {
                pictureBoxUserNameTip.Show();
                accRight = true;
            }
            else
            {
                pictureBoxUserNameTip.Hide();
                accRight = false;
            }
        }
        //输入密码时
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            //密码
            if (IsRightFormat(textBoxPassword.Text))
            {
                pictureBoxPsdTip.Show(); psdRight = true;
            }
            else
            {
                pictureBoxPsdTip.Hide(); psdRight = false;
            }
        }


        public void ThreadProcSafePost_Close()
        {
            m_SyncContext.Post(SetTextSafePost_Close, null);
        }

        public void SetTextSafePost_Close(object state)
        {
            formRegist.Close();
            formRegist.Dispose();
        }

        public void ThreadProcSafePost_Label(string value)
        {
            m_SyncContext.Post(SetTextSafePost_Label, value);
        }

        public void SetTextSafePost_Label(object state)
        {
            formRegist.labelregistResult.Text = state.ToString();
        }


        int delay = 0;
        int currentCount = 0;
        public void showOpreationResult(string content, int _delay)
        {
            this.labelOpreationResult.Text = content;
            delay = _delay;
            currentCount = 0;
            this.timerOpreationResult.Start();
        }

        private void timerOpreationResult_Tick(object sender, EventArgs e)
        {
            currentCount++;
            if (currentCount >= delay)
            {
                this.timerOpreationResult.Stop();
                this.labelOpreationResult.Text = "";
            }
        }
    }
}







