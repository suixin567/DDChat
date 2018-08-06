using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class FormForget3 : Form
    {
        SynchronizationContext m_SyncContext = null;//线程上下文
        string acc;


        public FormForget3(int x,int y,string _acc)
        {
            acc = _acc;
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FormForget3_Load(object sender, EventArgs e)
        {

        }

        //确认按钮
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!IsPsdRightFormat(textBox1.Text))
            {
                MessageBox.Show("新密码的格式不正确！");
                return;
            }
            HttpReqHelper.requestSync(AppConst.WebUrl + "forgetPsd?protocol=2&acc=" + acc+"&psd="+ textBox1.Text, delegate (string callback)
            {
                if (callback == "true")
                {                    
                    
                    closeFormSafePost();
                }
                else
                {
                    MessageBox.Show("密码修改失败！", "提示：");
                }
            });

        }




        //密码格式校验
        public bool IsPsdRightFormat(string str_handset)
        {          
            bool res = System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^\w{6,13}$");
            return res;
        }


        public void closeFormSafePost()
        {
            m_SyncContext.Post(closeForm, null);
        }

        public void closeForm(object state)
        {
            MessageBox.Show("密码修改成功！", "提示：");
            this.Close();
            this.Dispose();
        }
    }
}
