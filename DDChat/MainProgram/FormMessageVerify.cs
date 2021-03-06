﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mgr;
using MainProgram.UserControls;

namespace MainProgram
{
    public partial class FormMessageVerify : Form
    {

        SynchronizationContext m_SyncContext = null;//线程上下文

        public FormMessageVerify()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void FormMessageVerify_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width/2 - this.Size.Width/2-100);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2-100);
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y) 
            labelOpreationResult.Text = "";
            reFresh();
        }
  

        public void reFresh()
        {
            this.labelMsgAmount.Text = "消息验证: " + VerifyMsgMgr.Instance.vmList.Count + "条";
            this.flowLayoutPanel.Controls.Clear();
            for (int i = VerifyMsgMgr.Instance.vmList.Count - 1; i >= 0; i--)
            {
                VerifyMsgModel model = VerifyMsgMgr.Instance.vmList[i];
                MsgVerifyItem verifyItem = new MsgVerifyItem(model);
                this.flowLayoutPanel.Controls.Add(verifyItem);
            }
        }



        #region 操作结果显示
        public void showOpreationResultSafePost(string count)
        {
            m_SyncContext.Post(showOpreationResult, count);
        }

        int delay = 0;
        int currentCount = 0;
        public void showOpreationResult(object content)
        {
            this.labelOpreationResult.Text = content.ToString();
            delay = 5;
            currentCount = 0;
            this.timerOpreationResult.Start();
        }

        private void timerOpreationResult_Tick(object sender, EventArgs e)
        {
            currentCount++;
            if (currentCount >= delay)
            {
                this.timerOpreationResult.Stop();
                this.labelOpreationResult.Text = "";
            }
        }
        #endregion

        private void FormMessageVerify_Activated(object sender, EventArgs e)
        {
            reFresh();
        }
    }
}
