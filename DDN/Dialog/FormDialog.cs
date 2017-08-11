using SmileWei.EmbeddedApp;
using System;
using System.Drawing;
using System.Windows.Forms;
using UnityModule;

namespace Dialog
{
    public partial class FormDialog : Form
    {
        #region 属性
        int m_dialogType = -1;
        int m_groupOrFriendId = -1;
        public string m_title = "";
        Image m_face = null;
        public int UIState = 1;//对话窗的UI模式，0代表展示资源的状态，1代表聊天状态 ,2代表绘制状态
        #endregion

        public FormDialog(int type , int dialogId, string dialogName, Image face)
        {
            InitializeComponent();
            m_dialogType = type;
            m_groupOrFriendId = dialogId;
            m_title = dialogName;
            this.m_face = face;


        }

        private void FormDialog_Load(object sender, EventArgs e)
        {
            Parent.Resize += new EventHandler(this.resize);
            //根据窗体类型 设置toppanel的按钮        
            switch (m_dialogType)
            {
                case 0://商城
                    break;
                case 1://群
                    break;
                case 2://个人
                    this.labelChat.Dispose();
                    break;
                case 3://朋友                   
                    break;
                default:
                    break;
            }
            labelChat.BackColor = Color.SteelBlue;
        }


        void resize(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                this.Size = new Size(Parent.Width - 105, Parent.Height - 50 - 3);
            }
            switch (m_dialogType)
                {
                    case 0:
                        if (this.Size.Width > 300 && this.Size.Height > 200)
                        {
                            FormDialogManager.Instance.appContainer.Size = this.Size;
                        }
                        break;
                    case 1://群
                        if (this.Size.Width > 300 && this.Size.Height > 200)
                        {
                            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
                        }
                        break;
                    case 2:
                        if (this.Size.Width > 300 && this.Size.Height > 200)
                        {
                            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
                        }
                        break;
                    default:
                        break;
                }
        }

        
        private void buttonRes_Click(object sender, EventArgs e)
        {
          
        }

        
        private void buttonChat_Click(object sender, EventArgs e)
        {
        
        }


        private void buttonDraw_Click(object sender, EventArgs e)
        {
         
        }

        //设置激活窗体时触发
        private void FormDialog_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible==false)
            {
                return;
            }
            switch (m_dialogType)
            {
                case 0:
                    this.flowLayoutPanelTop.Hide();
                    this.panelChat.Hide();
                    FormDialogManager.Instance.appContainer.Show();
                    FormDialogManager.Instance.appContainer.Location = this.Location;
                    UnityManager.Instance.resourceMode = 0;
                    UnityManager.Instance.changeUnityScene(4);
                    break;
                case 1:
                    FormDialogManager.Instance.appContainer.Hide();
                    UnityManager.Instance.currentGroup = m_title;
                    UnityManager.Instance.resourceMode = 1;
                    if (UIState == 0)//资源
                    {
                        FormDialogManager.Instance.appContainer.Show();
                        FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                        UnityManager.Instance.changeUnityScene(4);
                    }
                    else if (UIState == 1)//聊天
                    {
                        this.panelChat.Show();
                        FormDialogManager.Instance.appContainer.Hide();
                    }
                    else//绘制
                    {
                        FormDialogManager.Instance.appContainer.Show();
                        FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                        UnityManager.Instance.changeUnityScene(3);
                    }
                    break;
                case 2://个人
                    this.panelChat.Hide();
                    UnityManager.Instance.resourceMode = 2;
                    FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
                    FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
                    FormDialogManager.Instance.appContainer.Show();
                    UnityManager.Instance.changeUnityScene(4);
                    break;
                default:
                    break;
            }
            resize(null,null);
        }

        //聊天选项卡
        private void labelChat_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanelTop.Controls)
            {
                ((Label)item).BackColor = Color.Transparent;
            }
            labelChat.BackColor = Color.SteelBlue;
            UIState = 1;
            panelChat.Show();
            FormDialogManager.Instance.appContainer.Hide();
        }
        //资源选项卡
        private void labelRes_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanelTop.Controls)
            {
                ((Label)item).BackColor = Color.Transparent;
            }
            labelRes.BackColor = Color.SteelBlue;
            UIState = 0;
            panelChat.Hide();
            UnityManager.Instance.changeUnityScene(4);
            FormDialogManager.Instance.appContainer.Show();
            FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
        }

        //画房子选项卡
        private void labelDraw_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanelTop.Controls)
            {
                ((Label)item).BackColor = Color.Transparent;
            }
            labelDraw.BackColor = Color.SteelBlue;
            UIState = 2;
            panelChat.Hide();
            UnityManager.Instance.changeUnityScene(3);
            FormDialogManager.Instance.appContainer.Show();
            FormDialogManager.Instance.appContainer.Location = new Point(this.Location.X, this.Location.Y + this.flowLayoutPanelTop.Height);
            FormDialogManager.Instance.appContainer.Size = this.panelChat.Size;
        }
    }
}