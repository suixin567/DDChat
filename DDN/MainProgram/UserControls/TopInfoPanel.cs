using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Drawing2D;
using ToolLib;

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
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBoxTopFace.DisplayRectangle, 0, 360);
            pictureBoxTopFace.Region = new Region(path);

            m_SyncContext = SynchronizationContext.Current;
           
           
                //请求网络数据
                HttpReqHelper.requestSync(AppConst.WebUrl + "baseInfo?username=" + AppInfo.USER_NAME,delegate(string myinfo) {
                    try
                    {
                       AppInfo.PERSONAL_INFO = Coding<PersonalInfoModel>.decode(myinfo);
                        //设置托盘显示内容
                       MainMgr.Instance.formMain.notifyIconFormMain.Text = "叮叮鸟：" + AppInfo.PERSONAL_INFO.Nickname + "（" + AppInfo.PERSONAL_INFO.Username + "）";
                       MainMgr.Instance.formMain.flowLayoutPanelFriendList.InitSelfInfoSafePost(AppInfo.PERSONAL_INFO);
                    }
                    catch (Exception err)
                    {
                        Debug.Print("TopInfoPanel.TopInfoPanel_Load()解析失败" + err.ToString());
                        return;
                    }

                 
                    //初始化昵称Label
                    initNickLabelSafePost();
                    
                    if (AppInfo.PERSONAL_INFO.Face != "")
                    {
                        //请求头像
                        HttpReqHelper.loadFaceSync(AppInfo.PERSONAL_INFO.Face,delegate(Image face) {
                            faceImage = face;
                            if (faceImage != null)
                            {
                                pictureBoxTopFace.Image = faceImage;
                                MainMgr.Instance.SelfFace = faceImage;
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
            }
            else
            {
                this.labelOnlineState.Text = "离线";
                this.labelOnlineState.ForeColor = Color.Red;
                Image tempImage = ImageTool.grayImage(faceImage);
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
