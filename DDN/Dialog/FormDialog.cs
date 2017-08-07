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
        int m_dialogType = -1;
        int m_groupOrFriendId = -1;
        public string m_title = "";
        Image m_face = null;
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
            switch (m_dialogType)
            {
                case 0://商城
                  
                    break;
                case 1://群
                    //请求群信息
                    //string groupInfo = HttpReqHelper.request(AppConst.WebUrl + "groupBaseInfo?gid=" + groupOrFriendId);
                    //Debug.Print("群信息是" + groupInfo);
                    //GroupInfoModel m_groupInfoModel=new GroupInfoModel();
                    //try
                    //{
                    //    m_groupInfoModel = Coding<GroupInfoModel>.decode(groupInfo);
                    //}
                    //catch {
                    //    Debug.Print("解析群数据失败");
                    //}
                    //UnityManager.Instance.currentGroup = m_groupInfoModel.Name;
                  
                    break;
                case 2://个人
                    
                    break;
                case 3://朋友
                   
                    break;
                default:
                    break;
            }           
        }

        //关闭按钮
        //private void buttonClose_Click(object sender, EventArgs e)
        //{
        //    switch (dialogType)
        //    {
        //        case 0:
        //            FormDialogManager.Instance.formShop = null;
        //            break;
        //        case 1:
        //            FormDialogManager.Instance.formGroupDictionary.Remove(groupOrFriendId);
        //            break;
        //        case 2:
        //            FormDialogManager.Instance.formSelf = null;
        //            break;
        //        case 3:
        //            break;
        //        default:
        //            break;
        //    }
        //    this.Dispose();
        //}


        void resize(object sender, EventArgs e)
        {
            if (Parent!=null)
            {
                this.Size = new Size(Parent.Width - 105, Parent.Height - 55);
            }           
        }

        private void FormDialog_Activated(object sender, EventArgs e)
        {
            Debug.Print("我被激活了" + m_title);
        }
    }
}
