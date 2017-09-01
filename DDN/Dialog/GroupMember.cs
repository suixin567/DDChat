using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Dialog
{
    public partial class GroupMember : UserControl
    {
        public GroupMember()
        {
            InitializeComponent();
        }

        public GroupMember(string uid,int memberLevel)
        {
            InitializeComponent();
            this.labelContent.Text = uid;
            switch (memberLevel)
            {
                case 2:
                    this.labelLevel.Text = "群主";
                    break;
                case 1:
                    this.labelLevel.Text = "管理员";
                    break;
                case 0:
                    this.labelLevel.Text = "";
                    break;
                default:
                    break;
            }            
         
        }

        private void GroupMember_Load(object sender, EventArgs e)
        {

        }
    }
}
