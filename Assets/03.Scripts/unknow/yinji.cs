using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class yinji : MonoBehaviour
{
    [Range(0, 1)]
    public float 速度;
    public float 值;
    public Vector3 大小;
    public int intt;
    public Text text;
    //Vector3.MoveTowards(transform.position, 道路.transform.position, Time.deltaTime * 速度 / 1000);

    void Update()
    {
        
            值 = Time.time * 速度 / 10000;
        
            //transform.localScale = new Vector3(transform.localScale.x + 值, transform.localScale.y, transform.localScale.z + 值);
            //插值
            transform.localScale = Vector3.MoveTowards(transform.localScale, 大小, 值);
        switch (intt)
        {
            case 1:
               this.GetComponent<Renderer>().material.color = Color.Lerp(new Color(0.2509804f, 0.2039216f, 0.2078432f, 1), new Color(0.8039216f, 0.2745098f, 0.1058824f, 1), 值*5000);

                break;
            case 2:
                this.GetComponent<Renderer>().material.color = Color.Lerp(new Color(1, 1, 1, 0),new Color(0.7607844f, 0.7803922f, 0.1686275f, 1), 值 * 5000);
                break;
            case 3:
                this.GetComponent<Renderer>().material.color = Color.Lerp(new Color(1, 1, 1, 0),new Color(0.1098039f, 0.2196079f, 0.2196079f, 1), 值 * 5000);
                break;
        }

    }
}