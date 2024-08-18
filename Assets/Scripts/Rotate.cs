using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    static float minAngle =0f;//最小
    static float maxAngle = -180f;   //0-180代表表盘旋转的角度
    static Rotate thisSpeed0;//单例
    
    void Start() {
        thisSpeed0 = this;//单例
    }

    public static void ShowSpeed(float speed, float min, float max)//控制指针旋转
    {
        //将速度与指针转动角度对应起来
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        //添加旋转   可以在ang后乘以个常数用来调节转动效果
        thisSpeed0.transform.eulerAngles = new Vector3(0, 0, -ang * 49.9f);
    }
}

