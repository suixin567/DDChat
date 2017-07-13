
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityControl
{
    class UnityManager
    {
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

        #region 属性
        System.Diagnostics.Process process;
        public bool isUnityShow = false;
        public int unityMode = 1;//0为编辑器模式
        public int resourceMode = 0;//资源模式 0：公开商城1：群资源2：个人资源
        public string currentGroup = "";//当前群组
        public int sceneIndex = 4;
        public bool isUpdateing = false;//是否更新中
        #endregion

        public void OpenUnity()
        {
            if (isUnityShow == true)
            {
                return;
            }
            else
            {
                try
                {
                    if (isUpdateing==true) {
                        Debug.Print("Tip : 更新中，请稍后...");
                        return;
                    }
                    isUpdateing = true;
                    FormUnityUpdate formUnityUpdate = new FormUnityUpdate();
                    if (formUnityUpdate.checkUpdate())
                    {
                        Debug.Print("退出更新状态");
 
                        ExetUnity();
                    }
                    else {

                    }
                    Debug.Print("---------------这里几时会运行？函数中开了新线程就会运行");                          
                }
                catch (Exception e)
                {
                    Debug.Print("Unity打开失败！"+e);
                }

            }
        }

        public void ExetUnity() {
            isUpdateing = false;
            process = new System.Diagnostics.Process();
            //if (PlayerPrefs.GetString("unityName") == "")
            //{
            //    unityName = System.Windows.Forms.Application.StartupPath + @"\Unity\DDN.exe";
            //}
            //else {
            //    unityName = System.Windows.Forms.Application.StartupPath + @"\Unity\" + PlayerPrefs.GetString("unityName");
            //    Debug.Print("打开的Unity是：" + unityName);           
            //}
            //var files = Directory.GetFiles(System.Windows.Forms.Application.StartupPath + @"\Unity\");//, " *.exe"
            findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");
            string unityName = exe;
            Debug.Print("要打开的是：" + unityName);
            if (unityName=="") {
                Debug.Print("程序不存在！");
                return;
            }
            process.StartInfo.FileName = unityName;
            process.Start();
            isUnityShow = true;
        }

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
            if (isUnityShow == false && unityMode == 1)
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
