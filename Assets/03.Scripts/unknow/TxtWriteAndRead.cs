using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;  //操作文件夹时需引用该命名空间
using System.Text;

public class TxtWriteAndRead : MonoBehaviour {
    public static TxtWriteAndRead ins;
    TextAsset m_Txt;
    public string str;
    public string jiasuduTXT;
   
    private void Awake() {
        ins = this;
    }
   
    public void AddTxtTextByFileInfo(string txtText) {
        string path = Application.dataPath + jiasuduTXT;
        StreamWriter sw;
        FileInfo fi = new FileInfo(path);

        if (!File.Exists(path)) {
            sw = fi.CreateText();
        } else {
            sw = fi.AppendText();
        }
        sw.WriteLine(txtText);
        sw.Close();
        sw.Dispose();
    }

   
   public  void ReadTxtFifth() {
        string path = Application.dataPath + jiasuduTXT;
        FileStream files = new FileStream(path, FileMode.Open, FileAccess.Read);
        byte[] bytes = new byte[files.Length];
        files.Read(bytes, 0, bytes.Length);
        files.Close();
        str = UTF8Encoding.UTF8.GetString(bytes);
    }

   public void ReWriteMyTxtByFileStreamTxt() {
        string path = Application.dataPath + jiasuduTXT;
        string[] strs = { null};
        File.WriteAllLines(path, strs);
    }
}