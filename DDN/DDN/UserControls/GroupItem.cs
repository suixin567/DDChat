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
    public partial class GroupItem : UserControl
    {
        public MyGroupModel m_myGroupModel;

        public GroupInfoModel m_groupInfoModel;

        public GroupItem()
        {
            InitializeComponent();
        }

        public GroupItem(MyGroupModel myGroupModel)
        {
            if (myGroupModel.GroupID == 0)
            {
                Debug.Print("groupID=0这不该发生" + m_myGroupModel.GroupID);
                Dispose();
                return;
            }

            InitializeComponent();
            m_myGroupModel = myGroupModel;
            //圆形头像
            pictureBoxGroupFace.Image = ImageTool.CutEllipse(pictureBoxGroupFace.Image);
        }


        private void GroupItem_Load(object sender, EventArgs e)
        {
            //获取这个群的基本信息
            string info = HttpReqHelper.request(AppConst.WebUrl + "groupBaseInfo?gid=" + m_myGroupModel.GroupID);
            GroupInfoModel model = Coding<GroupInfoModel>.decode(info);
            m_groupInfoModel = model;

            labelName.Text = model.Name;
           
            //下载头像
            if (model.Face != "")
            {
                Image image = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + model.Face);
                if (image != null)
                {
                    Image newImage = ImageTool.CutEllipse(image);
                    this.pictureBoxGroupFace.Image = newImage;
                }
            }
        }
    
    }
}
