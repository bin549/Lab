/****************************************************
    文件：shizhi.cs
	作者：夜
    邮箱: 97665366@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;

public class shizhi : MonoBehaviour
{
    public AnimationCurve curve;//放大的曲线

    public int intt;
    public GameObject yinjiprefab;
    public string text;
    void OnTriggerEnter(Collider other)//判断触发器
    {
        if (other.gameObject.name == "水滴")//碰撞到的物体名字是否等于预设物体名字
        {
            
            //Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter(Collision ctl)
    {
        if (ctl.gameObject.name == "试纸1")//碰撞到的物体名字是否等于预设物体名字
        {
            ContactPoint contact = ctl.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
           
            GameObject go = Instantiate(yinjiprefab,new Vector3(pos.x,ctl.transform.position.y+0.01f,pos.z),Quaternion.identity);
            go.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
            go.gameObject.GetComponent<yinji>().intt = intt;
            go.gameObject.GetComponent<yinji>().text.text = text;
            Destroy(gameObject);
        }
        if (ctl.gameObject.name == "试纸2")//碰撞到的物体名字是否等于预设物体名字
        {
            ContactPoint contact = ctl.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            GameObject go = Instantiate(yinjiprefab, new Vector3(pos.x, ctl.transform.position.y + 0.01f, pos.z), Quaternion.identity);
            go.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
            go.gameObject.GetComponent<yinji>().intt = intt;
            go.gameObject.GetComponent<yinji>().text.text = text;
            Destroy(gameObject);
        }
        if (ctl.gameObject.name == "试纸3")//碰撞到的物体名字是否等于预设物体名字
        {
            ContactPoint contact = ctl.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            GameObject go = Instantiate(yinjiprefab, new Vector3(pos.x, ctl.transform.position.y + 0.01f, pos.z), Quaternion.identity);
            go.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
            go.gameObject.GetComponent<yinji>().intt = intt;
            go.gameObject.GetComponent<yinji>().text.text = text;
            Destroy(gameObject);
        }
    }

}