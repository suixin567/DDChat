using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standalone
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

            mutex = new System.Threading.Mutex(true, "ddnOnlyRun");
            if (mutex.WaitOne(0, false))
            {
                Application.Run(new FormStandalone());
            }
            else
            {
                MessageBox.Show("叮叮鸟离线程序已经在运行，不可以开启多个。", "叮叮鸟提示：");
                Environment.Exit(0);
            }


           
        }
    }
}
