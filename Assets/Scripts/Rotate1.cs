/****************************************************
    文件：Rotate1.cs
	作者：夜
    邮箱: 97665366@qq.com
    日期：#CreateTime#
	功能：电压表指针控制
*****************************************************/

using UnityEngine;

public class Rotate1 : MonoBehaviour 
{
    static float minAngle = 0f;//最小
    static float maxAngle = -180f;   //0-180代表表盘旋转的角度
    static Rotate1 thisSpeed0;//单例
    // Start is called before the first frame update
    void Start()
    {
        thisSpeed0 = this;//单例
    }
    // Update is called once per frame
    public static void ShowSpeed(float speed, float min, float max)//控制指针旋转
    {
        //将速度与指针转动角度对应起来
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        //添加旋转   可以在ang后乘以个常数用来调节转动效果
        thisSpeed0.transform.eulerAngles = new Vector3(0, 0, -ang * 49.9f);
    }
}

