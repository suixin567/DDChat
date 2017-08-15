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

namespace MainProgram.UserControls
{
    public partial class MsgTipItem : UserControl
    {

        MsgModel m_mode;
        public MsgTipItem()
        {
            InitializeComponent();
        }

        public MsgTipItem(MsgModel mode)
        {
            m_mode = mode;
            InitializeComponent();
        }

        private void MsgTipItem_Load(object sender, EventArgs e)
        {
            switch (m_mode.MsgType)
            {
                case MsgProtocol.ONE_ADD_YOU_SRES://有人添加你
                    this.labelNickName.Text = m_mode.From;
                    this.labelContent.Text = "附加消息："+m_mode.Content;
                    break;
                default:
                    break;
            }
        }

        //被点击
        private void MsgTipItem_Click(object sender, EventArgs e)
        {
            Debug.Print("被点击");
            MsgTip FormMsgTip = (MsgTip)this.FindForm();
            //处理这些待处理消息
            FormMsgTip.showFormVerfyOrDialog();
        }
        //被点击
        private void labelNickName_Click(object sender, EventArgs e)
        {
            MsgTipItem_Click(null, null);
        }
        //被点击
        private void labelContent_Click(object sender, EventArgs e)
        {
            MsgTipItem_Click(null,null);
        }
    }
}
