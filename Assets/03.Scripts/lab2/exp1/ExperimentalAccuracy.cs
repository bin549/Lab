using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExperimentalAccuracy : MonoBehaviour {
    public GameObject[] jinducolor;
    public Color fadeColor = Color.green;
    public GameObject[] shiyantrue;
    public GameObject panel;
    public Text[] info;
    public int index;
    float[] shujujilu = new float[6];

    private void Awake() {
        for (int i = 0; i < jinducolor.Length; i++) {
            float alpha = jinducolor[i].GetComponent<Image>().color.a;
            alpha = 0f;
            fadeColor.a = alpha;
            jinducolor[i].GetComponent<Image>().color = fadeColor;
        }
    }

    private void Update() {
        if (
            shiyantrue[0].activeSelf
            && shiyantrue[1].activeSelf
            && shiyantrue[2].activeSelf
            && shiyantrue[3].activeSelf
            && shiyantrue[4].activeSelf
            && shiyantrue[5].activeSelf
            && shiyantrue[6].activeSelf
            && shiyantrue[7].activeSelf
            && shiyantrue[8].activeSelf
            && shiyantrue[9].activeSelf
            && shiyantrue[10].activeSelf
            && shiyantrue[11].activeSelf
            && shiyantrue[12].activeSelf
        ) {
            float alpha = jinducolor[0].GetComponent<Image>().color.a;
            alpha = 1f;
            fadeColor.a = alpha;
            jinducolor[0].GetComponent<Image>().color = fadeColor;
        }
    }

    public void dierbu() {
        float alpha = jinducolor[1].GetComponent<Image>().color.a;
        alpha = 1f;
        fadeColor.a = alpha;
        jinducolor[1].GetComponent<Image>().color = fadeColor;
    }

    public void disanbu() {
        float alpha = jinducolor[2].GetComponent<Image>().color.a;
        alpha = 1f;
        fadeColor.a = alpha;
        jinducolor[2].GetComponent<Image>().color = fadeColor;
    }

    public void disibu() {
        float alpha = jinducolor[3].GetComponent<Image>().color.a;
        alpha = 1f;
        fadeColor.a = alpha;
        jinducolor[3].GetComponent<Image>().color = fadeColor;
    }

    public void jilu() {
        if (index >= 3) {
            index = 0;
        }
        if (index == 0) {
            shujujilu[0] = BulbClosure.instance._v * 10f / 4;
            info[0].text = (BulbClosure.instance._v * 10f / 4).ToString();
            shujujilu[1] = BulbClosure.instance._v * 10f / 4 / 5;
            info[3].text = (BulbClosure.instance._v * 10f / 4 / 5).ToString();
        }
        if (index == 1) {
            shujujilu[2] = BulbClosure.instance._v * 10f / 4;
            info[1].text = (BulbClosure.instance._v * 10f / 4).ToString();
            shujujilu[3] = BulbClosure.instance._v * 10f / 4 / 5;
            info[4].text = (BulbClosure.instance._v * 10f / 4 / 5).ToString();
        }
        if (index == 2) {
            shujujilu[4] = BulbClosure.instance._v * 10f / 4;
            info[2].text = (BulbClosure.instance._v * 10f / 4).ToString();
            shujujilu[5] = BulbClosure.instance._v * 10f / 4 / 5;
            info[5].text = (BulbClosure.instance._v * 10f / 4 / 5).ToString();
        }
        index++;
    }

    public void chakan() {
        panel.SetActive(!panel.activeSelf);
        info[6].text = (shujujilu[0] / shujujilu[1]).ToString();
        info[7].text = (shujujilu[2] / shujujilu[3]).ToString();
        info[8].text = (shujujilu[4] / shujujilu[5]).ToString();
        info[9].text = ((
                    (shujujilu[0] / shujujilu[1])
                    + (shujujilu[2] / shujujilu[3])
                    + (shujujilu[4] / shujujilu[5])
                ) / 3
            ).ToString();
        if (info[9].text != null) {
            float alpha = jinducolor[4].GetComponent<Image>().color.a;
            alpha = 1f;
            fadeColor.a = alpha;
            jinducolor[4].GetComponent<Image>().color = fadeColor;
        }
    }

    public void chongzhi() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}