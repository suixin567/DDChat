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
    public partial class FlowLayoutPanelResourcesList : UserControl
    {
        public FlowLayoutPanelResourcesList()
        {
            InitializeComponent();
        }

 

        private void FlowLayoutPanelResourcesList_Load(object sender, EventArgs e)
        {            

        }

        private void buttonMyRes_Click(object sender, EventArgs e)
        {

        }
        bool isItemInited = false;
        bool isGroupResShow = false;
        private void buttonGroupRes_Click(object sender, EventArgs e)
        {
            if (isItemInited == false)
            {
                copyGroupItem();
                isItemInited = true;
                isGroupResShow = true;
                return;
            }
            isGroupResShow = !isGroupResShow;
            if (isGroupResShow)//展开
            {
                this.flowLayoutPanelGroupResItemList.Show();
            }
            else {//收起
                this.flowLayoutPanelGroupResItemList.Hide();
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {

        }


        void copyGroupItem() {
            
            for (int i = 0; i < Manager.Instance.formMain.flowLayoutPanelGroupList.flowLayoutPanel.Controls.Count; i++)
            {
                if (Manager.Instance.formMain.flowLayoutPanelGroupList.flowLayoutPanel.Controls[i] is GroupItem) {
                    GroupItem gi = (GroupItem)Manager.Instance.formMain.flowLayoutPanelGroupList.flowLayoutPanel.Controls[i];
                    GroupResItem item = new GroupResItem();
                    item.pictureBoxFace.Image = gi.pictureBoxGroupFace.Image;
                    item.labelName.Text = gi.labelName.Text;
                    this.flowLayoutPanelGroupResItemList.Controls.Add(item);
                }              
            }
        }
    }
}
