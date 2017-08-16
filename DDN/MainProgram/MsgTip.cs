using MainProgram.UserControls;
using System;
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

namespace MainProgram
{
    public partial class MsgTip : Form
    {

        //#region 单例
        //private static MsgTip instance;
        //public static MsgTip Instance {
        //    get {
        //        if (instance ==null)
        //        {
        //            instance = new MsgTip();
        //        }
        //        return instance;
        //    }
        //}
        //#endregion

        public SynchronizationContext m_SyncContext = null;
        //需要提示的消息
        public List<MsgModel> tipMsgList = new List<MsgModel>();

        public MsgTip()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void MsgTip_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width - this.Size.Width/2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);           
        }

        //添加新提示
       public void addNewTip(MsgModel mode) {
            tipMsgList.Add(mode);
            MsgTipItem tipItem = new MsgTipItem(mode);
            addItemSafePost(tipItem);
            MainMgr.Instance.formMain.notifyIonFlashSafePost();//icon闪烁
            showFormSafePost();
        }

        //处理提示消息
        public void processTipMsg() {
            MainMgr.Instance.formMain.stopInconFlash();
            //用户已做处理，清空待处理
            for (int i = 0; i < tipMsgList.Count; i++)
            {
                if (tipMsgList[i].MsgType < 100)//验证类消息
                {
                    VerifyMsgMgr.Instance.openFormMesageVerify();
                }
                else {
                    //这是个聊天，打开聊天对话框
                }             
            }
            tipMsgList.Clear();
            this.flowLayoutPanel1.Controls.Clear();
            this.Hide();
        }






        void addItemSafePost(MsgTipItem item)
        {
            m_SyncContext.Post(addItem, item);
        }

        void addItem(object state)
        {
            this.flowLayoutPanel1.Controls.Add((MsgTipItem)state);
        }


        void showFormSafePost() {
            m_SyncContext.Post(showForm,null);
        }

       void showForm(object state)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height);
            this.Location = (Point)new Size(x, y);
            this.Show();
        }
    }
}
