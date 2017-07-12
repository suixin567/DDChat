using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDN
{
    public partial class FormDDN : Form
    {


        bool debugModel = false;
        static string ip = "192.168.1.101:7788";
        string oriSerInfos;
        string[] serInfos;
        public SynchronizationContext m_SyncContext = null;

        public FormDDN()
        {
            InitializeComponent();        
        }

        

        private void FormDDN_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width / 2 - this.Size.Width / 2);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height / 2 - this.Size.Height / 2);
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
            m_SyncContext = SynchronizationContext.Current;
            Thread showOrHide = new Thread(new ThreadStart(startHide));
            Init();
        }
        void startHide() {
            hideFormSafePost();
        }



        public void Init()
        {
            string response = requestFromServer("http://" + ip + "/winUpdate");
            oriSerInfos = response;
            serInfos = response.Split('\n');
            int topVersion = -1;

            List<string> topVersionList = getValue("Version");
            topVersion = int.Parse(topVersionList[0]);
            Console.WriteLine("topVersion是--------》:" + topVersion);
            int WinformVersion = 0;
            try
            {
                string versionStr = System.IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"\wv.conf");
                WinformVersion = int.Parse(versionStr);
            }
            catch (Exception)
            {
                //发生错误
                FileStream fs1 = new FileStream(System.Windows.Forms.Application.StartupPath + @"\wv.conf", FileMode.Create);
                fs1.Close();
            }
            Console.WriteLine("WinformVersion是--------》:" + WinformVersion);
            if (WinformVersion != topVersion)
            {
                //就需要更，显示出来
                showFormSafePost();

                //更新文件

                Thread th = new Thread(new ThreadStart(UpdateFormUpdate));
                th.Start();
            }
            else//不需要更新
            {
                List<string> programNameList = getValue("Program");
                openPragram(programNameList[0]);
            }
        }


        void UpdateFormUpdate()
        {
            Thread.Sleep(2000);
            List<string> UpdateDllList = getValue("Update");
            
            for (int i = 0; i < UpdateDllList.Count; i++)
            {
                string url = "http://" + ip + "/res/winUpdateDlls/" + UpdateDllList[i];
                string path = System.Windows.Forms.Application.StartupPath + @"\" + UpdateDllList[i];
                try
                {
                    if (debugModel == false)
                    {
                        downloadFormUpdateFile(url, path);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载更新程序出错！");
                    Console.WriteLine("下载更新程序出错" + ex);
                }
            }
            Console.WriteLine("下载更新程序完成");
            hideFormSafePost();
            //下载完成，执行更新程序
            if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + "UpdateProgram.dll") == false)
            {
                MessageBox.Show("发生致命错误。更新程序不存在。");
                Environment.Exit(0);
                return;
            }


            //加载程序集(dll文件地址)，使用Assembly类
            Console.WriteLine("读取程序集：" + System.Windows.Forms.Application.StartupPath + @"\" + "UpdateProgram.dll");
            Assembly assembly = Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + @"\" + "UpdateProgram.dll");

            Type type = assembly.GetType("UpdateProgram.FormUpdate");
            object instance = assembly.CreateInstance("UpdateProgram.FormUpdate");
            Type[] params_type = new Type[1];

            string files = "";

            foreach (var item in serInfos)
            {
                files += item;
            }

            params_type[0] = Type.GetType("System.String");
            Object[] params_obj = new Object[1];
            params_obj[0] = oriSerInfos;

            //执行Show_Str方法   
            object value = type.GetMethod("downFiles", params_type).Invoke(instance, params_obj);
            Environment.Exit(0);
        }


        void downloadFormUpdateFile(string url, string path)
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



        public static string requestFromServer(string url)
        {
            string responseString = "";
            try
            {
                Debug.Print("发出拉取远程更新列表是：" + url);
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



        List<string> getValue(string key)
        {
            for (int i = 0; i < serInfos.Length; i++)
            {
                if (serInfos[i].Contains("[" + key + "]"))
                {
                    List<string> values = new List<string>();
                    //   Console.WriteLine("发现key"+i);
                    for (int j = i + 1; j < serInfos.Length; j++)
                    {
                        //      Console.WriteLine("比对中"+j + data[j]);
                        if (serInfos[j].Contains("[") == false && serInfos[j].Contains("]") == false)
                        {
                            string temp = serInfos[j].TrimEnd((char[])"\r".ToCharArray());
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



        void openPragram(string programName)
        {
            System.Diagnostics.Process process;
            try
            {
                process = new System.Diagnostics.Process();

                Console.WriteLine("启动的程序是" + System.Windows.Forms.Application.StartupPath + @"\" + programName);
                process.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + @"\" + programName;
                process.StartInfo.Arguments = programName; //启动参数 
                process.Start();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("发生致命错误，无需更新时找不到启动程序\n点击确定按钮自动修复程序。");
                UpdateFormUpdate();
            }
            finally {
                 Environment.Exit(0);
            }
        }


        void showFormSafePost()
        {
            m_SyncContext.Post(showForm, null);
        }
        void showForm(object state)
        {
          
            this.Show();
            Debug.Print("需要更新，得显示啊");
        }
        void hideFormSafePost() {
            m_SyncContext.Post(hideForm, null);
        }
        void hideForm(object state)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormDDN_Activated(object sender, EventArgs e)
        {
            Hide();
        }
    }
}












