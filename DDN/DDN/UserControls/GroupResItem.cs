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

namespace DDN.UserControls
{
    public partial class GroupResItem : UserControl
    {
        public GroupInfoModel m_groupInfoModel;

        public GroupResItem()
        {
            InitializeComponent();
        }

        public GroupResItem(GroupInfoModel model)
        {
            m_groupInfoModel = model;
            InitializeComponent();
        }

        private void GroupResItem_Load(object sender, EventArgs e)
        {

        }
        //群组资源被双击
        private void GroupResItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
            UnityManager.Instance.changeUnityScene(4);
            UnityManager.Instance.resourceMode = 1;
        }
    }
}
