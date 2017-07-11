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
using System.Threading;

namespace MainProgram.UserControls
{
    public partial class TopInfoPanel : UserControl
    {

        SynchronizationContext m_SyncContext = null;

        private Image faceImage;



        public TopInfoPanel()
        {
            InitializeComponent();            
        }


        private void TopInfoPanel_Load(object sender, EventArgs e)
        {
            m_SyncContext = SynchronizationContext.Current;
            if (PlayerPrefs.GetString("username") != "")
            {
                //圆形头像
                pictureBoxTopFace.Image = ImageTool.CutEllipse(pictureBoxTopFace.Image);
                //请求网络数据
                string myinfo = HttpReqHelper.request(AppConst.WebUrl + "baseInfo?username=" + PlayerPrefs.GetString("username"));
                PersonalInfoModel model = Coding<PersonalInfoModel>.decode(myinfo);
                MainMgr.Instance.BaseInfo = model;
                this.labelSelfNickName.Text = model.Nickname;
                this.labelSelfDescription.Text = model.Description;
                if (model.Face != "")
                {
                    //请求头像
                    faceImage = HttpReqHelper.requestPic(AppConst.WebUrl + "res/face/" + model.Face);
                }
                //在线状态显示
                this.labelOnlineState.Location = new Point(labelSelfNickName.Location.X + labelSelfNickName.Width / 2 + labelOnlineState.Width / 2 + 7, labelSelfNickName.Location.Y + 2);
                NetWorkManager.Instance.offLineEvent += this.offline;
                NetWorkManager.Instance.onLineEvent += this.onLine;
                changeLabelOnline(faceImage);
            }


        }



        //离线事件
        void offline() {
            changeLabelOnlineStateSafePost();
        }
        //上线事件
        void onLine() {
            changeLabelOnlineStateSafePost();
        }

        void changeLabelOnlineStateSafePost() {
            m_SyncContext.Post(changeLabelOnline,null);
        }

        void changeLabelOnline(object state) {
            if (NetWorkManager.Instance.IsConnected)
            {
                this.labelOnlineState.Text = "在线";
                this.labelOnlineState.ForeColor = Color.Lime;
                pictureBoxTopFace.Image = ImageTool.CutEllipse(faceImage);
            }
            else
            {
                this.labelOnlineState.Text = "离线";
                this.labelOnlineState.ForeColor = Color.Red;
                Image tempImage = ImageTool.grayImage(faceImage);
                pictureBoxTopFace.Image = ImageTool.CutEllipse(tempImage);
            }
        }

    }
}
