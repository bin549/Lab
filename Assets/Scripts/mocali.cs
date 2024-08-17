using UnityEngine.UI;
using UnityEngine;

public class mocali : MonoBehaviour 
{
    public static mocali instance;
    public Text[] text;
    public string names;
    public GameObject mocalipanel;
    public Transform conent;
    public GameObject mocaliprefab;

    public mocali() {
        instance = this;
    }

    public void add() {
        TxtWriteAndRead.ins.AddTxtTextByFileInfo(names+"\n"+ "加速度(m/s^2):" + text[0].text+ "\n " + "质量(kg):" + text[1].text+ "\n " + "重力加速度m/s^2):" + text[2].text+ "\n " + "角度(°):" + text[3].text+ "\n " + "摩擦力(N):" + text[4].text+"\n "+ "摩擦系数:" + text[5].text+"&");
    }
    
    public void readtxt() {
        mocalipanel.SetActive(!mocalipanel.activeSelf);
        if (mocalipanel.activeSelf)
        {
            Transform transform;
            for (int i = 0; i < conent.transform.childCount; i++)
            {
                transform = conent.transform.GetChild(i);
                GameObject.Destroy(transform.gameObject);
            }
            TxtWriteAndRead.ins.ReadTxtFifth();
            string[] str = TxtWriteAndRead.ins.str.Split('&');
            for (int i = 0; i < str.Length; i++)
            {
                GameObject go = Instantiate(mocaliprefab, conent, false);
                go.GetComponent<jiasuduprefab>().text.text = str[i];
                go.GetComponent<jiasuduprefab>().text.fontSize = 13;
            }
        }
    }



}