using System.Collections;
using UnityEngine;

public class PH : MonoBehaviour 
{
    private Vector3 _vec3TargetScreenSpace;
    private Vector3 _vec3TargetWorldSpace;
    public Transform _trans;
    private Vector3 _vec3MouseScreenSpace;
    private Vector3 _vec3Offset;
    public GameObject goquses;
    public bool qusebool;
    public bool dirubool;
    public GameObject yangben;
    public GameObject[] shaobeis;
    public readonly string _colorName = "_EmissionColor";//颜色模式
    public GameObject panelinfo;
    public int quseint;

    public Transform shuiditr;
    public GameObject shuidiprefab;
    string text;

    void OnTriggerEnter(Collider other)//判断触发器
    {
        if (other.gameObject.name == "醋")//碰撞到的物体名字是否等于预设物体名字
        {
            if (qusebool == true)
            {
                goquses = other.gameObject;
                qusebool = false;
                yangben.GetComponent<Renderer>().material.color = new Color(0.2509804f, 0.2039216f, 0.2078432f, 1);
                quseint = other.gameObject.GetComponent<color>().intt;
                text=other.gameObject.name;
            }
        }
        if (other.gameObject.name == "纯水")//碰撞到的物体名字是否等于预设物体名字
        {
            if (qusebool == true)
            {
                goquses = other.gameObject;
                qusebool = false;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                quseint = other.gameObject.GetComponent<color>().intt;
                text = other.gameObject.name;
            }
        }
        if (other.gameObject.name == "肥皂水")//碰撞到的物体名字是否等于预设物体名字
        {
            if (qusebool == true)
            {
                goquses = other.gameObject;
                qusebool = false;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                quseint = other.gameObject.GetComponent<color>().intt;
                text = other.gameObject.name;
            }
        }
        if (other.gameObject.name == "试纸1")//碰撞到的物体名字是否等于预设物体名字
        {
            if (dirubool == true && goquses != null)
            {
               
                GameObject go=Instantiate(shuidiprefab,shuiditr.transform.position,Quaternion.identity);
                go.GetComponent<Renderer>().material.color = yangben.GetComponent<Renderer>().material.color;
                go.gameObject.GetComponent<shizhi>().intt=quseint;
                go.gameObject.GetComponent<shizhi>().text=text;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);

                dirubool = false;


            }
        }
        if (other.gameObject.name == "试纸2")//碰撞到的物体名字是否等于预设物体名字
        {
            if (dirubool == true && goquses != null)
            {

                GameObject go = Instantiate(shuidiprefab, shuiditr.transform.position, Quaternion.identity);
                go.GetComponent<Renderer>().material.color = yangben.GetComponent<Renderer>().material.color;
                go.gameObject.GetComponent<shizhi>().intt = quseint;
                go.gameObject.GetComponent<shizhi>().text = text;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                dirubool = false;


            }
        }
        if (other.gameObject.name == "试纸3")//碰撞到的物体名字是否等于预设物体名字
        {
            if (dirubool == true && goquses != null)
            {

                GameObject go = Instantiate(shuidiprefab, shuiditr.transform.position, Quaternion.identity);
                go.GetComponent<Renderer>().material.color = yangben.GetComponent<Renderer>().material.color;
                go.gameObject.GetComponent<shizhi>().intt = quseint;
                go.gameObject.GetComponent<shizhi>().text = text;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                dirubool = false;


            }
        }
    }

    public void infopanel()
    {
        panelinfo.SetActive(!panelinfo.activeSelf);
    }
    
    public void dirubutton()
    {

        dirubool = true;
    }
    public void qusebutton()
    {
        qusebool = true;

    }
    private void Awake()
    {
        _trans = transform;//滑动位置赋值


    }
    private void Update()
    {
        _trans.position = new Vector3(_trans.transform.position.x, -3.416f, _trans.transform.position.z);


    }

    IEnumerator OnMouseDown()//携程控制鼠标移动物体

    {

        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);

        // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   

        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

        // 计算目标物体与鼠标物体在世界空间中的偏移量   

        _vec3Offset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);

        // 鼠标左键按下   

        while (Input.GetMouseButton(0))
        {

            // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  

            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

            // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  

            _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

            // 更新目标物体的世界空间坐标   

            _trans.position = _vec3TargetWorldSpace;

            // 等待固定更新   

            yield return new WaitForFixedUpdate();
        }
    }

}