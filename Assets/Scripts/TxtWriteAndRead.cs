/****************************************************
    文件：TxtWriteAndRead.cs
	作者：夜
    邮箱: 97665366@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;  //操作文件夹时需引用该命名空间
using System.Text;

public class TxtWriteAndRead : MonoBehaviour
{
    public static TxtWriteAndRead ins;
    TextAsset m_Txt;
    public string str;
    public string jiasuduTXT;
    private void Awake()
    {
        ins = this;
    }
    void Start()
    {
       //AddTxtTextByFileInfo("第一种方法添加text文本");//写入

      //ReadTxtFifth();//读取
    }

   
    /// <summary>
    /// 创建txt 写入
    /// </summary>
    /// <param name="txtText"></param>
    public void AddTxtTextByFileInfo(string txtText)
    {
        string path = Application.dataPath + jiasuduTXT;
        StreamWriter sw;
        FileInfo fi = new FileInfo(path);

        if (!File.Exists(path))
        {
            sw = fi.CreateText();
        }
        else
        {
            sw = fi.AppendText();   //在原文件后面追加内容      
        }
        sw.WriteLine(txtText);
        sw.Close();
        sw.Dispose();
    }

   

    /// <summary>
    /// 读取
    /// 文件流方式
    /// </summary>
   public  void ReadTxtFifth()
    {
        string path = Application.dataPath + jiasuduTXT;
        FileStream files = new FileStream(path, FileMode.Open, FileAccess.Read);
        byte[] bytes = new byte[files.Length];
        files.Read(bytes, 0, bytes.Length);
        files.Close();
        str = UTF8Encoding.UTF8.GetString(bytes);
        
    }
    //清空数据
   public  void ReWriteMyTxtByFileStreamTxt()
    {
        string path = Application.dataPath + jiasuduTXT;

        string[] strs = { null};

        File.WriteAllLines(path, strs);

    }

}