using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace MainProgram.UserControls
{
    public partial class DialogueItem : UserControl
    {
        #region 属性
        public SynchronizationContext m_SyncContext = null;
        public string m_friendAndGroupID;
        #endregion

        public DialogueItem()
        {
            InitializeComponent();
        }

        
        public DialogueItem(string friendAndGroupID,string content)
        {
            InitializeComponent();
            
            m_SyncContext = SynchronizationContext.Current;
            m_friendAndGroupID = friendAndGroupID;
            reFreshContentSafePost(content);
        }

        private void DialogueItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(PictureBoxDialogueFace.DisplayRectangle, 0, 360);
            PictureBoxDialogueFace.Region = new Region(path);
        }

        //更新内容
        public void reFreshContentSafePost(string content) {
            m_SyncContext.Post(reFreshContent,content);
        }

        void reFreshContent(object state)
        {
            this.LabelHistory.Text = (string)state;
        }


        private void 移除会话ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMgr.Instance.formMain.flowLayoutPanelDialogueList.removeDialogueSafePost(m_friendAndGroupID);
        }
    }
}
