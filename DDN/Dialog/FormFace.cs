using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialog
{
    public partial class FormFace : Form
    {

        FormDialog formDialog;



        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
                 (
                     int nLeftRect,
                     int nTopRect,
                     int nRightRect,
                     int nBottomRect,
                     int nWidthEllipse,
                     int nHeightEllipse
                  );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        public FormFace(FormDialog form)
        {
            m_aeroEnabled = false;
            InitializeComponent();
            formDialog = form;
        }
        private void FormFace_Load(object sender, EventArgs e)
        {
            //显示表情图像
            for (int t = 0; t < 5; t++)
            {
                for (int i = 0; i < 7; i++)
                {
                    PictureBox Ps = new PictureBox();
                    Ps.Size = new Size(32, 32);
                    Ps.SizeMode = PictureBoxSizeMode.Zoom;
                    Ps.Image = Image.FromFile(@"Res\" + ((i + 1) + (t * 7)) + ".png");
                    Ps.Location = new Point(i * 32 + 18 * (i + 1), 15 + (t * 35));
                    Ps.Cursor = Cursors.Hand;
                    Ps.BackColor = Color.Transparent;
                    Ps.Tag = ((i + 1) + (t * 7)) + ".png";
                    Ps.Click += new EventHandler(SmailPic_Click);
                    this.Controls.Add(Ps);
                }
            }
        }


        private void SmailPic_Click(object sender, EventArgs e)
        {
            //向编辑框写入图片
            PictureBox psm = (PictureBox)sender;
            formDialog.Rich_Edit.AddFile(@"Res\" + psm.Tag);
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormFace_FormClosing(object sender, FormClosingEventArgs e)
        {
            //同时只打开一次
            formDialog.formFace = null;
        }
    }

}
