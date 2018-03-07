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
using System.Text.RegularExpressions;

namespace Dialog
{
    public partial class ChatPop : UserControl
    {
        public ChatPop()
        {
            InitializeComponent();
        }

        public ChatPop(MsgModel mm)
        {
            InitializeComponent();
            //得到尺寸
      //    Size contentsize =  Calc_PanelWidth(mm.Content);
            this.labelNameAndTime.Text = mm.From + " " + mm.Time;
          this.richTextBoxEx1.Text = mm.Content;
      //    this.richTextBoxEx1.Size =contentsize;
           
        }

        private void ChatPop_Load(object sender, EventArgs e)
        {
            richTextBoxEx1.WordWrap = true;
            richTextBoxEx1.ReadOnly = true;
            richTextBoxEx1.BorderStyle = BorderStyle.None;
            richTextBoxEx1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBoxEx1.ForeColor = Color.FromArgb(255, 255, 255);
            richTextBoxEx1.BackColor = Color.FromArgb(90, 143, 0);

            Bitmap localBitmap = new Bitmap(panelPop.Width, panelPop.Height);
            Graphics bitmapGraphics = Graphics.FromImage(localBitmap);
            bitmapGraphics.Clear(BackColor);
            bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            Draw(panelPop.ClientRectangle, bitmapGraphics, 18, true, 0, Color.FromArgb(90, 143, 0), Color.FromArgb(90, 143, 0));
            panelPop.BackgroundImage = localBitmap;
            richTextBoxEx1.Focus();
        }
        //对话框绘图
        private void Draw(Rectangle rectangle, Graphics g, int _radius, bool cusp, int orientation, Color begin_color, Color end_color)
        {
            int span = 2;
            //抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //渐变填充
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(rectangle, begin_color, end_color, LinearGradientMode.Vertical);
            //画尖角
            if (cusp)
            {
                if (orientation == 0)
                {
                    span = 10;
                    PointF p1 = new PointF(rectangle.Width - 12, rectangle.Y + 10);
                    PointF p2 = new PointF(rectangle.Width - 12, rectangle.Y + 30);
                    PointF p3 = new PointF(rectangle.Width, rectangle.Y + 20);
                    PointF[] ptsArray = { p1, p2, p3 };
                    g.FillPolygon(myLinearGradientBrush, ptsArray);
                    g.FillPath(myLinearGradientBrush, DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - span, rectangle.Height - 1, _radius));
                }
                else
                if (orientation == 1)
                {
                    span = 10;
                    PointF p1 = new PointF(12, rectangle.Y + 10);
                    PointF p2 = new PointF(12, rectangle.Y + 30);
                    PointF p3 = new PointF(0, rectangle.Y + 20);
                    PointF[] ptsArray = { p1, p2, p3 };
                    g.FillPolygon(myLinearGradientBrush, ptsArray);
                    g.FillPath(myLinearGradientBrush, DrawRoundRect(rectangle.X + span, rectangle.Y, rectangle.Width - span, rectangle.Height - 1, _radius));
                }
                else
                {
                    g.FillPath(myLinearGradientBrush, DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - span, rectangle.Height - 1, _radius));
                }
            }
        }
        public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            //四边圆角
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }

        //计算显示框高度和宽度，英文字体和中文以及标点、数字的宽度各不相同，需计算
        private Size Calc_PanelWidth(string mess)
        {
            Size size = new Size();
            //临时建立一个容器装入内容
            RichTextBox canv_Rich = new RichTextBox();
            //先取全部Rtf的值
            canv_Rich.Rtf = mess;
            //再按照Txt判断文字
            //判断中文
            MatchCollection zh = Regex.Matches(canv_Rich.Text, @"[\u4e00-\u9fa5]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //判断中文标点
            MatchCollection zhdot = Regex.Matches(canv_Rich.Text, @"[，。；？~！：‘“”’【】（）]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //判断数字
            MatchCollection en = Regex.Matches(canv_Rich.Text, @"[1234567890]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //其余为英文，并计算总宽度
            size.Width = (zh.Count + zhdot.Count) * 13 + en.Count * 8 + (canv_Rich.Text.Length - zh.Count - zhdot.Count - en.Count) * 7;
            //接收数据内容中是否包含图像
            int havePic = 0;
            havePic = Regex.Matches(canv_Rich.Rtf, "Paint.Picture").Count;
            //加上图像宽度
            size.Width += havePic * 33;
            //判断极值
            if (size.Width > (26 * 13)) { size.Width = 26 * 13; }
            if (size.Width < 40) { size.Width = 40; }
            if (havePic > 0) { size.Height = 33; }
            else { size.Height = 25; }
            return size;
        }
    }
}
