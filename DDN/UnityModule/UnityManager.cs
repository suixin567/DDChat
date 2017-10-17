using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
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
        public bool isUnityShow = false;
        public int unityMode = 1;//0为编辑器模式
        public bool isUpdateing = false;//是否更新中
        public int netMode = 0;//网络模式，0为正常模式，1为离线模式
        public IntPtr unityHandle;
        static string exe = "";
        System.Diagnostics.Process process;
        public delegate void UpdatedUnityEvent(bool result);
        public UpdatedUnityEvent updatedUnityEvent;//unity更新完毕的事件

        public delegate void OpenedUnityEvent();
        public OpenedUnityEvent openedUnityEvent;//unity已经打开事件
        #endregion


        //打开unity
        public void openUnity(IntPtr formHandle) {

            if (isUnityShow)
            {
                return;
            }
            //unity检查更新
            UnityManager.Instance.updatedUnityEvent += this.exetUnity;//更新完毕以后启动unity。
            //  UnityManager.Instance.openedUnityEvent += this.onUnityOpened;//unity已经打开，可以嵌入了。
            //检查是否需要更新
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
                    FormUnityUpdate formUnityUpdate = new FormUnityUpdate(formHandle);
                    formUnityUpdate.checkUpdate();
                }
                catch (Exception e)
                {
                    Debug.Print("Unity打开失败！" + e);
                }
            }
        }


        public void CloseUnity()
        {
            isUnityShow = false;
            UnityManager.Instance.updatedUnityEvent -= this.exetUnity;//更新完毕以后启动unity。                     
        }



        static void findExe(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹  
                {
                    findExe(fsinfo.FullName);//递归调用  
                }
                else
                {
                    if (fsinfo.FullName.EndsWith(".exe"))
                    {
                        exe = fsinfo.FullName;
                        return;
                    }
                }
            }
        }

        public void exetUnity(bool result)
        {
            if (result ==false)
            {
                return;
            }
            process = new System.Diagnostics.Process();       
            findExe(System.Windows.Forms.Application.StartupPath + @"\Unity");            
            Debug.Print("要打开的是：" + exe);
            if (exe == "")
            {
                Debug.Print("程序不存在！");
                return;
            }
            process.StartInfo.FileName = exe;
            process.Start();
            isUnityShow = true;
        }






        ////切换Unity场景
        //public void changeUnityScene(int scene)
        //{
        //    if (isUnityShow ==true)
        //    {
        //        sceneIndex = scene;
        //        ServerForUnity.Instance.SendMessage(UnityProtocol.SCENE, sceneIndex, 0, "");
        //    }              
        //}

        //unity发来的，已经启动完毕
        //public void UnityOpened() {
        //    if (openedUnityEvent!=null)
        //    {
        //        openedUnityEvent();
        //    }           
        //}
    }
}
