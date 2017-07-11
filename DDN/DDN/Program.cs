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
            mutex = new System.Threading.Mutex(true, "OnlyRun");
            if (mutex.WaitOne(0, false))
            {
                FormDDN DDN = new FormDDN();
                Application.Run(DDN);
            }
            else
            {               
                Application.Exit();
            }
        }
    }
}
