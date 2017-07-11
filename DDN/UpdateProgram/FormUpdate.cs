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

        public void downFiles(string serInfos) {                     
            Debug.Print("被调用");
            m_serInfos = serInfos.Split('\n');
            downLoadDlls();
        }


        void downLoadDlls()
        {
            List<string> ipList = getValue("FilesUrl");            
            List<string> toLoadDlls = getValue("Files");
            Debug.Print("总共需要下载的文件数------》"+ toLoadDlls.Count);
            try
            {
                foreach (var item in toLoadDlls)
                {
                    //下载中
                    labelProgress.Text =  "更新..." + item;
                    labelProgress.Refresh();
                    string url = "http://" + ipList[0] + "/res/winUpdateDlls/" + item;
                    string path = System.Windows.Forms.Application.StartupPath + @"\" + item;
                    HttpDownloadFile(url,path);
                    Thread.Sleep(500);                    
                }
                labelProgress.Text = "更新完成...\n\n启动中...";
                Refresh();
            }
            catch (Exception err)
            {
                Debug.Print("更新文件出错了：" + err);
                MessageBox.Show("更新文件出错...");               
                Environment.Exit(0);
            }

            Thread.Sleep(5000);
            //更新完毕
            List<string> programNameList = getValue("Program");
            Console.WriteLine("FormUpdate更新dll完毕，开启程序");
            openPragram(programNameList[0]);
        }

          


       public static void openPragram(string programName)
        {
            System.Diagnostics.Process process;
            try
            {
                process = new System.Diagnostics.Process();

                Console.WriteLine("FormUpdate启动的程序是" + System.Windows.Forms.Application.StartupPath + @"\" + programName);
                process.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + @"\" + programName;
                process.StartInfo.Arguments = programName; //启动参数 
                process.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("开启主程序错误：" + e);
                MessageBox.Show("发生致命错误，开启主程序错误。");
            }
        }

        private void FormUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        List<string> getValue(string key)
        {
            for (int i = 0; i < m_serInfos.Length; i++)
            {
                if (m_serInfos[i].Contains("[" + key + "]"))
                {
                    List<string> values = new List<string>();
                    //   Console.WriteLine("发现key"+i);
                    for (int j = i + 1; j < m_serInfos.Length; j++)
                    {
                        //      Console.WriteLine("比对中"+j + data[j]);
                        if (m_serInfos[j].Contains("[") == false && m_serInfos[j].Contains("]") == false)
                        {
                            string temp = m_serInfos[j].TrimEnd((char[])"\r".ToCharArray());
                            if (temp.Contains("\r") == false && temp.Contains("\n") == false && temp != string.Empty)
                            {
                                values.Add(temp.Trim());
                                //        Console.WriteLine("找到值" + data[j]);
                            }
                        }
                        else
                        {
                            //         Console.WriteLine("已经到界" + data[j]);
                            break;
                        }
                    }
                    if (values.Count == 0)
                    {
                        Console.WriteLine("错误： 没有找到value!");
                    }
                    return values;
                }
            }
            Console.WriteLine("错误： 没有找到key!");
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
    }
}
