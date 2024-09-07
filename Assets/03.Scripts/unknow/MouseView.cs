using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseView : MonoBehaviour {
    public static MouseView ins;

    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    public RotationAxes m_axes = RotationAxes.MouseXAndY;
    public float m_sensitivityX = 10f;
    public float m_sensitivityY = 10f;
    public float m_minimumX = -360f;
    public float m_maximumX = 360f;

    public float m_minimumY = -25f;
    public float m_maximumY = 25f;

    float m_rotationY = 0f;
    public Text text1;
    public Text text;
    public GameObject[] fama;
    public int carKG = 1000;
    public Text carkg;
    public int heziKG = 1000;
    public Text hezikg;

    Ray ray;
    RaycastHit hit;
    GameObject obj;
    public GameObject[] mukuaitiekuai;

    private void Awake() {
        ins = this;
    }

    private void Start() {
        for (int i = 5; i < fama.Length; i++) {
            fama[i].SetActive(false);
        }
        if (GetComponent<Rigidbody>()) {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    private void OnMouseEnter() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            obj = hit.collider.gameObject;
        }
    }

    private void Update() {
        carkg.text = "С������" + carKG.ToString() + "g";
        hezikg.text = "��������" + heziKG.ToString();
        OnMouseEnter();
        if (Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                obj = hit.collider.gameObject;

                if (obj.name.Equals("����0")) {
                    carKG += 1000;
                    fama[0].SetActive(false);
                    fama[5].SetActive(true);
                    xiaoche.Singleton.kg += 1;
                }
                if (obj.name.Equals("����1")) {
                    carKG += 1000;
                    fama[1].SetActive(false);
                    fama[6].SetActive(true);
                    xiaoche.Singleton.kg += 1;
                }
                if (obj.name.Equals("����2")) {
                    carKG += 1000;
                    fama[2].SetActive(false);
                    fama[7].SetActive(true);
                    xiaoche.Singleton.kg += 1;
                }
                if (obj.name.Equals("����3")) {
                    heziKG += 1000;
                    fama[3].SetActive(false);
                    fama[8].SetActive(true);
                    xiaoche.Singleton.kh += 1;
                }
                if (obj.name.Equals("����4")) {
                    heziKG += 1000;
                    fama[4].SetActive(false);
                    fama[9].SetActive(true);
                    xiaoche.Singleton.kh += 1;
                }
                if (obj.name.Equals("mukuai")) {
                    obj.gameObject.SetActive(false);
                    mukuaitiekuai[0].SetActive(true);
                    mocali.instance.text[0].text = "2.4";
                    mocali.instance.text[1].text = "1";
                    mocali.instance.text[2].text = "9.8";
                    mocali.instance.text[3].text = "30";
                    mocali.instance.text[4].text = "2.5";
                    mocali.instance.text[5].text = "0.295";
                    mocali.instance.names = "ľ���";
                }
                if (obj.name.Equals("tiekuai")) {
                    obj.gameObject.SetActive(false);
                    mukuaitiekuai[1].SetActive(true);
                    mocali.instance.text[0].text = "2.4";
                    mocali.instance.text[1].text = "1";
                    mocali.instance.text[2].text = "9.8";
                    mocali.instance.text[3].text = "30";
                    mocali.instance.text[4].text = "2.5";
                    mocali.instance.text[5].text = "0.295";
                    mocali.instance.names = "����С";
                }
                if (obj.name.Equals("mukuai1")) {
                    obj.gameObject.SetActive(false);
                    mukuaitiekuai[2].SetActive(true);
                    mocali.instance.text[0].text = "2.4";
                    mocali.instance.text[1].text = "0.1";
                    mocali.instance.text[2].text = "9.8";
                    mocali.instance.text[3].text = "30";
                    mocali.instance.text[4].text = "0.25";
                    mocali.instance.text[5].text = "0.295";
                    mocali.instance.names = "ľ��С";
                }
                if (obj.name.Equals("tiekuai1")) {
                    obj.gameObject.SetActive(false);
                    mukuaitiekuai[3].SetActive(true);
                    mocali.instance.text[0].text = "2.4";
                    mocali.instance.text[1].text = "20";
                    mocali.instance.text[2].text = "9.8";
                    mocali.instance.text[3].text = "30";
                    mocali.instance.text[4].text = "50";
                    mocali.instance.text[5].text = "0.295";
                    mocali.instance.names = "�����";
                }
            }
        }
        if (Input.GetMouseButton(1)) {
            if (m_axes == RotationAxes.MouseXAndY) {
                float m_rotationX =
                    transform.localEulerAngles.y + Input.GetAxis("Mouse X") * m_sensitivityX;
                m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
                m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

                transform.localEulerAngles = new Vector3(-m_rotationY, m_rotationX, 0);
            }
            else if (m_axes == RotationAxes.MouseX) {
                transform.Rotate(0, Input.GetAxis("Mouse X") * m_sensitivityX, 0);
            }
            else {
                m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
                m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

                transform.localEulerAngles = new Vector3(
                    -m_rotationY,
                    transform.localEulerAngles.y,
                    0
                );
            }
        }
    }

    public void chongzhi() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainscene() {
        SceneManager.LoadScene("main");
    }
}
