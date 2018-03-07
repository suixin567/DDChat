using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Forms;

namespace MainProgram.UserControls
{
    public partial class FlowLayoutPanelDialogueList : UserControl
    {

        #region 属性  string: friend123456 \ group1000
        ConcurrentDictionary<string, DialogueItem> DialogueDic = new ConcurrentDictionary<string, DialogueItem>();
        public SynchronizationContext m_SyncContext = null;
        #endregion

        public FlowLayoutPanelDialogueList()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        //TODO:应加载历史的dialogue
        private void FlowLayoutPanelDialogueList_Load(object sender, EventArgs e)
        {
        }


        public struct IdAndContent {
            public string friendAndGroupID;
            public string content;
        }


        //更新一个对话item （新建或者更新）friendAndGroupID已包含friend或者group前缀
        public void reFreshContent(string friendAndGroupID , string content) {
            if (DialogueDic.ContainsKey(friendAndGroupID))//已有
            {
                DialogueDic[friendAndGroupID].reFreshContentSafePost(content);
            }
            else {//新建
                IdAndContent idAndContent = new IdAndContent();
                idAndContent.friendAndGroupID = friendAndGroupID;
                idAndContent.content = content;
                addItemSafePost(idAndContent);
            }
        }

        //添加一个item。
        public void addItemSafePost(IdAndContent para)
        {
            m_SyncContext.Post(addItem, para);
        }
        void addItem(object state)
        {
            IdAndContent idAndContent = (IdAndContent)state;
            DialogueItem item = new DialogueItem(idAndContent.friendAndGroupID, idAndContent.content);
            DialogueDic.TryAdd(idAndContent.friendAndGroupID, item);
            this.flowLayoutPanel.Controls.Add(item);
            this.flowLayoutPanel.Controls.SetChildIndex(item, 0);
            //如果个数太多,销毁最后一个
            if (this.flowLayoutPanel.Controls.Count > 99)
            {
                //清除dic
                removeDialogueSafePost(((DialogueItem)this.flowLayoutPanel.Controls[this.flowLayoutPanel.Controls.Count - 1]).m_friendAndGroupID);
            }
        }

        //删除一个dialogue
        public void removeDialogueSafePost(string friendAndGroupID) {
            m_SyncContext.Post(removeDialogue,friendAndGroupID);                              
        }

        void removeDialogue(object state) {
            string friendAndGroupID = (string)state;
            if (DialogueDic.ContainsKey(friendAndGroupID))
            {
                //清除dic
                DialogueItem item;
                DialogueDic.TryRemove(friendAndGroupID,out item);
                if (item!=null)
                {
                    item.Dispose();
                }                           
            }
        }

        private void 清空会话列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogueDic.Clear();
            foreach (var item in this.flowLayoutPanel.Controls)
            {
                if (item is DialogueItem )
                {
                    ((DialogueItem)item).Dispose();
                }
              
            }
        }
    }
}
