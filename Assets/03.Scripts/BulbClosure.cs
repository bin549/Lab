using System.Collections;
using UnityEngine;

public class BulbClosure : MonoBehaviour {
    public enum RenderingMode {
        Opaque,
        Cutout,
        Fade,
        Transparent,
    }
    public static BulbClosure instance;
    private GameObject obj;
    public Transform Sun;
    public bool isTriggerEnabled = false;
    public GameObject bulb;
    private Renderer renderer;
    public Material material;
    public GameObject[] dianxianred;
    public GameObject[] dianxian;
    public shiyanjindu shiyanjindu;
    [SerializeField] private LabOne labOne;
    [SerializeField] private LabDetector labDetector;
    public readonly string _colorName = "_EmissionColor";
    public float _deltaBrightness;
    [Range(0.0f, 1.0f)] public float minBrightness = 0f;
    [Range(0.0f, 1)] public float maxBrightness = 1f;
    public Color color = new Color(1, 0, 1, 1);
    public float _h, _s;
    public float _v;

    private void Awake() {
        this.labOne = FindObjectOfType<LabOne>();
        instance = this;
    }

    private void Start() {
        if (this.bulb) {
            this.renderer = this.bulb.GetComponent<Renderer>();
            this.material = this.renderer.material;
            SetMaterialRenderingMode(this.material, RenderingMode.Transparent);
            this.material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
        }
        for (int i = 0; i < dianxianred.Length; i++) {
            dianxianred[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
        }
        for (int i = 0; i < dianxian.Length; i++) {
            dianxian[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
        }
    }

    private void ToggleLight() {
        if (!this.isTriggerEnabled) {
            obj.transform.RotateAround(Sun.transform.position, Vector3.forward, -60);
            this.isTriggerEnabled = true;
            SetMaterialRenderingMode(this.material, RenderingMode.Opaque);
            for (int i = 0; i < dianxianred.Length; i++) {
                dianxianred[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.red);
            }
            for (int i = 0; i < dianxian.Length; i++) {
                dianxian[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.blue);
            }
            shiyanjindu.dierbu();
        } else {
            obj.transform.RotateAround(Sun.transform.position, Vector3.forward, 60);
            this.isTriggerEnabled = false;
            this.material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
            SetMaterialRenderingMode(this.material, RenderingMode.Transparent);
            for (int i = 0; i < dianxianred.Length; i++) {
                dianxianred[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
            }
            for (int i = 0; i < dianxian.Length; i++) {
                dianxian[i].GetComponent<Renderer>().material.SetColor(_colorName, Color.HSVToRGB(_h, _s, minBrightness));
            }
        }
    }

    private void Update() {
        if (this.isTriggerEnabled) {
            this.material.SetColor(_colorName, Color.HSVToRGB(_h, _s, _v));
        }
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                obj = hit.collider.gameObject;
                if (obj.name.Equals("铡刀")) {
                    this.labOne.PassLab();
                    this.ToggleLight();
                    StartCoroutine(this.ResetLab());
                }
            }
        }
    }

    private IEnumerator ResetLab() {
        yield return new WaitForSeconds(1.4f);
        this.ToggleLight();
        this.labDetector.ExitLab(true);
    }

    public static void SetMaterialRenderingMode(Material material, RenderingMode renderingMode) {
        switch (renderingMode) {
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
