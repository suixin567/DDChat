using MainProgram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolLib;

namespace UnityControl
{
    public partial class FormUnityUpdate : Form
    {

        string unityPath = System.Windows.Forms.Application.StartupPath + @"\Unity";
        string oriSerInfos;
        public SynchronizationContext m_SyncContext = null;


        public FormUnityUpdate()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

       

        private void FormUnityUpdate_Load(object sender, EventArgs e)
        {
            Form formMaim = MainMgr.Instance.formMain;
            int x = formMaim.Location.X;
            int y = formMaim.Location.Y + formMaim.Height;
            this.StartPosition = FormStartPosition.Manual; 
            this.Location = (Point)new Size(x, y);
            this.Width = formMaim.Width;
        }


        public bool checkUpdate()
        {
            oriSerInfos = HttpReqHelper.request("http://192.168.1.101:7788/winUpdate");

            string topUnityVerStr = AnalyzeMFile.Analyze(oriSerInfos, "UnityVersion")[0];
            int topUnityVerson = int.Parse(topUnityVerStr);
            Debug.Print("unity最高版本----------------》" + topUnityVerson);
            int unityVersion = 0;
            //本地版本号
            try
            {
                string unityVersionStr = File.ReadAllText(unityPath + @"\uv.conf");
                unityVersion = int.Parse(unityVersionStr);
            }
            catch (Exception)
            {
                unityVersion = -1;
                //发生错误，直接下载unity
                //FileStream fs1 = new FileStream(System.Windows.Forms.Application.StartupPath + @"\wv.conf", FileMode.Create);
                //fs1.Close();
            }
            Debug.Print("unity本地版本----------------》" + unityVersion);
            if (unityVersion != topUnityVerson)
            {
                this.Show();
                //更新文件
                Thread th = new Thread(new ThreadStart(downLoadUnity));
                th.Start();              
                return false;
            }
            else
            {//不需要更新
                return true;
            }
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

        void downLoadUnity()
        {
            KillProcess("7-Zip Console");
          //  Debug.Print("杀掉进程7-Zip");
            string ip = AnalyzeMFile.Analyze(oriSerInfos, "FilesUrl")[0];
            string url = "http://" + ip + "/res/winUpdateDlls/" + AnalyzeMFile.Analyze(oriSerInfos, "Unity")[0];
            string path = unityPath + @"\temp\" + AnalyzeMFile.Analyze(oriSerInfos, "Unity")[0];
            Debug.Print("下载Unity文件" + url + path);

            HttpReqHelper.downloadFile(url, path, delegate (string err) {
                if (err == null)
                {
                    Debug.Print("下载Unity文件完成了！！！-----------------》》》》》");
                    //删除原文件
                    DirectoryInfo d = new DirectoryInfo(unityPath);
                    FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
                    foreach (FileSystemInfo fsinfo in fsinfos)
                    {
                        Debug.Print("遍历unity下的所有文件" + fsinfo.FullName);
                        if (fsinfo is DirectoryInfo && fsinfo.FullName.EndsWith("temp") == false)     //判断是否为文件夹  
                        {
                            Debug.Print("下载完 删除原有文件" + fsinfo.FullName);
                            try
                            {
                                Directory.Delete(fsinfo.FullName, true);
                                Debug.Print("删除了原unity版本：" + fsinfo.FullName);

                            }
                            catch (Exception deerr)
                            {
                                Debug.Print("删除原unity版本失败！" + deerr.ToString());
                            //    MessageBox.Show("删除旧版本失败");
                            }
                        }
                    }

                    labelProgressSafePost("提取中，请稍后...");
                    //解压
                    Debug.Print("开始解压");
                    string oriPath = unityPath + @"\temp\" + AnalyzeMFile.Analyze(oriSerInfos, "Unity")[0];
                    string disPath = unityPath;
                    try
                    {
                        _7zHelper.DecompressFileToDestDirectory(oriPath, disPath, delegate (string dcerr)
                        {
                            if (dcerr == null)
                            {
                                UnityManager.Instance.ExetUnity();
                            }
                            else
                            {
                                Debug.Print("解压出错！");
                            }
                        });
                        labelProgressSafePost("提取完成，启动中...");
                    }
                    catch (Exception dcerr)
                    {
                        Debug.Print("解压出错"+ dcerr.ToString());
                        MessageBox.Show("解压出错" + dcerr.ToString());
                    }
                   
                   
                    
                    closeSelfSafePost();
                }
            },
            delegate (float progress) {
              //  Debug.Print("下载进度-----------------》》》》》" + progress);
                progressBarSafePost((int)progress);
            }
            );
        }

        public void labelProgressSafePost(string content)
        {
            m_SyncContext.Post(updateLabelProgress, content);
        }

        void updateLabelProgress(object state)
        {
            this.labelProgress.ForeColor = Color.Green;
            this.labelProgress.Text = (string)state;
        }



        public void progressBarSafePost(int progress)
        {
            m_SyncContext.Post(updateProgressBar, progress);
        }

        void updateProgressBar(object state)
        {
            this.progressBar.Value = (int)state;
            this.labelProgress.Text = "玩命加载中..." + (int)state + "%";
        }

        public void closeSelfSafePost()
        {
            Thread.Sleep(2000);
            m_SyncContext.Post(closeSelf, null);
        }

        void closeSelf(object state)
        {
            this.Dispose();
        }


        private void FormUnityUpdate_Paint(object sender, PaintEventArgs e)
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FormUnityUpdate_Load(null, null);
            if (this.Location.Y+ this.Height > System.Windows.Forms.SystemInformation.WorkingArea.Height) {
                this.Location = new Point(this.Location.X , System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Height);
                this.Activate();
            }
        }



    }
}
