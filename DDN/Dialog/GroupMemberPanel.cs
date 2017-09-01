using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dialog;
using System.Diagnostics;
using System.Threading;

namespace Dialog
{
    public partial class GroupMemberPanel : UserControl
    {

        #region 属性
        public SynchronizationContext m_SyncContext = null;
        public int m_memberAmount = 0;
        #endregion


        struct GroupMembers
        {
            public string Master;
            public string Manager;
            public string Member;
        }

        public GroupMemberPanel()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void GroupMemberPanel_Load(object sender, EventArgs e)
        {
            this.flowLayoutPanelGroupMember.Controls.Clear();
        }

        public void initMember(string membersJson) {
            Debug.Print("收到群成员是：" + membersJson);
            GroupMembers members = Coding<GroupMembers>.decode(membersJson);
            Debug.Print("群主是：" + members.Master);
            GroupMember master = new GroupMember(members.Master,2);
            addMemberSafePost(master);
            Debug.Print("管理是：" + members.Manager);
            string[] mans = members.Manager.Split(',');
            foreach (var item in mans)
            {
                if (item!="")
                {
                  //  GroupMember manger = new GroupMember(item,1);
                  //  addMemberSafePost(manger);
                }
            }
            Debug.Print("成员是：" + members.Member);
            string[] mems = members.Member.Split(',');
            foreach (var item in mems)
            {
                if (item != "")
                {
                    GroupMember member = new GroupMember(item,0);
                    addMemberSafePost(member);
                }
            }
        }


        public void addMemberSafePost(GroupMember gm)
        {
            m_SyncContext.Post(addMember, gm);
        }
        void addMember(object mem)
        {
            m_memberAmount++;
            this.labelGroupMember.Text = "群成员 "+ m_memberAmount;
            this.flowLayoutPanelGroupMember.Controls.Add((GroupMember)mem);
        }
    }
}
