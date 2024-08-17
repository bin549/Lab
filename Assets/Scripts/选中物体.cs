using System.Collections.Generic;
using UnityEngine;

public class 选中物体 : MonoBehaviour 
{
    public Texture2D tex;//鼠标图标
    GameObject obj;//点击的物体
    
    public GameObject camera;//控制近景相机
    public shiyanjindu shiyanjindu;//实验进度脚本
    //[SerializeField]
    
    private void Start()
    {
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);//设置鼠标图标

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//当鼠标左键按下的时候
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从当前点击的位置发射一条射线
            if (Physics.Raycast(ray, out RaycastHit hit))//判断当前射线有没有射中物体
            {
                obj = hit.collider.gameObject;//获取点击的物体
                if (obj.name.Equals("学生电源"))//如果物体为学生电源，近景显示
                {
                   
                    camera.transform.position =new Vector3( obj.transform.position.x, obj.transform.position.y+0.40807f, obj.transform.position.z-0.4822f);
                }
                if (obj.name.Equals("开关"))//如果物体为铡刀开关，近景显示
                {
                   
                   
                    camera.transform.position = new Vector3(obj.transform.position.x+0.022f, obj.transform.position.y + 0.148f, obj.transform.position.z - 0.1256f);
                }
                if (obj.name.Equals("滑动电阻"))//如果物体为滑动电阻，近景显示
                {
                    
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.2f, obj.transform.position.z - 0.2f);
                }
                if (obj.name.Equals("电流表"))//如果物体为电流表，近景显示
                {
                   
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.15f, obj.transform.position.z - 0.15f);
                    shiyanjindu.disibu();//第四步完成
                }
                if (obj.name.Equals("电压表"))//如果物体为电压表，近景显示
                {
                    
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.15f, obj.transform.position.z - 0.15f);
                    shiyanjindu.disibu();//第四步完成
                }
                if (obj.name.Equals("负载"))//如果物体为负载，近景显示
                {
                   
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.2f, obj.transform.position.z - 0.2f);
                }
                
            }
        }
            }
}