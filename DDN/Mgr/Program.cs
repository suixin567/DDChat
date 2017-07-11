using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mgr
{
    static class Program
    {
        static bool isDebugModel = true;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (isDebugModel==false) {
                if (args.Length < 1)
                {
                    Environment.Exit(0);
                }
            }
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Manager.Instance.InitApp();
            Application.Run(new FormMgr());
        }
    }
}
