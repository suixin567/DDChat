using MainProgram.UserControls;
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
    public partial class MsgTip : Form
    {
        public MsgTip()
        {
            InitializeComponent();
        }

        private void MsgTip_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width - this.Size.Width/2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            this .flowLayoutPanel1. Controls.Clear();
            //处理MsgMgr中待处理的消息
            Debug.Print("待处理信息个数" + MainMgr.Instance.msgMgr.mList.Count);
            for (int i = MainMgr.Instance.msgMgr.mList.Count - 1; i >= 0; i--)
            {
                MsgModel model = MainMgr.Instance.msgMgr.mList[i];
                MsgTipItem tipItem = new MsgTipItem(model);
                this.flowLayoutPanel1.Controls.Add(tipItem);
            }
        }


        public void showFormVerfyOrDialog() {
            //处理待处理消息
            MainMgr.Instance.msgMgr.showFormVerfyOrDialog();      
        }

    }
}
