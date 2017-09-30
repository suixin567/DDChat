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
            //注册头像被修改的事件
            AppInfo.onPersonalFaceChanged += this.initFaceSafePost;

            //请求网络数据，获取个人信息
            DataMgr.Instance.getPersonalByID(AppInfo.USER_NAME, delegate (PersonalInfoModel model)
            {
                AppInfo.PERSONAL_INFO = model;
                //请求头像
                if (AppInfo.PERSONAL_INFO.Face != "")
                {
                    FaceMgr.Instance.getFaceByName(AppInfo.PERSONAL_INFO.Face, delegate (Image face)
                    {
                        faceImage = face;
                        if (faceImage != null)
                        {
                            AppInfo.SELF_FACE = faceImage;
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
            try
            {
                if (AppInfo.PERSONAL_INFO.Nickname.Length < 5)
                {
                    this.labelSelfNickName.Text = AppInfo.PERSONAL_INFO.Nickname;
                }
                else
                {
                    this.labelSelfNickName.Text = AppInfo.PERSONAL_INFO.Nickname.Substring(0, 4) + "...";
                }

                this.labelSelfDescription.Text = AppInfo.PERSONAL_INFO.Description;
                this.labelOnlineState.Location = new Point(labelSelfNickName.Location.X + labelSelfNickName.Width + 2, labelSelfNickName.Location.Y + 2);
            }
            catch {
              //  MessageBox.Show("1");
            }      
        }


        void initFaceSafePost()
        {
            m_SyncContext.Post(initFace, null);
        }
        void initFace(object state)
        {
            this.pictureBoxTopFace.Image = AppInfo.SELF_FACE;          
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
            try
            {
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
            catch
            {
            }
        }

        //个人资料的主面板
        FormShowPersonalInfo formModifyPersonalInfo = null;
        //头像被点击
        private void pictureBoxTopFace_Click(object sender, EventArgs e)
        {
            if (formModifyPersonalInfo==null || formModifyPersonalInfo.IsDisposed)
            {
                formModifyPersonalInfo = new FormShowPersonalInfo();
                formModifyPersonalInfo.Show();
            }
        }

        Label labelTip = null;
        //鼠标进入头像范围内，则展示资料
        private void pictureBoxTopFace_MouseEnter(object sender, EventArgs e)
        {
            FormInfoCard.Instance.SetPersionalCard(PointToScreen(this.pictureBoxTopFace.Location), AppInfo.PERSONAL_INFO,this.pictureBoxTopFace.Image);
            FormInfoCard.Instance.enterItem("self");

            if (labelTip==null)
            {
                labelTip = new Label();
                ((FormMain)FindForm()).Controls.Add(labelTip);
                labelTip.Text = "点击修改个人资料!";
                labelTip.Size = new Size(110, 20);
                labelTip.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
                labelTip.ForeColor = Color.Black;
                labelTip.TextAlign = ContentAlignment.MiddleCenter;
                labelTip.BackColor = Color.White;
                Point po = new Point(this.Location.X, this.Location.Y + 65);
                labelTip.Location = po;
            }
            labelTip.BringToFront();
            labelTip.Show();
        }


        //鼠标离开后关闭资料展示
        private void pictureBoxTopFace_MouseLeave(object sender, EventArgs e)
        {
            FormInfoCard.Instance.leaveItem("self");
            labelTip.Hide();
        }

     
    }
}
