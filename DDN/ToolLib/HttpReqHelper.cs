using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

public class HttpReqHelper
    {

    public static string request(string url)
    {
        string responseString = "";
        try
        {
            //  Debug.Print("发出是：" + url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "textml;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //   Debug.Print("收到的是" + responseString);
        }
        catch (Exception e)
        {
            Debug.Print(e.ToString());
        }
        return responseString;
    }



    public delegate void RequestInfoEvent(string callback);

    public static void requestSync(string url, RequestInfoEvent callBack)
    {
        string responseString = "";
        Func<string, string> reqInfo = requestThread;
        IAsyncResult iar = reqInfo.BeginInvoke(url, ar =>
        {
            responseString = reqInfo.EndInvoke(ar);
            if (callBack !=null)
            {
                callBack(responseString);
            }
        }, reqInfo);    
    }

    static string requestThread(string url)
    {
        string responseString = "";
        try
        {
            Debug.Print("发出是：" + url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "textml;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //   Debug.Print("收到的是" + responseString);
        }
        catch (Exception e)
        {
            Debug.Print(e.ToString());
            return e.ToString();
        }
        Debug.Print("线程收到的数据" + responseString);
        return responseString;
    }


        public static Image requestPic(string url)
        {
        return null;
            Image image=null;
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
                return image;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (resStream != null)
                {
                    resStream.Close();
                }
                // if (image!=null) {
                //    image.Dispose();
                // }
            }
            //image.Save(@"C:/x.JPG", System.Drawing.Imaging.ImageFormat.Jpeg);                        
            //WebClient wc = new WebClient();
            //wc.DownloadFile("http://dotnet.aspx.cc/Images/logoSite.gif", "c:\\xx.gif");
        }


    //文件下载
    public delegate void AssetLoadEvent(string err);
    public delegate void AssetLoadProgress(float progress);


    public static void downloadFile(string url, string path, AssetLoadEvent callback, AssetLoadProgress progress=null)
    {
        Debug.Print("下载Unity的请求" + url);
        int a = path.LastIndexOf('\\');
        string directory = path.Substring(0, a);
        if (File.Exists(directory) == false)
        {
            Directory.CreateDirectory(directory);
        }
        HttpWebRequest request =null;
        HttpWebResponse response =null;
        try
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            response = request.GetResponse() as HttpWebResponse;
        }
        catch (Exception err)
        {
            Debug.Print("下载Unity文件失败" + err.ToString());
            if (callback != null) callback(err.ToString());
            return;
        }
      
        long totalBytes = response.ContentLength;
        Stream responseStream = response.GetResponseStream();
        Stream stream = new FileStream(path, FileMode.Create);
        long totalDownloadedByte = 0;
        try
        {          
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                totalDownloadedByte = size + totalDownloadedByte;
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
                if (progress!=null) {
                    progress((float)totalDownloadedByte / (float)totalBytes * 100);
                }                
                //System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
              //  Thread.Sleep(10);
            }
            stream.Close();
            responseStream.Close();
            //下载成功
            if (callback != null) callback(null);
        }
        catch (Exception e)
        {
            Debug.Print("ToolLib下载文件出错:" + e);
            if (callback != null) callback(e.ToString());
            throw e;
        }
        finally {
            stream.Close();
            responseStream.Close();
        }
     
    }


    /// <summary>  
    /// 创建POST方式的HTTP请求  
    /// </summary>  
    public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int timeout, string userAgent, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                //request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout; 

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //发送POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>
        /// 获取请求的数据
        /// </summary>
        public static string GetResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();

            }
        }
}
