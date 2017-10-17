using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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


        static string f1 = @"C:\Users\文强\Desktop\DDN\DDN\DDN\bin\Debug\DDN.exe";
        static string f2 = @"C:\Users\文强\Desktop\DDN\DDN\UpdateProgram\bin\Debug\UpdateProgram.dll";
        static string f3 = @"C:\Users\文强\Desktop\DDN\DDN\Mgr\bin\Debug\Mgr.exe";
        static string f4 = @"C:\Users\文强\Desktop\DDN\DDN\Login\bin\Debug\Login.dll";
        static string f5 = @"C:\Users\文强\Desktop\DDN\DDN\MainProgram\bin\Debug\MainProgram.dll";
        static string f6 = @"C:\Users\文强\Desktop\DDN\DDN\Dialog\bin\Debug\Dialog.dll";
        static string f7 = @"C:\Users\文强\Desktop\DDN\DDN\UnityModule\bin\Debug\UnityModule.dll";
        static string f8 = @"C:\Users\文强\Desktop\DDN\DDN\Standalone\bin\Debug\Standalone.exe";
        static string f9 = @"C:\Users\文强\Desktop\DDN\DDN\ToolLib\bin\Debug\ToolLib.dll";
        string[] dlls = new string[9] { f1,f2,f3,f4,f5,f6, f7, f8,f9 };


  
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            string sourceFile = dlls[0];
            string destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\DDN.exe";
            copy(sourceFile,destinationFile);

            sourceFile = dlls[1];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\UpdateProgram.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[2];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\Mgr.exe";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[3];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\Login.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[4];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\MainProgram.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[5];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\Dialog.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[6];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\UnityModule.dll";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[7];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\Standalone.exe";
            copy(sourceFile, destinationFile);

            sourceFile = dlls[8];
            destinationFile = @"C:\Users\文强\Desktop\DDN_DLLS\ToolLib.dll";
            copy(sourceFile, destinationFile);

            System.Diagnostics.Process.Start(@"C:\Users\文强\Desktop\DDN_DLLS");
            Debug.Print(dlls.Length+"个文件，复制完成...");
        }

        void copy( string sourceFile, string destinationFile) {
            FileInfo file = new FileInfo(sourceFile);
            if (file.Exists)
            {
                file.CopyTo(destinationFile, true);// true is overwrite
                Debug.Print("复制完毕" + destinationFile);
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
    }
}
