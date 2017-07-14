using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                        Console.WriteLine("Analyze错误： 没有找到value!");
                    }
                    return values;
                }
            }
            Console.WriteLine("Analyze错误： 没有找到key!");
            return null;
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
