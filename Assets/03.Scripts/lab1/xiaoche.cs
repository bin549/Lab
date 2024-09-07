using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI;

public class xiaoche : MonoBehaviour {
    public static xiaoche Singleton;
    private Rigidbody rigid;
    public float speed = 0;
    public bool xiaochespeedbool = false;
    private float xiaochespeed;
    public Text text;
    private bool suduxianshibool = false;
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
    }

    public void addtxt() {
        TxtWriteAndRead.ins.AddTxtTextByFileInfo(
            "С������"
                + MouseView.ins.carKG.ToString()
                + "g"
                + "\n"
                + "��������"
                + MouseView.ins.heziKG.ToString()
                + "g"
                + "\n"
                + text.text
                + "&"
        );
    }

    public void readtxt() {
        jiasudupanel.SetActive(!jiasudupanel.activeSelf);
        if (jiasudupanel.activeSelf) {
            Transform transform;
            for (int i = 0; i < conent.transform.childCount; i++) {
                transform = conent.transform.GetChild(i);
                GameObject.Destroy(transform.gameObject);
            }
            TxtWriteAndRead.ins.ReadTxtFifth();
            string[] str = TxtWriteAndRead.ins.str.Split('&');
            for (int i = 0; i < str.Length; i++) {
                GameObject go = Instantiate(jiasuduprefab, conent, false);
                go.GetComponent<jiasuduprefab>().text.text = str[i];
            }
        }
    }

    public void rigidbodyadd2() {
        rigid.mass = rigid.mass + 1;
        suduxianshibool = true;
    }

    public void kaishiyouxi() {
        xiaochespeedbool = true;
    }

    public void qingkong() {
        text.text = null;
    }
}
