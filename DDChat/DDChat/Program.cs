using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDN
{
    static class Program
    {
        private static System.Threading.Mutex mutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

             
          


            mutex = new System.Threading.Mutex(true, "ddchatOnlyRun");
            if (mutex.WaitOne(0, false)  && System.Diagnostics.Process.GetProcessesByName("DDChatMgr").ToList().Count == 0)
            {
                FormDDChat DDN = new FormDDChat();
                Application.Run(DDN);
            }
            else
            {
               // MessageBox.Show("已经有叮叮鸟程序在运行，不可以开启多个。","叮叮鸟提示"); 
                Application.Exit();
            }
        }
    }
}
