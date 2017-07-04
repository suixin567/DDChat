using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DDN.UserControls
{
    public partial class MainTabControl : UserControl
    {
        int currentSelectState = 3;//默认选中朋友列表

        Point oriLocation;
        Size oriSize;
        AnchorStyles OriAnchor;
        FormMain formMain;

        public MainTabControl()
        {
            InitializeComponent();            
        }

        private void MainTabControl_Load(object sender, EventArgs e)
        {
            formMain = Manager.Instance.formMain;
            if (formMain!=null) {
                oriLocation = formMain.flowLayoutPanelFriendList.Location;
                oriSize = formMain.flowLayoutPanelFriendList.Size;
                OriAnchor = formMain.flowLayoutPanelFriendList.Anchor;

                formMain.flowLayoutPanelDialogueList.Location = oriLocation;
                formMain.flowLayoutPanelDialogueList.Size = oriSize;
                formMain.flowLayoutPanelDialogueList.Anchor = OriAnchor;

                formMain.flowLayoutPanelGroupList.Location = oriLocation;
                formMain.flowLayoutPanelGroupList.Size = oriSize;
                formMain.flowLayoutPanelDialogueList.Anchor = OriAnchor;

                formMain.flowLayoutPanelResourcesList.Location = oriLocation;
                formMain.flowLayoutPanelResourcesList.Size = oriSize;
                formMain.flowLayoutPanelResourcesList.Anchor = OriAnchor;
                switchState();
            }       

        }

        //会话选项卡被点击
        private void buttonDialogue_Click(object sender, EventArgs e)
        {
            currentSelectState = 0;
          //  switchState();
        }

        //好友选项卡被点击
        private void buttonFriends_Click(object sender, EventArgs e)
        {
            currentSelectState = 1;
           // switchState();
        }

        //群选项卡被点击
        private void buttonCompany_Click(object sender, EventArgs e)
        {
            currentSelectState = 2;
            switchState();
        }

        //资源
        private void buttonRes_Click(object sender, EventArgs e)
        {
            currentSelectState = 3;
            switchState();
        }

        void switchState() {           

            switch (currentSelectState)
            {
                case 0:
                    formMain.flowLayoutPanelDialogueList.Show();
                    formMain.flowLayoutPanelFriendList.Hide();
                    formMain.flowLayoutPanelGroupList.Hide();
                    formMain.flowLayoutPanelResourcesList.Hide();      
                    break;
                case 1:
                    formMain.flowLayoutPanelDialogueList.Hide();
                    formMain.flowLayoutPanelFriendList.Show();
                    formMain.flowLayoutPanelGroupList.Hide();
                    formMain.flowLayoutPanelResourcesList.Hide();
                    break;
                case 2:
                    formMain.flowLayoutPanelDialogueList.Hide();
                    formMain.flowLayoutPanelFriendList.Hide();
                    formMain.flowLayoutPanelGroupList.Show();
                    formMain.flowLayoutPanelResourcesList.Hide();
                    break;
                case 3:
                    formMain.flowLayoutPanelDialogueList.Hide();
                    formMain.flowLayoutPanelFriendList.Hide();
                    formMain.flowLayoutPanelGroupList.Hide();
                    formMain.flowLayoutPanelResourcesList.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
