﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ToolLib;

namespace MainProgram
{
    public partial class FormModifyGroupInfo : Form
    {
        #region 属性
        string oldNickName;
        string oldBoxDisc;
        public SynchronizationContext m_SyncContext = null;
        FormShowGroupInfo m_FormShowGroupInfo;
        GroupInfoModel m_groupModel;
        #endregion


        public FormModifyGroupInfo(GroupInfoModel groupModel, FormShowGroupInfo formShowGroupInfo)
        {
            InitializeComponent();
            this.textBoxNickName.Text = groupModel.Name;
            this.textBoxDisc.Text = groupModel.Description;
            oldNickName = this.textBoxNickName.Text;
            oldBoxDisc = this.textBoxDisc.Text;
            m_SyncContext = SynchronizationContext.Current;
            m_FormShowGroupInfo = formShowGroupInfo;
            m_groupModel = groupModel;
        }


        private void FormModifyPersionalInfo_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }



        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormModifyPersionalInfo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
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

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose2_Click(object sender, EventArgs e)
        {
            buttonClose_Click(null,null);
        }


        //保存修改按钮
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxNickName.Text != oldNickName || this.textBoxDisc.Text != oldBoxDisc)
            {
                string url = AppConst.WebUrl + "groupBaseInfo?protocol="+HttpGroupProtocol.MODIFY_GROUP_BASE_INFO+"&gid=" + m_groupModel.Gid + "&name=" + this.textBoxNickName.Text + "&description=" + this.textBoxDisc.Text;
//                Debug.Print(url);
                HttpReqHelper.requestSync(url, delegate (string result)
                {
               
                    if (result == "true")
                    {
                        //修改模型
                        m_groupModel.Name = this.textBoxNickName.Text;
                        m_groupModel.Description = this.textBoxDisc.Text;
                        m_FormShowGroupInfo.refreshSafePost(m_groupModel);  
                        ////广播最新的群模型给所有群员               
                        //string message = Coding<GroupInfoModel>.encode(m_groupModel);
                        //NetWorkManager.Instance.sendMessage(Protocol.SETTING, -1, 0, message);
                        saveOKSafePost();
                    }
                    else
                    {
                        Debug.Print("修改失败");
                    }
                });
            }
        }

        public void saveOKSafePost()
        {
            m_SyncContext.Post(saveOK, null);
        }
        void saveOK(object state)
        {
            //刷新个人信息展示面板
            this.Close();
            this.Dispose();
        }
    }
}
