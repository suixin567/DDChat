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
    public partial class VerifyMsgMgr : UserControl
    {
        public VerifyMsgMgr()
        {
            InitializeComponent();
        }


        private void VerifyMsgMgr_Load(object sender, EventArgs e)
        {

        }


        private void VerifyMsgMgr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainMgr.Instance.formMain.opFormMsgVerify();
        }

        private void pictureBoxFace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VerifyMsgMgr_MouseDoubleClick(null,null);
        }

        private void labelTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VerifyMsgMgr_MouseDoubleClick(null, null);
        }

        private void labelContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VerifyMsgMgr_MouseDoubleClick(null, null);
        }

 
    }
}
