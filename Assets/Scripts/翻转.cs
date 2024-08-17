using System.Collections;
using UnityEngine;

public class 翻转 : MonoBehaviour 
{
    public static 翻转 ins;//单例脚本
    GameObject obj;//点击的物体
    public Transform Sun;//围绕旋转的位置
   public  bool 开关=false;//旋转开关
    public GameObject 灯;//灯泡
    private Renderer _renderer;//灯泡材质
    public  Material _material;//灯泡材质
    public GameObject[] dianxianred;//红色电线材质控制
    public GameObject[] dianxian;//蓝色电线材质控制
    public shiyanjindu shiyanjindu;//实验进度控制脚本
    private void Awake()  {
        ins = this;//单例
        if (灯 != null)//灯不为空
        {
            _renderer = 灯.GetComponent<Renderer>();//获取灯泡材质组件
            _material = _renderer.material;//获取灯泡材质
            SetMaterialRenderingMode(_material, RenderingMode.Transparent);//设置灯泡材质默认模式为默认
            _material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));//设置灯泡自发光亮度为最低
        }
        for (int i = 0; i < dianxianred.Length; i++)//遍历红色电线材质为默认
        {
            dianxianred[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
           
        }
        for (int i = 0; i < dianxian.Length; i++)//遍历蓝色电线材质为默认
        {
            dianxian[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));

        }
    }
    private void Update()
    {
        if (开关 == true)//开关打开灯泡亮度才为可以控制
        {
            _material.SetColor(_colorName, Color.HSVToRGB(_h, _s, _v));//检测_v控制灯泡亮度
        }

            if (Input.GetMouseButtonDown(0))//当鼠标左键按下的时候
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从当前点击的位置发射一条射线
            if (Physics.Raycast(ray, out RaycastHit hit))//判断当前射线有没有射中物体
            {
                obj = hit.collider.gameObject;//获取点击的物体
                if (obj.name.Equals("铡刀"))//如果物体为铡刀开关
                {

                    if (开关 == false)//开关状态为关
                    {
                        obj.transform.RotateAround(Sun.transform.position, Vector3.forward, -60);//控制开关铡刀
                        开关 = true;//开关状态为开
                       
                            SetMaterialRenderingMode(_material, RenderingMode.Opaque);//修改灯泡材质为自发光

                            for (int i = 0; i < dianxianred.Length; i++)//通电后遍历修改红色电线材质
                            {
                                dianxianred[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.red);
                            }
                            for (int i = 0; i < dianxian.Length; i++)//通电后修改蓝色电线材质
                            {
                                dianxian[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.blue);
                            }
                        shiyanjindu.dierbu();//实验进度第二步完成
                        
                    }
                    else
                    {
                        obj.transform.RotateAround(Sun.transform.position, Vector3.forward, 60);//控制开关铡刀
                        开关 = false;//开关状态为关
                        _material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));//设置灯泡自发光亮度为最低
                        SetMaterialRenderingMode(_material, RenderingMode.Transparent);//修改灯泡材质为默认
                        for (int i = 0; i < dianxianred.Length; i++)//关闭电源修改红色电线材质为默认材质
                        {
                            dianxianred[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
                       
                        }
                        for (int i = 0; i < dianxian.Length; i++)//关闭电源修改蓝色电线材质为默认材质
                        {
                            dianxian[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));

                        }
                    }
                }
               


                }
        }
    }
   
    public  readonly string _colorName = "_EmissionColor";//颜色模式
    public float _deltaBrightness;     // 最低最高亮度差
    [Range(0.0f, 1.0f)]
    public float minBrightness = 0f;//最低亮度
    /// <summary>
    /// 最高发光亮度，取值范围[0,1]，需大于最低发光亮度。
    /// </summary>
    [Range(0.0f, 1)]
    public float maxBrightness = 1f;//最高亮度
    public Color color = new Color(1, 0, 1, 1);//设置自发光颜色
    public float _h, _s;// 色调，饱和度，亮度
    public float  _v;           // 色调，饱和度，亮度
   
    public enum RenderingMode//材质枚举对应系统材质选项
    {
        Opaque,
        Cutout,
        Fade,
        Transparent,
    }

    public static void SetMaterialRenderingMode(Material material, RenderingMode renderingMode)//自发光材质系统对应设置，默认代码
    {
        switch (renderingMode)
        {
            case RenderingMode.Opaque:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case RenderingMode.Cutout:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case RenderingMode.Fade:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case RenderingMode.Transparent:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }
}

