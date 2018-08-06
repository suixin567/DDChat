using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class FormForget2 : Form
    {
        FormForget3 formForget3;
        public FormForget2(int x, int y)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            int x = this.Location.X;
            int y = this.Location.Y;
            formForget3 = new FormForget3(x, y);
            formForget3.ShowDialog();
        }
    }
}
