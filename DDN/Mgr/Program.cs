using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mgr
{
    static class Program
    {
        static bool isDebugModel = false;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (isDebugModel == false)
            {//实际运行
                if (args.Length < 1)
                {
                    Environment.Exit(0);
                }
                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\temp\" + args[0]) == true)
                {
                    while (UpdateMainProgram(args[0]) == false)
                    {
                        //更新主程序                
                        Thread.Sleep(100);
                    }

                }
            }     
 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Manager.Instance.InitApp();
            Application.Run(new FormMgr());
        }

        static bool UpdateMainProgram(string mianProgram) {
            try
            {
                if (mianProgram.Length > 0)
                {
                    Debug.Print("更新主程序" + mianProgram[0]);
                    if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\temp\" + mianProgram) == true)
                    {
                        File.Copy(System.Windows.Forms.Application.StartupPath + @"\temp\" + mianProgram,
                                           Application.StartupPath + @"\" + mianProgram, true);
                        File.Delete(Application.StartupPath + @"\temp\" + mianProgram);
                    }
                }
            }
            catch (Exception)
            {
                return false;
                //Debug.Print("更新主程序错误" + e);
                //MessageBox.Show("更新主程序发生错误！" + e);
            }
            return true;
        }
    }
}
