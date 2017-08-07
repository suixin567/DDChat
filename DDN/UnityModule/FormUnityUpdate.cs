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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolLib;

namespace UnityModule
{
    public partial class FormUnityUpdate : Form
    {
        IntPtr m_formMainHandle;


        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        //public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        ////   nCmdShow的含义
        ////0    关闭窗口
        ////1    正常大小显示窗口
        ////2    最小化窗口
        ////3    最大化窗口


        string unityPath = System.Windows.Forms.Application.StartupPath + @"\Unity";
        string oriSerInfos;
        public SynchronizationContext m_SyncContext = null;


        public FormUnityUpdate(IntPtr formMainHandle)
        {
            this.m_formMainHandle = formMainHandle;
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

       

        private void FormUnityUpdate_Load(object sender, EventArgs e)
        {
            getFormMian();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;                            
            public int Top;                             
            public int Right;                          
            public int Bottom;                     
        }


        void getFormMian()
        {
            RECT rect = new RECT();
            GetWindowRect(m_formMainHandle, ref rect);
            int width = rect.Right - rect.Left;                 
            int height = rect.Bottom - rect.Top;            
            int x = rect.Left;
            int y = rect.Top;
            this.StartPosition = FormStartPosition.Manual; 
            this.Location = (Point)new Size(x, y+ height);
            this.Width = width;
        }


        public bool checkUpdate()
        {
            oriSerInfos = HttpReqHelper.request(AppConst.WebUrl +"winUpdate");

            string topUnityVerStr = AnalyzeMFile.Analyze(oriSerInfos, "UnityVersion")[0];
            int topUnityVerson = int.Parse(topUnityVerStr);
            Debug.Print("unity最高版本----------------》" + topUnityVerson);
            int unityVersion = -1;
            //本地版本号
            if (File.Exists(@".\wv.conf"))
            {
                string content = File.ReadAllText(@".\wv.conf");
                List<string> temp = AnalyzeMFile.Analyze(content, "UnityVersion");
                if (temp!=null)
                {                   
                    try
                    {
                        string unityVersionStr = temp[0];
                        unityVersion = int.Parse(unityVersionStr);
                    }
                    catch
                    {           
                    }                   
                }                
            }
            else {
                FileStream fs1 = new FileStream(System.Windows.Forms.Application.StartupPath + @".\wv.conf", FileMode.Create);
                fs1.Close();
                Debug.Print("读取Unity配置文件不存在，这不该发生！-------》" + unityVersion);
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
                if (UnityManager.Instance.updateUnityEvent != null)
                {
                    UnityManager.Instance.isUpdateing = false;
                    UnityManager.Instance.updateUnityEvent(true);
                    Debug.Print("不需要更新的");
                }
                return true;
            }
        }


        void downLoadUnity()
        {
            string ip = AnalyzeMFile.Analyze(oriSerInfos, "FilesUrl")[0];
            string filesPath = AnalyzeMFile.Analyze(oriSerInfos, "FilesPath")[0];

            string url = "http://" + ip + "/res/winUpdateDlls/"+ filesPath+"/" + AnalyzeMFile.Analyze(oriSerInfos, "Unity")[0];
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
                    string oriPath = @".\Unity\temp\" + AnalyzeMFile.Analyze(oriSerInfos, "Unity")[0];
                    string disPath = @".\Unity";
                    try
                    {
                        _7zHelper.DecompressFileToDestDirectory(oriPath, disPath, delegate (string dcerr)
                        {
                            if (dcerr == null)//解压成功
                            {
                                //更新版本号！！
                                try
                                {
                                    string versionStr = "";
                                    if (File.Exists(@".\wv.conf"))
                                    {
                                        //读取配置文件
                                        versionStr = System.IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath + @".\wv.conf");
                                    }
                                    else
                                    {
                                        FileStream fs1 = new FileStream(System.Windows.Forms.Application.StartupPath + @".\wv.conf", FileMode.Create);
                                        fs1.Close();
                                        Debug.Print("更新unity版本配置文件失败，这不该发生！");
                                    }

                                    //更新配置文件
                                    string newContent = AnalyzeMFile.AnalyzeSet(versionStr, "UnityVersion", new List<string> { AnalyzeMFile.Analyze(oriSerInfos, "UnityVersion")[0] });
                                    FileStream fs = new FileStream(@".\wv.conf", FileMode.Create);
                                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码               
                                    sw.WriteLine(newContent);
                                    //清空缓冲区
                                    sw.Flush();
                                    //关闭流
                                    sw.Close();
                                    fs.Close();
                                }
                                catch (Exception upErr)
                                {
                                    Debug.Print("更新Unity版本号失败" + upErr);
                                }
                                Debug.Print("更新Unity版本号：" + AnalyzeMFile.Analyze(oriSerInfos, "UnityVersion")[0]);

                                if (UnityManager.Instance.updateUnityEvent != null)  {
                                    UnityManager.Instance.isUpdateing = false;
                                    UnityManager.Instance.updateUnityEvent(true);
                                }
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
                        Debug.Print("解压出错" + dcerr.ToString());
                        MessageBox.Show("解压出错" + dcerr.ToString());
                    }



                    closeSelfSafePost();
                }
                else {
                    MessageBox.Show("下载3D模块失败，请重试。");
                    if (UnityManager.Instance.updateUnityEvent != null)
                    {
                        UnityManager.Instance.isUpdateing = false;
                        UnityManager.Instance.updateUnityEvent(false);
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
