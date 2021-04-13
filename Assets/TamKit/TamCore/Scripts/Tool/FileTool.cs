/* ========================================================
* |     作者：Tamsiree 
* |     创建时间：2020年08月20日 10:41:39
* |     主要功能：
* |     详细描述：
* |     版本：1.0
*  ======================================================== */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEditor;
using UnityEngine;

public class FileTool
{

    public static string LoadFile(string dictionaryPath, string fileName, string log = null, bool showhint = true)
    {
        //路径 
        //string.Format("{0}", @"D:\SHU170221U3D-09\Lesson14\Assets\StreamingAssets");         + @"/_Image/grid.png"
        Debug.Log("想要读取的文件夹是************" + dictionaryPath);

        string type = "*.json";

        //获取指定路径下面的所有json文件  
        if (Directory.Exists(dictionaryPath))
        {
            DirectoryInfo direction = new DirectoryInfo(dictionaryPath);
            FileInfo[] files = direction.GetFiles(type, SearchOption.AllDirectories);   //   获取所有json文件
            Debug.Log("该文件夹存在文件总数为" + files.Length);
            if (files.Length == 0)
            {
                string fileLogName = log == null ? "json文件" : log;
                Debug.Log("不存在任何" + fileLogName + "！！");
                return null;
            }
        }
        else
        {
            Debug.Log("不存在该路径:" + dictionaryPath);
            return null;
        }

        string json = File.ReadAllText(dictionaryPath + "/" + fileName, Encoding.UTF8);
        return json;
    }

    //本地文件
    public static void Save(string dictionaryPath, string fileName, string json)
    {
        Debug.Log(json);
        if (!Directory.Exists(dictionaryPath))
        {
            Directory.CreateDirectory(dictionaryPath);
        }
        FileStream file = new FileStream(dictionaryPath + "/" + fileName, FileMode.Create);
        byte[] bts = Encoding.UTF8.GetBytes(json);
        file.Write(bts, 0, bts.Length);
        if (file != null)
        {
            file.Close();
        }
        else
            Debug.Log("NULLLLLLLLLLLLL");
    }

    //Resource json
    public static void SaveToResource(string filePath, string json)
    {
        Debug.Log(filePath);

        if (!File.Exists(filePath))
        {
            Debug.LogWarning("路径或文件不存在！！！即将创建新文件！！！！！");
        }

        FileInfo file = new FileInfo(filePath);
        //判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        sw.WriteLine(json);
        sw.Flush();  // 清空缓存
        sw.Close();
        sw.Dispose();
    }

}
