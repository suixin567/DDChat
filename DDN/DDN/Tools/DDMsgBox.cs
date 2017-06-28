using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDN.Tools
{
    public partial class DDMsgBox : Form
    {
        public delegate void OKButtonClick();
        public OKButtonClick oKButtonClick;


        //构造
        public DDMsgBox(Point point, string content ,OKButtonClick _oKButtonClick =null)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = point;         //窗体的起始位置为(x,y)
            oKButtonClick += _oKButtonClick;
            labelMsg.Text = content;         
        }
        //确定事件
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (oKButtonClick!=null) {
                oKButtonClick();
            }
            Dispose();
        }



        public static void Show(Point point, string content, OKButtonClick _oKButtonClick = null)
        {
            DDMsgBox tipBox = new DDMsgBox(point,content,_oKButtonClick);
            tipBox.ShowDialog();
        }

    }
}
