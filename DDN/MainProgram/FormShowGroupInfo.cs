using Dialog;
using MainProgram.UserControls;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ToolLib;

namespace MainProgram
{
    public partial class FormShowGroupInfo : Form
    {

        #region 属性
        SynchronizationContext m_SyncContext = null;
        Image m_Face;
        GroupItem m_groupItem;
        #endregion

        public FormShowGroupInfo()
        {
            InitializeComponent();
        }

        //群资料时调用
        public FormShowGroupInfo(GroupInfoModel groupModel, Image face, GroupItem groupItem)
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            m_Face = face;
            m_groupItem = groupItem;
            DataMgr.Instance.modifyGroupInfoEvent += this.onGroupModelMotified;
        }

        private void FormModifyPersonalInfo_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width/2 - this.Size.Width/2);
            int y = (SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            this.labelNickName.Text = m_groupItem.getGroupMode().Name;
            this.labelUsername.Text = m_groupItem.getGroupMode().Gid.ToString();
            this.labelCreatedtime.Text = m_groupItem.getGroupMode().Createdtime;
            this.textBoxDescription.Text = m_groupItem.getGroupMode().Description;
            this.pictureBoxFace.Image = m_Face;
            this.pictureBoxMasterFace.Image = null;//群主头像

            DataMgr.Instance.getPersonalByID(m_groupItem.getGroupMode().Master, delegate (PersonalInfoModel model)
            {
                SetMasterLabel(model.Nickname);
                if (model.Face != "" && model.Face != null) //下载群主头像
                {
                    HttpReqHelper.loadFaceSync(model.Face, delegate (Image masterface)
                    {
                        if (masterface != null)
                        {
                            SetMasterFace(masterface);
                        }
                    });
                }
            });
            //成员数量
            int membersAmount = 0;
            string[] manarr = m_groupItem.getGroupMode().Manager.Split(',');
            foreach (var item in manarr)
            {
                if (item != "")
                {
                    membersAmount++;
                }
            }
            string[] memarr = m_groupItem.getGroupMode().Member.Split(',');
            foreach (var item in memarr)
            {
                if (item != "")
                {
                    membersAmount++;
                }
            }
            membersAmount++;//算上群主
            this.labelMemberAmount.Text = membersAmount.ToString();
          
            //判断是不是群主，群主才可以修改资料
            if (m_groupItem.getGroupMode().Master != AppInfo.PERSONAL_INFO.Username)
            {
                this.labelModify.Hide();
                this.labelChangeFace.Hide();
            }
        }

        //当群模型被改变
        void onGroupModelMotified(int gid)
        {
            if (m_groupItem.getGroupMode().Gid == gid)
            {              
            }
        }

            //跨线程设置群主信息
            delegate void AppendValueDelegate(string strValue);
        public void SetMasterLabel(string strValue)
        {
            this.labelMaster.BeginInvoke(new AppendValueDelegate(MasterLabel), new object[] { strValue });
        }
        private void MasterLabel(string strValue)
        {
            this.labelMaster.Text = strValue;
        }
        //跨线程设置群主头像
        delegate void MasterFaceDelegate(Image masterFace);
        public void SetMasterFace(Image masterFace)
        {
            this.pictureBoxMasterFace.BeginInvoke(new MasterFaceDelegate(MasterFace), new object[] { masterFace });
        }
        private void MasterFace(Image masterFace)
        {
            this.pictureBoxMasterFace.Image = masterFace;
        }



        //修改    群资料按钮被点击
        FormModifyGroupInfo formModifyGroupInfo = null;
        private void labelModify_Click(object sender, EventArgs e)
        {
            if (formModifyGroupInfo == null || formModifyGroupInfo.IsDisposed)
            {
                formModifyGroupInfo = new FormModifyGroupInfo(m_groupItem.getGroupMode(), this);
                formModifyGroupInfo.Show();
            }
            else {
                formModifyGroupInfo.Activate();
            }
        }


        //点击修改头像
        FormModifyGroupFace formModifyGroupFace = null;
        private void pictureBoxFace_Click(object sender, EventArgs e)
        {

            if (m_groupItem.getGroupMode().Master != AppInfo.PERSONAL_INFO.Username)
            {
                return;
            }

            if (formModifyGroupFace == null || formModifyGroupFace.IsDisposed)
            {
                formModifyGroupFace = new FormModifyGroupFace(this.pictureBoxFace.Image, m_groupItem.getGroupMode().Gid,this);
                formModifyGroupFace.Show();
            }
            else
            {
                formModifyGroupFace.Activate();
            }
        }
        private void labelChangeFace_Click(object sender, EventArgs e)
        {
            pictureBoxFace_Click(null, null);
        }


        //刷新展示内容
        public void refreshSafePost(GroupInfoModel newGroupModel)
        {
            m_SyncContext.Post(refresh, newGroupModel);
        }
        void refresh(object state)
        {
            GroupInfoModel newGroupModel = (GroupInfoModel)state;
            this.labelNickName.Text = newGroupModel.Name;
            this.textBoxDescription.Text = newGroupModel.Description;
        }

        //头像被修改后要 刷新头像
       public void refreshFaceSafePost(Image newFace)
        {
            m_SyncContext.Post(refreshFace, newFace);
        }
        void refreshFace(object state)
        {
            this.pictureBoxFace.Image = (Image)state;           
        }




        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormModifyPersonalInfo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        //关闭面板
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //最小化
        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonOpenDialogue_Click(object sender, EventArgs e)
        {
            FormDialogManager.Instance.openDialog(1, m_groupItem.getGroupMode().Gid, m_groupItem.getGroupMode().Name, pictureBoxFace.Image);
        }



        //允许任何人加群被勾选
        private void checkBoxVerifymode1_Click(object sender, EventArgs e)
        {
            if (checkBoxVerifymode1.Checked == true)
            {
                //发送请求
                HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol=3&gid=" + m_groupItem.getGroupMode().Gid + "&method=1", delegate (string result)
                {
                    if (result == "true")
                    {
                        //请求成功    
                        GroupInfoModel newModel = m_groupItem.getGroupMode();
                        newModel.Verifymode = 1;                       
                        DataMgr.Instance.modifyGroupInfo(newModel);
                        setEnterMethodSafePost();
                    }
                    else
                    {
                    }
                });
            }
            else {
                checkBoxVerifymode1.Checked = true;
            }         
        }

        //需要群主验证被勾选
        private void checkBoxVerifymode2_Click(object sender, EventArgs e)
        {
            if (checkBoxVerifymode2.Checked == true)
            {
                //发送请求
                HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol=3&gid=" + m_groupItem.getGroupMode().Gid + "&method=0", delegate (string result)
                {
                    if (result == "true")
                    {
                        //请求成功
                        GroupInfoModel newModel = m_groupItem.getGroupMode();
                        newModel.Verifymode = 0;
                        DataMgr.Instance.modifyGroupInfo(newModel);
                        setEnterMethodSafePost();
                    }
                    else
                    {
                    }
                });
            }
            else {
                checkBoxVerifymode2.Checked = true;
            }
        }

        //切换选项卡事件
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex==2)//设置选项卡被点击
            {
                if (m_groupItem.getGroupMode().Master == AppInfo.PERSONAL_INFO.Username)//自己是群主
                {
                    this.labelVerifymode.Hide();
                    setEnterMethodSafePost();
                }
                else {//不是群主，不可编辑
                    checkBoxVerifymode1.Hide();
                    checkBoxVerifymode2.Hide();
                    this.labelVerifymode.Location = checkBoxVerifymode1.Location;
                    if (m_groupItem.getGroupMode().Verifymode == 0)
                    {
                        this.labelVerifymode.Text = "需要群主验证";                        
                    }
                    else
                    {
                        this.labelVerifymode.Text = "允许任何人加入";
                    }
                }
            }
        }

        //设置进群方式
        public void setEnterMethodSafePost()
        {
            m_SyncContext.Post(setEnterMethod, null);
        }
        void setEnterMethod(object state)
        {
            if (m_groupItem.getGroupMode().Verifymode == 0)
            {
                checkBoxVerifymode1.Checked = false;
                checkBoxVerifymode2.Checked = true;
            }
            else
            {
                checkBoxVerifymode1.Checked = true;
                checkBoxVerifymode2.Checked = false;
            }
        }
    }
}
