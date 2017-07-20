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
using Mgr;


namespace Login
{
    public partial class FormRegist : Form
    {

        bool accRight = false;
        bool psdRight = false;
        bool phoneRight = false;

        FormLogin formLogin;
        public FormRegist(int x,int y,FormLogin login)
        {
            formLogin = login;
            InitializeComponent();       
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }

        private void FormRegist_Load(object sender, EventArgs e)
        {
            pictureBoxUserNameTip.Hide();
            pictureBoxPsdTip.Hide();
            pictureBoxPhoneTip.Hide();
            labelregistResult.Text = "";
        }

        //注册按钮被提交
        private void buttonRegistCommit_Click(object sender, EventArgs e)
        {
            if (NetWorkManager.NET_STATE == NetState.WAIT) {
                return;
            }

            if (accRight == true && psdRight == true && phoneRight == true)
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
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^\w{6,10}$");

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
            //判断只能输入数字
            if (IsNumber(textBoxRegistUserName.Text) == false)
            {
                textBoxRegistUserName.Text = "";
            }
            else
            {
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
    }
        
}
