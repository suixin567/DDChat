using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDN.UserControls
{
    public partial class MainTabControl : UserControl
    {
        int currentSelectState = 1;//默认选中朋友列表

        public MainTabControl()
        {
            InitializeComponent();
            
        }

        private void MainTabControl_Load(object sender, EventArgs e)
        {

        }

        //会话选项卡被点击
        private void buttonDialogue_Click(object sender, EventArgs e)
        {
            FormMain formMain = (FormMain)this.FindForm();
            switch (currentSelectState)
            {
                case 0:
                    break;
                case 1:
                    formMain.flowLayoutPanelDialogueList.Location = formMain.flowLayoutPanelFriendList.Location;
                    formMain.flowLayoutPanelDialogueList.Size = formMain.flowLayoutPanelFriendList.Size;
                    formMain.flowLayoutPanelDialogueList.Anchor = formMain.flowLayoutPanelFriendList.Anchor;
                    formMain.flowLayoutPanelDialogueList.Show();
                    formMain.flowLayoutPanelFriendList.Hide();
                    break;
                case 2:
                    formMain.flowLayoutPanelDialogueList.Location = formMain.flowLayoutPanelCompanyList.Location;
                    formMain.flowLayoutPanelDialogueList.Size = formMain.flowLayoutPanelCompanyList.Size;
                    formMain.flowLayoutPanelDialogueList.Anchor = formMain.flowLayoutPanelCompanyList.Anchor;
                    formMain.flowLayoutPanelDialogueList.Show();
                    formMain.flowLayoutPanelCompanyList.Hide();
                    break;
                default:
                    break;
            }
            currentSelectState = 0;
        }

        //好友选项卡被点击
        private void buttonFriends_Click(object sender, EventArgs e)
        {
            FormMain formMain = (FormMain)this.FindForm();
            switch (currentSelectState)
            {
                case 0:
                    formMain.flowLayoutPanelFriendList.Location = formMain.flowLayoutPanelDialogueList.Location;
                    formMain.flowLayoutPanelFriendList.Size = formMain.flowLayoutPanelDialogueList.Size;
                    formMain.flowLayoutPanelFriendList.Anchor = formMain.flowLayoutPanelDialogueList.Anchor;
                    formMain.flowLayoutPanelFriendList.Show();
                    formMain.flowLayoutPanelDialogueList.Hide();
                    break;
                case 1:                    
                    break;
                case 2:
                    formMain.flowLayoutPanelFriendList.Location = formMain.flowLayoutPanelCompanyList.Location;
                    formMain.flowLayoutPanelFriendList.Size = formMain.flowLayoutPanelCompanyList.Size;
                    formMain.flowLayoutPanelFriendList.Anchor = formMain.flowLayoutPanelCompanyList.Anchor;
                    formMain.flowLayoutPanelFriendList.Show();
                    formMain.flowLayoutPanelCompanyList.Hide();
                    break;
                default:
                    break;
            }
            currentSelectState = 1;
        }

        //公司选项卡被点击
        private void buttonCompany_Click(object sender, EventArgs e)
        {
            FormMain formMain = (FormMain)this.FindForm();
            switch (currentSelectState)
            {
                case 0:
                    formMain.flowLayoutPanelCompanyList.Location = formMain.flowLayoutPanelDialogueList.Location;
                    formMain.flowLayoutPanelCompanyList.Size = formMain.flowLayoutPanelDialogueList.Size;
                    formMain.flowLayoutPanelCompanyList.Anchor = formMain.flowLayoutPanelDialogueList.Anchor;
                    formMain.flowLayoutPanelCompanyList.Show();
                    formMain.flowLayoutPanelDialogueList.Hide();
                    break;
                case 1:
                    formMain.flowLayoutPanelCompanyList.Location = formMain.flowLayoutPanelFriendList.Location;
                    formMain.flowLayoutPanelCompanyList.Size = formMain.flowLayoutPanelFriendList.Size;
                    formMain.flowLayoutPanelCompanyList.Anchor = formMain.flowLayoutPanelFriendList.Anchor;
                    formMain.flowLayoutPanelCompanyList.Show();
                    formMain.flowLayoutPanelFriendList.Hide();
                    break;
                case 2:
                    break;
                default:
                    break;
            }           
            currentSelectState = 2;
        }

    }
}
