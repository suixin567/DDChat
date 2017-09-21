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




        public bool isCanHide = false;//是否可以隐藏
       

        public void init() {

        }

        public FormPersionalInfo()
        {
            InitializeComponent();
        }

        private void FormPersionalInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetFormPersionalInfo(Point location ,string nickName, string username,string discription)
        {
            location = new Point(location.X-this.Width-20, location.Y-10);//调整一下位置           
            this.Location = location;
            this.labelNickName.Text = nickName;
            this.labelUsername.Text = "("+username+")";
            this.labelDiscription.Text = discription;
            this.Show();
        }


        public void HideFormPersionalInfo()
        {
            if (isCanHide)
            {
                this.Hide();
            }             
        }

        //当鼠标离开
        private void FormPersionalInfo_MouseLeave(object sender, EventArgs e)
        {
            leaveItem();
            System.Windows.Forms.Timer closeTimer = new System.Windows.Forms.Timer();
            closeTimer.Enabled = true;
            closeTimer.Interval = 1500;
            closeTimer.Tick += (sen, eve) => {
                ((System.Windows.Forms.Timer)sen).Stop();
                ((System.Windows.Forms.Timer)sen).Dispose();
                //Rectangle rectangle = new Rectangle(this.Location, this.Size);
                //if (rectangle.Contains(MousePosition) == false)
                //{
                //    HideFormPersionalInfo();
                //    Debug.Print("我自己被销毁");
                //}
                HideFormPersionalInfo();
            };
            closeTimer.Start();
        }

        public void leaveItem() {
            this.isCanHide = true;
        }

        public void enterItem()
        {
            this.isCanHide = false;
        }

        //鼠标进入
        private void FormPersionalInfo_MouseEnter(object sender, EventArgs e)
        {
            enterItem();
        }
    }
}
