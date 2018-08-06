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

namespace Login
{
    public partial class FormForget1 : Form
    {
        FormForget2 formForget2;

        public FormForget1(int x, int y, FormLogin login)
        {
            InitializeComponent();           
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }

        private void FormForget1_Load(object sender, EventArgs e)
        {

        }



        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (!IsRightFormat(textBox1.Text))
            {
                MessageBox.Show("账号格式不正确！");
                return;
            }
            int x = this.Location.X;
            int y = this.Location.Y;
            formForget2 = new FormForget2(x, y, textBox1.Text);          
            this.Close();
            this.Dispose();                   
            formForget2.ShowDialog();                   
        }




        //账户格式校验
        public bool IsRightFormat(string str_handset)
        {
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"(^[0-9]{6,10}$)");
            return res;
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
