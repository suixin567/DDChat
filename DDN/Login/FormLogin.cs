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
using Mgr;

namespace Login
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
            m_SyncContext = SynchronizationContext.Current;
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
           //     GameInfo.ACC_ID = textBoxUserName.Text;
          //      GameInfo.ACC_PSD = textBoxPassword.Text;
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
                showOpreationResult("输入格式错误，请检查后重试！");
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
                showLoginOpreationResultSafePost("登陆未知错误...err");
                return;
            }
            switch (message)
            {
                case "10"://用户名不存在                    
                    showLoginOpreationResultSafePost("用户名不存在...");
                    break;
                case "11"://已登录
                    showLoginOpreationResultSafePost("此账号已登录...");
                    break;
                case "12"://密码错误
                    showLoginOpreationResultSafePost("密码错误...");
                    break;
                default:
                    loginOK(message);
                    break;
            }
        }

        void loginOK(string userInfo)
        {
            //登陆成功
          // Debug.Print("FormLogin--->>>登录结果是：" + userInfo);
        //    GameInfo.IS_LOGIN = 1;//已登录
            //跳转场景 ,不需要销毁自己
     //     LoginMgr.Instance.formLogin.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态     
           CloseSafePost();                                                    
        }

        private void FormLoginClose(object sender, FormClosedEventArgs e)
        {
        //    if (GameInfo.IS_LOGIN == 0)
         //   {
         //       Manager.Instance.ExitApp();
        //    }
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                //    e.Cancel = true;
                //使关闭时窗口向右下角缩小的效果
                //   this.WindowState = FormWindowState.Minimized;
                //    this.notifyIcon1.Visible = true;
                //    this.Hide();
                //    return;
                Debug.Print("用户关闭窗体");
                Environment.Exit(0);
            }
     
        }

        private void labelRegist_Click(object sender, EventArgs e)
        {
            int x = this.Location.X - 200;
            int y = this.Location.Y - 200;
            formRegist = new FormRegist(x, y, this);
           
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

        public void CloseSafePost()
        {
            m_SyncContext.Post(CloseSelf, null);
        }

        public void CloseSelf(object state)
        {
            Dispose();
        }


        public void CloseRegistSafePost()
        {
            m_SyncContext.Post(CloseRegist, null);
            showLoginOpreationResultSafePost("注册成功！");
        }

        public void CloseRegist(object state)
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






        void showLoginOpreationResultSafePost(string content)
        {
            m_SyncContext.Post(showOpreationResult, content);
        }

        int delay = 0;
        int currentCount = 0;
        void showOpreationResult(object content)
        {
            this.labelOpreationResult.Text = content.ToString();
            delay = 3;
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







