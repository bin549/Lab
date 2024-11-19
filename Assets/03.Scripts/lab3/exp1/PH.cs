using System.Collections;
using UnityEngine;

public class PH : MonoBehaviour {
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
    public readonly string _colorName = "_EmissionColor";
    public GameObject panelinfo;
    public int quseint;
    public Transform shuiditr;
    public GameObject shuidiprefab;
    string text;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "醋") {
            if (qusebool == true) {
                goquses = other.gameObject;
                qusebool = false;
                yangben.GetComponent<Renderer>().material.color = new Color(
                    0.2509804f,
                    0.2039216f,
                    0.2078432f,
                    1
                );
                quseint = other.gameObject.GetComponent<color>().intt;
                text = other.gameObject.name;
            }
        }
        if (other.gameObject.name == "纯水") {
            if (qusebool == true) {
                goquses = other.gameObject;
                qusebool = false;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                quseint = other.gameObject.GetComponent<color>().intt;
                text = other.gameObject.name;
            }
        }
        if (other.gameObject.name == "肥皂水") {
            if (qusebool) {
                goquses = other.gameObject;
                qusebool = false;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                quseint = other.gameObject.GetComponent<color>().intt;
                text = other.gameObject.name;
            }
        }
        if (other.gameObject.name == "试纸1") {
            if (dirubool == true && goquses != null) {
                GameObject go = Instantiate(
                    shuidiprefab,
                    shuiditr.transform.position,
                    Quaternion.identity
                );
                go.GetComponent<Renderer>().material.color = yangben
                    .GetComponent<Renderer>()
                    .material.color;
                go.gameObject.GetComponent<shizhi>().intt = quseint;
                go.gameObject.GetComponent<shizhi>().text = text;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);

                dirubool = false;
            }
        }
        if (other.gameObject.name == "试纸2") {
            if (dirubool == true && goquses != null) {
                GameObject go = Instantiate(
                    shuidiprefab,
                    shuiditr.transform.position,
                    Quaternion.identity
                );
                go.GetComponent<Renderer>().material.color = yangben.GetComponent<Renderer>().material.color;
                go.gameObject.GetComponent<shizhi>().intt = quseint;
                go.gameObject.GetComponent<shizhi>().text = text;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                dirubool = false;
            }
        }
        if (other.gameObject.name == "试纸3") {
            if (dirubool == true && goquses != null) {
                GameObject go = Instantiate(
                    shuidiprefab,
                    shuiditr.transform.position,
                    Quaternion.identity
                );
                go.GetComponent<Renderer>().material.color = yangben
                    .GetComponent<Renderer>()
                    .material.color;
                go.gameObject.GetComponent<shizhi>().intt = quseint;
                go.gameObject.GetComponent<shizhi>().text = text;
                yangben.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                dirubool = false;
            }
        }
    }

    public void infopanel() {
        panelinfo.SetActive(!panelinfo.activeSelf);
    }

    public void dirubutton() {
        dirubool = true;
    }

    public void qusebutton() {
        qusebool = true;
    }

    private void Awake() {
        _trans = transform;
    }

    private void Update() {
        _trans.position = new Vector3(
            _trans.transform.position.x,
            -3.416f,
            _trans.transform.position.z
        );
    }

    private IEnumerator OnMouseDown() {
        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);
        _vec3MouseScreenSpace = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            _vec3TargetScreenSpace.z
        );
        _vec3Offset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);
        while (Input.GetMouseButton(0)) {
            _vec3MouseScreenSpace = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                _vec3TargetScreenSpace.z
            );
            _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;
            _trans.position = _vec3TargetWorldSpace;
            yield return new WaitForFixedUpdate();
        }
    }
}