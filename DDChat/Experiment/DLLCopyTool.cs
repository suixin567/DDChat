using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experiment
{
    public partial class DLLCopyTool : Form
    {
        public DLLCopyTool()
        {
            InitializeComponent();
        }


        static string f1 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\DDChat\bin\Debug\DDChat.exe";
        static string f2 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\UpdateProgram\bin\Debug\UpdateProgram.dll";
        static string f3 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\Mgr\bin\Debug\DDChatMgr.exe";
        static string f4 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\Login\bin\Debug\Login.dll";
        static string f5 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\MainProgram\bin\Debug\MainProgram.dll";
        static string f6 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\Dialog\bin\Debug\Dialog.dll";
    
     //   static string f8 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\Standalone\bin\Debug\Standalone.exe";
        static string f7 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\ToolLib\bin\Debug\ToolLib.dll";
           static string f8 = @"C:\Users\Administrator\Desktop\DDChat\DDChat\UnityModule\bin\Debug\UnityModule.dll";
        string[] dlls = new string[8] { f1,f2,f3,f4,f5,f6, f7,f8};


  
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            string sourceFile = dlls[0];
            string destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\DDChat.exe";
            copy(sourceFile,destinationFile);

            sourceFile = dlls[1];
            destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\UpdateProgram.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[2];
            destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\DDChatMgr.exe";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[3];
            destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\Login.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[4];
            destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\MainProgram.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[5];
            destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\Dialog.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[6];
            destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\ToolLib.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[7];
            destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\UnityModule.dll";
            copy(sourceFile, destinationFile);

            //sourceFile = dlls[7];
            //destinationFile = @"C:\Users\Administrator\Desktop\DDChat_DLLS\Standalone.exe";
            //copy(sourceFile, destinationFile);

            System.Diagnostics.Process.Start(@"C:\Users\Administrator\Desktop\DDChat_DLLS");
            Debug.Print(dlls.Length+"个文件，复制完成...");
        }

        void copy( string sourceFile, string destinationFile) {
            FileInfo file = new FileInfo(sourceFile);
            if (file.Exists)
            {
                file.CopyTo(destinationFile, true);// true is overwrite
                Debug.Print("复制完毕" + destinationFile);
            }
            else {
                Debug.Print("文件不存在"+ file.Name);
            }
        }
      //  int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //i++;
            //this.flowLayoutPanel1.VerticalScroll.Value = 100;
            //Debug.Print(i.ToString());

            Point newPoint = new Point(0, 100000);
            flowLayoutPanel1.AutoScrollPosition = newPoint;
            //newPoint = new Point(0, this.flowLayoutPanel1.Height - flowLayoutPanel1.AutoScrollPosition.Y);
            //flowLayoutPanel1.AutoScrollPosition = newPoint;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //发送消息//winuser.h 中有函数原型定义
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture(); //释放鼠标捕捉winuser.h
    }
}
