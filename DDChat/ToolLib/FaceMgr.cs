using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;

namespace ToolLib
{
    public class FaceMgr
    {

        #region 单例
        private static FaceMgr instance;
        public static FaceMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FaceMgr();
                }
                return instance;
            }
        }
        #endregion

        #region 属性
        ConcurrentDictionary<string, Image> faceDic = new ConcurrentDictionary<string, Image>();
        //头像被改变事件
        public delegate void ModifyFace(string face,Image newFace);
        public event ModifyFace modifyFaceEvent;
        #endregion


        /// <summary>
        /// 图片缓存
        /// </summary>
        public static List<string> texturesList = new List<string>();//获取到的路径
                                                                     // public delegate void TextureLoadEvent(string err, Texture2D tex);
        public void Init()
        {
            if (Directory.Exists(AppConst.WinPicPath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(AppConst.WinPicPath);
            }
            getAllTextures(AppConst.WinPicPath);
        }
        //获取所有本地图
        public static void getAllTextures(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            //   DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                texturesList.Add(f.FullName.Replace('\\', '/'));//添加文件的路径到列表
            }
        }




        //根据头像名字获取头像图片
        public delegate void RequestPicEvent(Image img);
        public void getFaceByName(string face, RequestPicEvent callBack)
        {
            bool isFaceExit = false;
            foreach (var item in texturesList)
            {
                if (item == null)
                {
                    Debug.Print("item为空");
                    callBack(null);
                    return;
                }
                if (face == null)
                {
                    Debug.Print("face为空");
                    callBack(null);
                    return;
                }
                if (item.EndsWith(face))
                {
                    isFaceExit = true;
                    break;
                }
            }
            if (isFaceExit)
            {
                //   Debug.Print("图片存在，无需下载" + face);
                loadFaceFromLocal(face, callBack);
            }
            else
            {
                //  Debug.Print("图片不存在，网络下载"+ face);
                loadFaceFromNet(face, callBack);
            }
        }


        void loadFaceFromLocal(string face, RequestPicEvent callBack)
        {
            string url = AppConst.WinPicPath + face;
            Image tempImage;
            Func<string, RequestPicEvent, Image> reqPic = loadFaceFromLocalThread;
            IAsyncResult iar = reqPic.BeginInvoke(url, callBack, ar =>
            {
                tempImage = reqPic.EndInvoke(ar);
                if (callBack != null)
                {
                    callBack(tempImage);
                }
            }, reqPic);
        }

        Image loadFaceFromLocalThread(string url, RequestPicEvent callBack)
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(url);
                int filelength = 0;
                filelength = (int)fs.Length; //获得文件长度 
                Byte[] image = new Byte[filelength]; //建立一个字节数组 
                fs.Read(image, 0, filelength); //按字节流读取 
                Image result = Image.FromStream(fs);
                fs.Close();
                return result;
            }
            catch (Exception err)
            {
                Debug.Print("loadFaceFromLocalThread下载图片失败,转为网络下载。" + url + err.ToString());
                int count = url.LastIndexOf("/");
                string face = url.Substring(count);
                loadFaceFromNet(face, callBack);
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        void loadFaceFromNet(string face, RequestPicEvent callBack)
        {

            Image tempImage;
            Func<string, Image> reqPic = loadFaceFromNetThread;
            IAsyncResult iar = reqPic.BeginInvoke(face, ar =>
            {
                tempImage = reqPic.EndInvoke(ar);
                if (callBack != null)
                {
                    callBack(tempImage);
                }
            }, reqPic);
        }

        Image loadFaceFromNetThread(string face)
        {
            string url = AppConst.WebUrl + "res/face/" + face;

            Image image = null;
            Stream resStream = null;
            try
            {
                //    Debug.Print("发出请求图片是：" + url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/octet-stream";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                resStream = response.GetResponseStream();
                image = Image.FromStream(resStream);

                //本地缓存
                image.Save(AppConst.WinPicPath + face);
                if (texturesList.Contains(AppConst.WinPicPath + face) == false)
                {
                    texturesList.Add(AppConst.WinPicPath + face);
                }
                return image;
            }
            catch (Exception err)
            {
                Debug.Print("requestPicThread下载图片失败" + err.ToString());
                return null;
            }
            finally
            {
                if (resStream != null)
                {
                    resStream.Close();
                }
            }
        }



        //强制更新一个群的头像，并广播这个头像改变了。
        public void faceUpdateFace(string faceName)
        {
            loadFaceFromNet(faceName, delegate(Image newFace) {

                //广播更新事件
                if (modifyFaceEvent != null)
                {
                    modifyFaceEvent(faceName,newFace);
                }
            });
          
        }
    }
}
