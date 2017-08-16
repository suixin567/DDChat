using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MainProgram.UserControls
{


    public partial class VerifyMsgItem : UserControl
    {



        #region 属性
        SynchronizationContext m_SyncContext = null;//线程上下文
        #endregion

        //构造
        public VerifyMsgItem()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            VerifyMsgMgr.Instance.verifyMsgItem = this;
        }


        private void VerifyMsgMgr_Load(object sender, EventArgs e)
        { 
      
        }
 

        //更新内容
        public void setContentSafePost(string content)
        {
            m_SyncContext.Post(setContent, content);
        }

        void setContent(object state)
        {
            this.labelCont.Text = (string)state;
        }


        private void VerifyMsgMgr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VerifyMsgMgr.Instance.openFormMesageVerify();
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
