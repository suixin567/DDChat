using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDN.Tools;
using System.Diagnostics;

namespace DDN.UserControls
{
    public partial class AddGroupItem : UserControl
    {

        string m_Name;
        int m_GID;
        string m_Face;


        public AddGroupItem()
        {
            InitializeComponent();
        }

        public AddGroupItem(string name, int gid, string face)
        {
            m_Name = name;
            m_GID = gid;
            m_Face = face;
            InitializeComponent();
        }




        private void AddGroupItem_Load(object sender, EventArgs e)
        {
            this.labelName.Text = m_Name;
            this.labelGid.Text = m_GID.ToString();
            //下载头像
            if (m_Face != "")
            {
                Image image = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + m_Face);
                if (image != null)
                {
                    this.pictureBoxFace.Image = ImageTool.CutEllipse(image);
                }
            }
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            Debug.Print("加入公司");
            if (Manager.Instance.formMain.flowLayoutPanelCompanyList.getGroupList().Contains(m_GID))
            {
                ((FormAddFriend)this.FindForm()).showOpreationResultSafePost("你已经加入这个群了，无需重复加入。");
                return;
            }

            MsgModel mm = new MsgModel(MsgProtocol.ADD_GROUP_CREQ, GameInfo.ACC_ID, m_GID.ToString(), "让我也加入你们吧！", DateTime.Now.ToString());
            Manager.Instance.msgMgr.sendMessage(MsgProtocol.GROUP, mm);
            this.Dispose();
        }
    }
}
