using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityModule;
using System.Drawing.Drawing2D;

namespace Dialog
{
    public partial class ButtonTab : UserControl
    {

        public int m_dialogType;//0商城 1群 2个人
        public string m_id;//特殊id
        public string m_dialogTitle;//名字
        public Image m_face;
        public Color oriColor;
        public ButtonTab()
        {
            InitializeComponent();
        }

        public ButtonTab(int type,string id,string content,Image face)
        {
            InitializeComponent();
            m_dialogType = type;
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
    }
}
