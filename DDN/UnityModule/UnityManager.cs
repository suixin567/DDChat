
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityModule
{
    public class UnityManager
    {
        #region 单例
        private static UnityManager instance;
        public static UnityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UnityManager();
                }
                return instance;
            }
        }
        #endregion

        #region 属性
        System.Diagnostics.Process process;
        public bool isUnityShow = false;
        public int unityMode = 1;//0为编辑器模式
        public int resourceMode = 0;//资源模式 0：公开商城1：群资源2：个人资源
        public string currentGroup = "";//当前群组
        public int sceneIndex = 4;
        public bool isUpdateing = false;//是否更新中
        public int netMode = 0;//网络模式，0为正常模式，1为离线模式
        public IntPtr formMainHandle;
        public IntPtr unityHandle;
        #endregion

        public void OpenUnity()
        {
            Debug.Print("打开Unity的请求");
            if (isUnityShow == true)
            {
                return;
            }
            if (netMode == 0)//联网模式
            {
                try
                {
                    if (isUpdateing == true)
                    {
                        Debug.Print("Tip : 更新中，请稍后...");
                        return;
                    }
                    isUpdateing = true;
                    FormUnityUpdate formUnityUpdate = new FormUnityUpdate(formMainHandle);
                    if (formUnityUpdate.checkUpdate())
                    {
                        ExetUnity();
                    }
                }
                catch (Exception e)
                {
                    Debug.Print("Unity打开失败！" + e);
                }
            } else {//单机模式
                ExetUnity();
            }
        }


        public void ExetUnity() {
            isUpdateing = false;/////////////////////////////////////////////有问题！！！
            process = new System.Diagnostics.Process();
            try
            {
                findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");
                Debug.Print("准备打开Unity客户端：" + exe);
                process.StartInfo.FileName = exe;
                process.Start();
                isUnityShow = true;
                unityHandle = process.Handle;
            }
            catch (Exception err)
            {
                Debug.Print("打开Unity失败" + err.ToString());
                MessageBox.Show("3D展示模块不存在！\n请先下载3D模块。", "叮叮鸟提示：");
            }           
        }


        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);


        static string exe = "";
        static void findExe(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
              //  Debug.Print("遍历顺序" + fsinfo.FullName);
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹  
                {
                    findExe(fsinfo.FullName);//递归调用  
                }
                else
                {
                //    Debug.Print("遍历中" + fsinfo.FullName);
                    if (fsinfo.FullName.EndsWith(".exe")) {
               //         Debug.Print("找到exe了" + fsinfo.FullName);
                        exe = fsinfo.FullName;
                        return;                
                    }
                }
            }            
        }


        public void CloseUnity()
        {
            isUnityShow = false;
            try
            {
                process.Kill();
                process.Dispose();

            }
            catch
            {
            }
        }

        //切换Unity场景
        public void changeUnityScene(int scene)
        {
            sceneIndex = scene;
            if (isUnityShow == false)//&& unityMode == 1
            {
                UnityManager.Instance.OpenUnity();
            }
            else
            {
                ServerForUnity.Instance.SendMessage(UnityProtocol.SCENE, sceneIndex, 0, "");
            }
        }
    }
}
