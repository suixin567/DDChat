using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLib
{
    public class AnalyzeMFile
    {
        public static List<string> Analyze(string content ,string key) {

            string[] serInfos;
            serInfos = content.Split('\n');

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
    }
}
