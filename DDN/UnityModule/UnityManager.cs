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
        public int resourceMode = 0;//资源模式 0：公开商城1：群资源2：个人资源
        public string currentGroup = "";//当前群组
        public int sceneIndex = 4;
        public bool isUpdateing = false;//是否更新中
        public int netMode = 0;//网络模式，0为正常模式，1为离线模式
        public IntPtr unityHandle;
        #endregion



        public delegate void UpdateUnityEvent(bool result);
        public UpdateUnityEvent updateUnityEvent;//unity更新完成事件

        public delegate void OpenedUnityEvent();
        public OpenedUnityEvent openedUnityEvent;//unity启动事件


        //检查是否需要更新
        public void checkUpdate(IntPtr  formHandle)
        {            
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
        }


        //切换Unity场景
        public void changeUnityScene(int scene)
        {
            if (isUnityShow ==true)
            {
                sceneIndex = scene;
                ServerForUnity.Instance.SendMessage(UnityProtocol.SCENE, sceneIndex, 0, "");
            }              
        }

        public void UnityOpened() {
            if (openedUnityEvent!=null)
            {
                openedUnityEvent();
            }           
        }
    }
}
