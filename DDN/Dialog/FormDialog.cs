using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityModule;

namespace Dialog
{
    public partial class FormDialog : Form
    {
        #region 属性
        int dialogType = -1;
        int groupOrFriendId = -1;
        string labelTitle = "";
        #endregion

        public FormDialog(int type , int id)
        {
            InitializeComponent();
            dialogType = type;
            groupOrFriendId = id;
        }

        private void FormDialog_Load(object sender, EventArgs e)
        {
            Parent.Resize += new EventHandler(this.resize);          
            switch (dialogType)
            {
                case 0://商城
                    this.labelTitle = "叮叮鸟商城";
                    break;
                case 1://群
                    //请求群信息
                    string groupInfo = HttpReqHelper.request(AppConst.WebUrl + "groupBaseInfo?gid=" + groupOrFriendId);
                    Debug.Print("群信息是" + groupInfo);
                    GroupInfoModel m_groupInfoModel=new GroupInfoModel();
                    try
                    {
                        m_groupInfoModel = Coding<GroupInfoModel>.decode(groupInfo);
                    }
                    catch {
                        Debug.Print("解析群数据失败");
                    }
                    UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
                    this.labelTitle = m_groupInfoModel.Name;
                    break;
                case 2://个人
                    this.labelTitle = "我的资源";
                    break;
                case 3://朋友
                    this.labelTitle = groupOrFriendId.ToString();
                    break;
                default:
                    break;
            }
           
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            switch (dialogType)
            {
                case 0:
                    FormDialogManager.Instance.formShop = null;
                    break;
                case 1:
                    FormDialogManager.Instance.formGroupDictionary.Remove(groupOrFriendId);
                    break;
                case 2:
                    FormDialogManager.Instance.formSelf = null;
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            this.Dispose();
        }


        private void FormDialog_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal) {
            //    FormDialogManager.Instance.Show();
            //    FormDialogManager.Instance.setParent(this);
            //}
        }

        void resize(object sender, EventArgs e)
        {
            if (Parent!=null)
            {
                this.Size = new Size(Parent.Width - 105, Parent.Height - 55);
            }
           
        }
    }
}
