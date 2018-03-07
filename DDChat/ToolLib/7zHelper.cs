using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class _7zHelper
{
    // Fields  
    private static string _7zInstallPath = @".\dc.exe";
    public delegate void dcEvent(string err);

    /// <summary>  
    /// 压缩文件夹目录  
    /// </summary>  
    /// <param name="strInDirectoryPath">指定需要压缩的目录，如C:\test\，将压缩test目录下的所有文件</param>  
    /// <param name="strOutFilePath">压缩后压缩文件的存放目录</param>  
    public static void CompressDirectory(string strInDirectoryPath, string strOutFilePath)
    {
        Process process = new Process();
        process.StartInfo.FileName = _7zInstallPath;
        process.StartInfo.Arguments = " a -t7z " + strOutFilePath + " " + strInDirectoryPath + " -r";
        //隐藏DOS窗口  
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.Start();
        process.WaitForExit();
        process.Close();
    }

    /// <summary>  
    /// 压缩文件  
    /// </summary>  
    /// <param name="strInFilePath">指定需要压缩的文件，如C:\test\demo.xlsx，将压缩demo.xlsx文件</param>  
    /// <param name="strOutFilePath">压缩后压缩文件的存放目录</param>  
    public static void CompressFile(string strInFilePath, string strOutFilePath)
    {
        Process process = new Process();
        process.StartInfo.FileName = _7zInstallPath;
        process.StartInfo.Arguments = " a -t7z " + strOutFilePath + " " + strInFilePath + "";
        //隐藏DOS窗口  
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.Start();
        process.WaitForExit();
        process.Close();
    }



    /// <summary>  
    /// 解压缩  
    /// </summary>  
    /// <param name="strInFilePath">压缩文件的路径</param>  
    /// <param name="strOutDirectoryPath">解压缩后文件的路径</param>  
    public static void DecompressFileToDestDirectory(string strInFilePath, string strOutDirectoryPath, dcEvent callBack)
    {
        //  KillProcess("7-Zip Console");
        Process process = new Process();
        try
        {
            process.StartInfo.FileName = _7zInstallPath;
            process.StartInfo.Arguments = " x " + strInFilePath + " -o" + strOutDirectoryPath + " -r -y";
            //隐藏DOS窗口  
            // process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            process.Close();


        }
        catch (Exception e)
        {
            Debug.Print("解压错误!" + e);
            MessageBox.Show("解压出错" + e);
            return;
        }
        finally
        {
            process.Close();
        }
        Debug.Print("解压完了");
        if (callBack != null)
        {
            callBack(null);
        }
        //删除zip
        File.Delete(strInFilePath);
        //   Debug.Print("我的路径是"+ Directory.GetCurrentDirectory());
    }

    /// <summary>
    /// 关闭进程
    /// </summary>
    /// <param name="processName">进程名</param>
    private static void KillProcess(string processName)
    {
        Process[] myproc = Process.GetProcesses();
        foreach (Process item in myproc)
        {
            if (item.ProcessName == processName)
            {
                item.Kill();
            }
        }
    }

}
