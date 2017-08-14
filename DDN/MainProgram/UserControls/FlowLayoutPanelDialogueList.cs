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
    public partial class FlowLayoutPanelDialogueList : UserControl
    {
        public FlowLayoutPanelDialogueList()
        {
            InitializeComponent();
        }

        //打开验证管理器
        private void panelMsgVerifyItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        //打开验证管理器
        private void pictureBoxMsgVerifyFace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelMsgVerifyItem_MouseDoubleClick(null,null);
        }
        //打开验证管理器
        private void labelMsgVerify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelMsgVerifyItem_MouseDoubleClick(null, null);
        }
        //打开验证管理器
        private void labelMsgVerifyContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelMsgVerifyItem_MouseDoubleClick(null, null);
        }
    }
}
