using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class xiaoche : MonoBehaviour {
    public static xiaoche Singleton;
    Rigidbody rigid;
    public float speed = 0;
    public bool xiaochespeedbool=false;
    float  xiaochespeed;
    public Text text;
    bool suduxianshibool=false;
    public float kg = 1;
    public float kh = 1;
    public GameObject jiasuduprefab;
    public Transform conent;
    public GameObject jiasudupanel;

    public xiaoche() {
        Singleton = this;
    }

    void Start() {
        rigid = GetComponent<Rigidbody>();
        
    }
    
    void FixedUpdate()
    {
        DateTime NowTime = DateTime.Now.ToLocalTime();//��ȡʱ��
        speed = GameObject.Find("hezi").GetComponent<hezi>().hezispeed;
        if (xiaochespeedbool == true)
        {
            rigid.velocity = Vector3.forward * speed;
        }
        xiaochespeed = rigid.velocity.magnitude;
        if (speed != 0)
        {
            //if(suduxianshibool == true)
            //{
            //    string message1 = NowTime.ToString("HH: mm:ss") + " : speed :" + xiaochespeed/2;
            //    text.text += message1 + "\n";
            //}

            string message = NowTime.ToString(" HH: mm:ss")+"=>" + (xiaochespeed / kg) * kh;
            text.text += message + "\n";
        }

    }

    public void addtxt()
    {
        TxtWriteAndRead.ins.AddTxtTextByFileInfo("С������" + MouseView.ins.carKG.ToString() + "g" +"\n"+ "��������" + MouseView.ins.heziKG.ToString() + "g" + "\n" + text.text+"&");
    }

    public void readtxt()
    {
        jiasudupanel.SetActive(!jiasudupanel.activeSelf);
        if (jiasudupanel.activeSelf)
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
                GameObject go = Instantiate(jiasuduprefab, conent, false);
                go.GetComponent<jiasuduprefab>().text.text = str[i];
            }
        }
    }

    public void rigidbodyadd2()
    {
        rigid.mass = rigid.mass + 1;
        suduxianshibool = true;
    }

    public void kaishiyouxi()
    {
        xiaochespeedbool = true;
    }

    public void qingkong()
    {
        text.text = null;
    }
}

   

