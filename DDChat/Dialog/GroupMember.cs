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
using ToolLib;

namespace Dialog
{
    public partial class GroupMember : UserControl
    {

        delegate void SetTextCallback(string text);
        delegate void SetImgCallback(Image img);
        private string m_memberUsername;
        private PersonalInfoModel m_mode;
        private Image m_face;

        public GroupMember()
        {
            InitializeComponent();
        }

        public GroupMember(string username, int memberLevel)
        {
            InitializeComponent();
            m_memberUsername = username;
            switch (memberLevel)
            {
                case 2:
                    this.labelLevel.Text = "群主";
                    break;
                case 1:
                    this.labelLevel.Text = "管理员";
                    break;
                case 0:
                    this.labelLevel.Text = "";
                    break;
                default:
                    break;
            }            
         
        }

        private void GroupMember_Load(object sender, EventArgs e)
        {
            if (m_memberUsername == null)
            {
                return;
            }
            //获取昵称与头像
            DataMgr.Instance.getPersonalByID(m_memberUsername, delegate (PersonalInfoModel mode)
            {
                m_mode = mode;
                if (mode.Nickname != null)
                {
                    SetText(mode.Nickname);
                }
                //下载头像
                if (mode.Face != "")
                {
                    FaceMgr.Instance.getFaceByName(mode.Face, delegate (Image face) {
                        if (face != null)
                        {
                            m_face = face;
                            SetImg(face);
                        }
                    });
                }
            });
        }

        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            //Debug.Print(text);
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.labelNickName.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.labelNickName.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.labelNickName.Disposing || this.labelNickName.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(SetText);
                this.labelNickName.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelNickName.Text = text;
            }
        }


        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetImg(Image img)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.pictureBoxFace.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.pictureBoxFace.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.pictureBoxFace.Disposing || this.pictureBoxFace.IsDisposed)
                        return;
                }
                SetImgCallback d = new SetImgCallback(SetImg);
                this.pictureBoxFace.Invoke(d, new object[] { img });
            }
            else
            {
                this.pictureBoxFace.Image = img;
            }
        }
    }
}
