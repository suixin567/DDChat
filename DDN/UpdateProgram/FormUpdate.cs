using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Drawing;

namespace UpdateProgram
{
    public partial class FormUpdate : Form
    {
        string m_serInfoStr;
        string[] m_serInfos;

        public FormUpdate()
        {
            InitializeComponent();
            Show();
            Refresh();
        }


        private void FormUpdate_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }

        public void downFiles(string serInfos)
        {
            Debug.Print(">>>>>>>>>>>>>>>>>>>>>>>>>>> >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>来到更新程序");
            m_serInfoStr = serInfos;
            m_serInfos = serInfos.Split('\n');
            downLoadDlls();
        }


        void downLoadDlls()
        {
            List<string> ipList = getValue(m_serInfoStr,"FilesUrl");
            List<string> pathList = getValue(m_serInfoStr, "FilesPath");
            List<string> toLoadDlls = getValue(m_serInfoStr,"Files");
            Debug.Print("总共需要下载的文件数------》" + toLoadDlls.Count);
            //创建临时文件夹
            DirectoryInfo tempDir = Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\temp");
            Debug.Print("临时文件路径" + tempDir.FullName);
            int count = 0;
            try
            {
                foreach (var item in toLoadDlls)
                {
                    count++;
                    //下载中
                    labelProgress.Text = "更新..." + item + "     " + count + "/" + toLoadDlls.Count;
                    labelProgress.Refresh();
                    string url = "http://" + ipList[0] + "/res/winUpdateDlls/"+ pathList[0]+"/" + item;
                    Debug.Print("更新文件" + "http://" + ipList[0] + "/res/winUpdateDlls/" + pathList[0] + "/" + item);
                    string path = tempDir + @"\" + item;
                    HttpDownloadFile(url, path);
                  //  Thread.Sleep(500);
                }
                //移动功能文件

                List<string> toMoveFiles = toLoadDlls;
                List<string> mianList = getValue(m_serInfoStr,"Main");
                toMoveFiles.Remove(mianList[0]);
                for (int i = 0; i < toMoveFiles.Count; i++)
                {
                    File.Copy(System.Windows.Forms.Application.StartupPath + @"\temp\" + toMoveFiles[i],
                    Application.StartupPath + @"\" + toMoveFiles[i], true);
                    //删除临时文件
                    File.Delete(System.Windows.Forms.Application.StartupPath + @"\temp\" + toMoveFiles[i]);
                }
            }
            catch (Exception err)
            {
                Debug.Print("更新文件出错了：" + err);
                MessageBox.Show("更新文件出错...");
                Environment.Exit(0);
            }
            //更新完毕
            labelProgress.Text = "更新完成...\n\n启动中...";
            Refresh();
            //更新版本号！！
            try
            {
                //读取配置文件
                string versionStr = System.IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"\wv.conf");
                //更新配置文件
                string newContent = AnalyzeSet(versionStr,"Version", new List<string> { getValue(m_serInfoStr, "Version")[0] });         
                string path = @".\wv.conf";
                FileStream fs = new FileStream(path, FileMode.Create);
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
                Debug.Print("更新版本号失败" + upErr);
            }
            Debug.Print("更新版本号：" + getValue(m_serInfoStr, "Version")[0]);

            List<string> programNameList = getValue(m_serInfoStr,"Program");
            Debug.Print("FormUpdate更新dll完毕，开启程序");
            openPragram(programNameList[0]);
        }




        public void openPragram(string programName)
        {
            System.Diagnostics.Process process;
            try
            {
                process = new System.Diagnostics.Process();

                Debug.Print("FormUpdate启动的程序是" + System.Windows.Forms.Application.StartupPath + @"\" + programName);
                process.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + @"\" + programName;
                List<string> mianList = getValue(m_serInfoStr,"Main");
                process.StartInfo.Arguments = mianList[0]; //启动参数 
                process.Start();
            }
            catch (Exception e)
            {
                Debug.Print("开启主程序错误：" + e);
                MessageBox.Show("发生致命错误，开启主程序错误。");
            }
        }

        private void FormUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        List<string> getValue(string content, string key)
        {
            string[] rows = content.Split('\n');
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Contains("[" + key + "]"))
                {
                    List<string> values = new List<string>();
                    //   Debug.Print("发现key"+i);
                    for (int j = i + 1; j < rows.Length; j++)
                    {
                        //      Debug.Print("比对中"+j + data[j]);
                        if (rows[j].Contains("[") == false && rows[j].Contains("]") == false)
                        {
                            string temp = rows[j].TrimEnd((char[])"\r".ToCharArray());
                            if (temp.Contains("\r") == false && temp.Contains("\n") == false && temp != string.Empty)
                            {
                                values.Add(temp.Trim());
                                //        Debug.Print("找到值" + data[j]);
                            }
                        }
                        else
                        {
                            //         Debug.Print("已经到界" + data[j]);
                            break;
                        }
                    }
                    if (values.Count == 0)
                    {
                        Debug.Print("错误： 没有找到value!");
                    }
                    return values;
                }
            }
            Debug.Print("错误： 没有找到key!");
            return null;
        }
        void HttpDownloadFile(string url, string path)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
        }

        string AnalyzeSet(string content, string key, List<string> value)
        {

            string[] serInfos;
            serInfos = content.Split('\n');
            bool isKeyExist = false;
            int keyPosition = -1;
            int nextKeyPosition = -1;
            //先判断key是否存在
            for (int i = 0; i < serInfos.Length; i++)
            {
                if (serInfos[i].Contains("[" + key + "]"))
                {
                    isKeyExist = true;
                    keyPosition = i;
                //    Debug.Print("找到key" + keyPosition);
                }
                if (isKeyExist && i != keyPosition && serInfos[i].Contains("[") && serInfos[i].Contains("]"))
                {//找到了下一个key
                    nextKeyPosition = i;
                //    Debug.Print("找到了下一个key" + nextKeyPosition);
                    break;
                }
            }
            if (isKeyExist)
            {
            //    Debug.Print("存在key模式");
                if (nextKeyPosition == -1)                   //更新最后一个key
                {
                    List<string> newList = new List<string>();
                    for (int i = 0; i <= keyPosition; i++)
                    {
                        newList.Add(serInfos[i]);//原本的值
                    }
                    content = "";
                    foreach (var item in newList)
                    {
                        if (content == "")
                        {
                            content += item;
                        }
                        else
                        {
                            content += "\n" + item;
                        }
                    }
                    bool firstNewValue = true;
                    foreach (var item in value)//加上新值
                    {
                        if (firstNewValue)
                        {
                            content += "\n" + item;
                            firstNewValue = false;
                        }
                        else
                        {
                            content += "\r\n" + item;
                        }

                    }
                }
                else
                {                                          //正常更新，替换两个key之间的所有值
                    List<string> newList = new List<string>();
                    for (int i = 0; i <= keyPosition; i++)
                    {
                        newList.Add(serInfos[i]);//原本前段的值
                    }
                    content = "";
                    foreach (var item in newList)
                    {
                        if (content == "")
                        {
                            content += item;
                        }
                        else
                        {
                            content += "\n" + item;
                        }
                    }
                    bool isFirstNewValue = true;
                    foreach (var item in value)//加上新值
                    {
                        if (isFirstNewValue)
                        {
                            content += "\n" + item;
                            isFirstNewValue = false;
                        }
                        else
                        {
                            content += "\r\n" + item;
                        }
                    }
                    //原本后段的值
                    List<string> newList2 = new List<string>();
                    for (int i = nextKeyPosition; i < serInfos.Length; i++)
                    {
                        newList2.Add(serInfos[i]);//原本后段的值
                    }
                    foreach (var item in newList2)
                    {
                        content += "\n" + item;
                    }
                }
            }
            else
            {
           //     Debug.Print("不存在key模式");
                content += "\r\n[" + key + "]";
                foreach (var item in value)
                {
                    content += "\r\n" + item;
                }
            }
           // Debug.Print("最终文件是\n" + content);
            return content;
        }
    }
}
