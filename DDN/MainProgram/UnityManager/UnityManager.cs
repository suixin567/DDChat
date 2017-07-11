
using System;
using System.Collections.Generic;
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
                    process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = @"E:\build\叮叮鸟.exe"; //"输入完整的路径"
                    process.StartInfo.Arguments = "叮叮鸟.exe"; //启动参数 
                    process.Start();
                    isUnityShow = true;
                }
                catch (Exception)
                {
                    throw;
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
