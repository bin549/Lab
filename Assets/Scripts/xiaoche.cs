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

    private void Start() {
        rigid = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() {
        DateTime NowTime = DateTime.Now.ToLocalTime();
        speed = GameObject.Find("endBox").GetComponent<hezi>().hezispeed;
        if (this.xiaochespeedbool) {
            rigid.velocity = Vector3.forward * speed;
        }
            xiaochespeed = rigid.velocity.magnitude;
        // if (speed != 0) {
        //     string message = NowTime.ToString(" HH: mm:ss")+"=>" + (xiaochespeed / kg) * kh;
        //     text.text += message + "\n";
        // }
    }

    public void addtxt() {
        TxtWriteAndRead.ins.AddTxtTextByFileInfo("小车重量" + MouseView.ins.carKG.ToString() + "g" +"\n"+ "盒子重量" + MouseView.ins.heziKG.ToString() + "g" + "\n" + text.text+"&");
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

   

