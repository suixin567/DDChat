using Dialog;
using MainProgram.UserControls;
using System;
using System.Diagnostics;
using System.Drawing;
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
        public GroupItem m_groupItem;
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
                    FaceMgr.Instance.getFaceByName(model.Face, delegate (Image masterface)
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
        void onGroupModelMotified(int gid,GroupInfoModel mode)
        {
            if (m_groupItem.getGroupMode().Gid == gid)
            {
                setEnterMethodSafePost();
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

        //允许任何人加群被勾选
        private void checkBoxVerifymode1_Click(object sender, EventArgs e)
        {
            if (checkBoxVerifymode1.Checked == true)
            {
                //发送请求
                HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol=3&gid=" + m_groupItem.getGroupMode().Gid + "&method=1", delegate (string result){});
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
                HttpReqHelper.requestSync(AppConst.WebUrl + "groupBaseInfo?protocol=3&gid=" + m_groupItem.getGroupMode().Gid + "&method=0", delegate (string result){});
            }
            else {
                checkBoxVerifymode2.Checked = true;
            }
        }

        //切换选项卡事件
        bool isMemberInited = false;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置选项卡被点击
            if (tabControl1.SelectedIndex==2)
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
            
            //群成员选项卡被点击
            if (tabControl1.SelectedIndex == 1)
            {
                if (isMemberInited==false)
                {
                    //初始化成员列表
                    refreshMembers(m_groupItem.getGroupMode().Gid);
                    isMemberInited = true;
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
        private void buttonOpenDialogue_Click(object sender, EventArgs e)
        {
            FormDialogManager.Instance.openDialog(1, m_groupItem.getGroupMode().Gid, m_groupItem.getGroupMode().Name, pictureBoxFace.Image);
        }



        //刷新群成员列表
        int memberAmount = 0;
        public void refreshMembers(int groupId)
        {
            this.flowLayoutPanelMembers.Controls.Clear();
            //拉取群成员
            HttpReqHelper.requestSync(AppConst.WebUrl + "groupMembers?gid=" + groupId, delegate (string membersJson) {
                //先清空               
               // Debug.Print("收到群成员是：" + membersJson);                
                GroupMembers members = Coding<GroupMembers>.decode(membersJson);
               // Debug.Print("群主是：" + members.Master);
                GroupManageMemberItem master = new GroupManageMemberItem(members.Master,0);
                addMemberSafePost(master);
                memberAmount++;
                //   Debug.Print("管理是：" + members.Manager);
                string[] mans = members.Manager.Split(',');
                foreach (var item in mans)
                {
                    if (item != "")
                    {
                        GroupManageMemberItem manager = new GroupManageMemberItem(item, 1);
                        addMemberSafePost(manager);
                        memberAmount++;
                    }
                }
             //   Debug.Print("成员是：" + members.Member);
                string[] mems = members.Member.Split(',');
                foreach (var item in mems)
                {
                    if (item != "")
                    {
                        GroupManageMemberItem member = new GroupManageMemberItem(item, 2);
                        addMemberSafePost(member);
                        memberAmount++;
                    }
                }

                //this.labelMemberAmount.Text = memberAmount.ToString();
                setAmountSafePost();
            });
        }
        void setAmountSafePost()
        {
            m_SyncContext.Post(setAmount, null);
        }
        void setAmount(object state)
        {            
            this.labelMemberAmount2.Text ="总人数："+ memberAmount.ToString();
        }

        void addMemberSafePost(GroupManageMemberItem item) {
            m_SyncContext.Post(addMember, item);
        }
        void addMember(object state) {                     
            this.flowLayoutPanelMembers.Controls.Add((GroupManageMemberItem)state);
        }


        //添加新成员
        FormInviteToGroup formInviteToGroup;
        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            if (formInviteToGroup == null || formInviteToGroup.IsDisposed)
            {
                formInviteToGroup = new FormInviteToGroup(m_groupItem.getGroupMode().Gid);
                formInviteToGroup.Show();
            }
            else {
                formInviteToGroup.Activate();
            }
        }


        /// ///////////////////////////////////////////////
        /// 工具方法
        /// ///////////////////////////////////////////////
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

    }
}
