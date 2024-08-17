using System.Collections;
using UnityEngine;

public class 拖拽 : MonoBehaviour  {
    public shiyanjindu shiyanjindu;//实验进度脚本
    private Vector3 _vec3TargetScreenSpace;// 目标物体的屏幕空间坐标  
    private Vector3 _vec3TargetWorldSpace;// 目标物体的世界空间坐标  
    public  Transform _trans;// 目标物体的空间变换组件  
    private Vector3 _vec3MouseScreenSpace;// 鼠标的屏幕空间坐标  
    private Vector3 _vec3Offset;// 偏移 

    private void Awake()  {
        _trans = transform;//滑动位置赋值
        
       
    }
    
    private void Update() {
        _trans.position = new Vector3(Mathf.Clamp(_trans.transform.position.x, _trans.parent.position.x - 0.09f, _trans.parent.position.x + 0.04f), _trans.parent.position.y, _trans.parent.position.z);
        //限制移动位置
        if (翻转.ins.开关 == true)//判断开关
        {
           // 翻转.ins._v = (_trans.position.x / 0.13f) - 50.7861523f;//滑动电阻控制灯泡亮度
            翻转.ins._v =1-( (_trans.position.x / 0.13f) - 50.7861523f);//滑动电阻控制灯泡亮度
            Rotate.ShowSpeed(_trans.position.x * 20, 45f, 360);//电流表指针绑定
            Rotate1.ShowSpeed(_trans.position.x * 20, 45, 360);//电压表指针绑定
            shiyanjindu.disanbu();//进度第三步完成
        }
    }
 
    IEnumerator OnMouseDown()//携程控制鼠标移动物体

    {
        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);

        // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   

        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

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