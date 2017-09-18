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

namespace MainProgram.UserControls
{
    public partial class DialogueItem : UserControl
    {
        public DialogueItem()
        {
            InitializeComponent();
        }

        private void DialogueItem_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(PictureBoxDialogueFace.DisplayRectangle, 0, 360);
            PictureBoxDialogueFace.Region = new Region(path);
        }
    }
}
