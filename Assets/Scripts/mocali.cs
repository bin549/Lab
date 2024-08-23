using UnityEngine.UI;
using UnityEngine;

public class mocali : MonoBehaviour {
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
        TxtWriteAndRead.ins.AddTxtTextByFileInfo(names+"\n"+ "���ٶ�(m/s^2):" + text[0].text+ "\n " + "����(kg):" + text[1].text+ "\n " + "�������ٶ�m/s^2):" + text[2].text+ "\n " + "�Ƕ�(��):" + text[3].text+ "\n " + "Ħ����(N):" + text[4].text+"\n "+ "Ħ��ϵ��:" + text[5].text+"&");
    }
    
    public void readtxt() {
        mocalipanel.SetActive(!mocalipanel.activeSelf);
        if (mocalipanel.activeSelf) {
            Transform transform;
            for (int i = 0; i < conent.transform.childCount; i++) {
                transform = conent.transform.GetChild(i);
                GameObject.Destroy(transform.gameObject);
            }
            TxtWriteAndRead.ins.ReadTxtFifth();
            string[] str = TxtWriteAndRead.ins.str.Split('&');
            for (int i = 0; i < str.Length; i++) {
                GameObject go = Instantiate(mocaliprefab, conent, false);
                go.GetComponent<jiasuduprefab>().text.text = str[i];
                go.GetComponent<jiasuduprefab>().text.fontSize = 13;
            }
        }
    }
}