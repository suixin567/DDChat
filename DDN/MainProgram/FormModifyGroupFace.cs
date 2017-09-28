using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class FormModifyGroupFace : Form
    {

        #region 属性
        private Image currentImage = null;
        public Image CurrentImage
        {
            get { return currentImage; }
        }
        public SynchronizationContext m_SyncContext = null;
        string m_gid;
        FormShowGroupInfo m_FormShowGroupInfo;
        #endregion


        public FormModifyGroupFace()
        {
            InitializeComponent();
        }

        //构造
        public FormModifyGroupFace(Image oldGroupFace,string gid, FormShowGroupInfo formShowGroupInfo)
        {
            InitializeComponent();
            try
            {
                this.imagePartSelecter1.ImagePartSelected += new ESBasic.CbGeneric<Bitmap>(imagePartSelecter1_ImagePartSelected);
                this.imagePartSelecter1.Initialize(150);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            if (oldGroupFace != null)
            {
                this.imagePartSelecter1.SetSourceImage(oldGroupFace);
            }
          
            m_SyncContext = SynchronizationContext.Current;
            m_gid = gid;
            m_FormShowGroupInfo = formShowGroupInfo;
        }

        private void FormModifyFace_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }

        void imagePartSelecter1_ImagePartSelected(Bitmap obj)
        {
            this.currentImage = obj;
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


        //最小化
        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //关闭
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //浏览图片
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string file = ESBasic.Helpers.FileHelper.GetFileToOpen("请选择要使用的图片");
            if (file == null)
            {
                return;
            }

            Image img = Image.FromFile(file);
            this.imagePartSelecter1.SetSourceImage(img);

        }


        //保存头像
        private void buttonSaveFace_Click(object sender, EventArgs e)
        {
            string responseText;
            UploadPic httpRequestClient = new UploadPic();
            httpRequestClient.SetFieldValue("gid", m_gid);//加数据
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                currentImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                imageBytes = new byte[ms.Length];
                ms.Read(imageBytes, 0, imageBytes.Length);
            }
            httpRequestClient.SetFieldValue("face", "***", "application/octet-stream", imageBytes);
            httpRequestClient.Upload(AppConst.WebUrl + "groupBaseInfo", out responseText);
            Debug.Print("上传结果是" + responseText);
            if (responseText == "true")
            {
                //修改新头像
                m_FormShowGroupInfo.refreshFaceSafePost(currentImage);
                saveOKSafePost();
                //修改本地缓存的头像
                this.currentImage.Save(AppConst.WinPicPath + "group"+ m_gid + ".jpg");
            }
            else
            {
                MessageBox.Show("更改失败！");
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

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            buttonClose_Click(null,null);
        }
    }
}
