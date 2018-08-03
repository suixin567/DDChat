using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Dialog
{
    public partial class ButtonTab : UserControl
    {

     //   public int m_dialogType;//0商城 1群 2个人
        public string m_id;//特殊id(包含friend和group前缀)
        public string m_dialogTitle;//名字
        public Image m_face;
        public Color oriColor;
        public ButtonTab()
        {
            InitializeComponent();
        }
        //构造
        public ButtonTab(int type,string id,string content,Image face)
        {
            InitializeComponent();
   //         m_dialogType = type;
            m_id = id;
            m_dialogTitle = content;
            this.label.Text = content;
            if (face!=null)
            {
                m_face = face;
                this.pictureBox.Image = m_face;
            }
            oriColor = this.BackColor;
        }

        private void ButtonTab_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(pictureBox.DisplayRectangle, 0, 360);
            pictureBox.Region = new Region(path);

            GraphicsPath path2 = new GraphicsPath();
            path2.AddArc(buttonClose.DisplayRectangle, 0, 360);            
            this.buttonClose.Region = new Region(path2);
            this.buttonClose.Hide();
        }

        //被点击
        private void ButtonTab_Click(object sender, EventArgs e)
        {
            FormDialogManager.Instance.changeActiveWindow(m_id);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            FormDialogManager.Instance.changeActiveWindow(m_id);
        }

        private void label_Click(object sender, EventArgs e)
        {
            FormDialogManager.Instance.changeActiveWindow(m_id);
        }


        //关闭按钮
        private void buttonClose_Click(object sender, EventArgs e)
        {
            FormDialogManager.Instance.closeDialogueWindow(m_id);
        }

        //鼠标进入，显示关闭按钮
        private void ButtonTab_MouseEnter(object sender, EventArgs e)
        {
            var x = FormDialogManager.Instance.splitContainer.Panel1.Width;
            if (x < this.pictureBox.Width*2 + this.pictureBox.Location.X*2 )
            {
                this.buttonClose.Location = new Point(x - this.buttonClose.Width, 0);
            } else {
                this.buttonClose.Location = new Point(x - this.buttonClose.Width*2, this.Size.Height/2 - buttonClose.Height / 2);
            }
         //   this.buttonClose.Location = new Point(FormDialogManager.Instance.splitContainer.Panel1.Width  - buttonClose.Width*2 , this.Size.Height / 2 - buttonClose.Height / 2);
            this.buttonClose.Show();
        }
        //鼠标离开
        private void ButtonTab_MouseLeave(object sender, EventArgs e)
        {
            Point mousePoint = this.Parent.PointToClient(MousePosition);
            if (mousePoint.X <= this.Left || mousePoint.X >= this.Right ||
                mousePoint.Y <= this.Top || mousePoint.Y >= this.Bottom)
            {
                this.buttonClose.Hide();
            }
        }
    }
}
