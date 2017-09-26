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

namespace MainProgram
{
    public partial class FormPersionalInfo : Form
    {

        private static FormPersionalInfo instance;
        public static FormPersionalInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormPersionalInfo();
                }
                return instance;
            }
        }



        public string m_id;
        System.Windows.Forms.Timer closeTimer = new System.Windows.Forms.Timer();

        public FormPersionalInfo()
        {
            InitializeComponent();
        }

        private void FormPersionalInfo_Load(object sender, EventArgs e)
        {
            closeTimer.Enabled = true;
            closeTimer.Interval = 1000;
            closeTimer.Tick += CloseTimer_Tick;
        }

        //关闭面板 定时器
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
                this.Hide();
        }

        public void SetFormPersionalInfo(int type ,Point location ,string nickName, string username,string discription)
        {
            switch (type)
            {
                case 1://群
                    this.labelNickName.Text = nickName;
                    this.labelUsername.Text = "群号(" + username + ")";
                    this.labelDiscription.Text = discription;
                    break;
                case 3://个人
                    this.labelNickName.Text = nickName;
                    this.labelUsername.Text = "(" + username + ")";
                    this.labelDiscription.Text = discription;
                    break;
                default:
                    break;
            }
            location = new Point(location.X-this.Width-20, location.Y-10);//调整一下位置           
            this.Location = location;        
            this.Show();
        }


        //鼠标进入
        private void FormPersionalInfo_MouseEnter(object sender, EventArgs e)
        {
            enterItem("FormPersionalInfo");           
        }

        //当鼠标离开
        private void FormPersionalInfo_MouseLeave(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle(this.Location, this.Size);
            if (rectangle.Contains(MousePosition) == false)
            {
                leaveItem("FormPersionalInfo");             
            }          
        }

        public void leaveItem(string id) {
            if (id==m_id)
            {
                closeTimer.Start();
            }           
        }

        //标识符
        public void enterItem(string id)
        {
            m_id = id;
            closeTimer.Stop();
        }
     
    }
}
