using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using ToolLib;

namespace MainProgram.UserControls
{
    public partial class TopInfoPanel : UserControl
    {
        #region 属性
        SynchronizationContext m_SyncContext = null;
        private Image faceImage;
        #endregion

        public TopInfoPanel()
        {
            InitializeComponent();
        
        }       

        private void TopInfoPanel_Load(object sender, EventArgs e)
        {
            faceImage = this.pictureBoxTopFace.Image;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBoxTopFace.DisplayRectangle, 0, 360);
            pictureBoxTopFace.Region = new Region(path);
            m_SyncContext = SynchronizationContext.Current;
            //注册资料被修改的事件
            AppInfo.onPersonalInfoModelChanged += this.initNickLabelSafePost;

            //请求网络数据，获取个人信息
            DataMgr.Instance.getPersonalByID(AppInfo.USER_NAME, delegate (PersonalInfoModel model) {
                AppInfo.PERSONAL_INFO = model;                          
                //请求头像
                if (AppInfo.PERSONAL_INFO.Face != "")
                {                    
                    HttpReqHelper.loadFaceSync(AppInfo.PERSONAL_INFO.Face, delegate (Image face) {
                        faceImage = face;
                        if (faceImage != null)
                        {
                            pictureBoxTopFace.Image = faceImage;
                            //设置自己item的图片
                            MainMgr.Instance.formMain.flowLayoutPanelFriendList.InitSelfFace(faceImage);
                        }
                    });
                }
            });                        
                //在线状态显示               
                NetWorkManager.Instance.offLineEvent += this.offline;
                NetWorkManager.Instance.onLineEvent += this.onLine;
                changeLabelOnline(faceImage);
            
        }


        void initNickLabelSafePost() {
            m_SyncContext.Post(initNickLabel,null);         
        }
        void initNickLabel(object state)
        {
            this.labelSelfNickName.Text = AppInfo.PERSONAL_INFO.Nickname;
            this.labelSelfDescription.Text = AppInfo.PERSONAL_INFO.Description;
            this.labelOnlineState.Location = new Point(labelSelfNickName.Location.X + labelSelfNickName.Width + 7, labelSelfNickName.Location.Y + 2);
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
                pictureBoxTopFace.Image = faceImage;
            }
            else
            {
                this.labelOnlineState.Text = "离线";
                this.labelOnlineState.ForeColor = Color.Red;
                Image tempImage = ImageTool.grayImage(faceImage);
                pictureBoxTopFace.Image = tempImage;
            }
        }

        //个人资料的主面板
        FormShowPersonalInfo formModifyPersonalInfo = null;
        //头像被点击
        private void pictureBoxTopFace_Click(object sender, EventArgs e)
        {
            if (formModifyPersonalInfo==null || formModifyPersonalInfo.IsDisposed)
            {
                formModifyPersonalInfo = new FormShowPersonalInfo(this.pictureBoxTopFace.Image);
                formModifyPersonalInfo.Show();
            }
        }
    }
}
