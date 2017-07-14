using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolLib;

namespace Experiment
{
    public partial class Form1 : Form
    {


        string fileContent="";

        public Form1()
        {
            InitializeComponent();           
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            Read();
        }

        public void Read()
        {
            try
            {
                string versionStr = System.IO.File.ReadAllText( @"e:\test.conf");
                fileContent = versionStr;
                Debug.Print("读取到的是\n" + fileContent);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string newContent = AnalyzeMFile.AnalyzeSet(fileContent,"f",new List<string> { "112", "222", "3333" });
            try
            {
                string path = @"e:\test.conf";
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码               
                sw.WriteLine(newContent);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                Debug.Print("<script>('写入失败！')</script>");
            }
        }
    }
}
