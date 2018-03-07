using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.UserControls
{
    public partial class InviteItem : UserControl
    {
        #region 属性
        Color oriColor;
        public string m_friendUsername;
        public string m_nickname;
        public Image m_face;
        FormInviteToGroup form;
        bool isSelectedState;
        #endregion

        public InviteItem()
        {
            InitializeComponent();
        }

        public InviteItem(string friendUsername,string nick,Image face, FormInviteToGroup formInviteToGroup,bool isSelected)
        {
            InitializeComponent();
            m_friendUsername = friendUsername;
            m_nickname = nick;
            m_face = face;
            oriColor = this.BackColor;
            this.labelContent.Text = nick + "(" + friendUsername + ")";
            form = formInviteToGroup;
            if (isSelected == false)
            {
                this.buttonClose.Hide();
            }
            else {
                isSelectedState = true;
            }
        }


        private void InviteItem_Load(object sender, EventArgs e)
        {
                      
        }

        private void InviteItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        private void InviteItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = oriColor;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        //被点击
        private void InviteItem_Click(object sender, EventArgs e)
        {
            if (isSelectedState==false)
            {
                form.onItemSelected(this);
            }
 
        }
    }
}
