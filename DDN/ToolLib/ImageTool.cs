using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ImageTool
    {

        public static Image grayImage(Image image)
        {
            int Height = image.Height;
            int Width = image.Width;
            Bitmap bitmap = new Bitmap(Width, Height);
            Bitmap MyBitmap = (Bitmap)image;
            Color pixel;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    pixel = MyBitmap.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    //实例程序以加权平均值法产生黑白图像  
                    int iType = 2;
                    switch (iType)
                    {
                        case 0://平均值法  
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法  
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法  
                            Result = ((int)(0.7 * r) + (int)(0.2 * g) + (int)(0.1 * b));
                            break;
                    }
                    bitmap.SetPixel(x, y, Color.FromArgb(Result, Result, Result));
                }
            return bitmap;
        }


        //绘制圆图片
        public static Image CutEllipse(Image img)
        {
        if (img == null)
        {
            return null;
        }
            Rectangle rec = new Rectangle(0, 0, img.Width, img.Height);
            Size size = new Size(62, 62);
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            return bitmap;
        }
    }

