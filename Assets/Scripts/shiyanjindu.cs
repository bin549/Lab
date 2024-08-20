using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shiyanjindu : MonoBehaviour {
    public GameObject[] jinducolor; //5个提示进度颜色
    public Color fadeColor = Color.green; //进度默认颜色
    public GameObject[] shiyantrue; //13个器材
    public GameObject panel; //开始界面
    public Text[] info; //10个数据显示
    public int index; //数据测量计数
    float[] shujujilu = new float[6]; //6个数据缓存

    private void Awake() {
        for (int i = 0; i < jinducolor.Length; i++) {
            float alpha = jinducolor[i].GetComponent<Image>().color.a;
            alpha = 0f;
            fadeColor.a = alpha;
            jinducolor[i].GetComponent<Image>().color = fadeColor;
        }
    }

    private void Update() { //判断第一步是否完成
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

    public void dierbu() //判断第二步是否完成 {
        float alpha = jinducolor[1].GetComponent<Image>().color.a;
        alpha = 1f;
        fadeColor.a = alpha;
        jinducolor[1].GetComponent<Image>().color = fadeColor;
    }

    public void disanbu() //判断第三步是否完成 {
        float alpha = jinducolor[2].GetComponent<Image>().color.a;
        alpha = 1f;
        fadeColor.a = alpha;
        jinducolor[2].GetComponent<Image>().color = fadeColor;
    }

    public void disibu() //判断第四步是否完成 {
        float alpha = jinducolor[3].GetComponent<Image>().color.a;
        alpha = 1f;
        fadeColor.a = alpha;
        jinducolor[3].GetComponent<Image>().color = fadeColor;
    }

    public void jilu() //记录数据 {
        if (index >= 3) {
            index = 0;
        }
        if (index == 0) {
            shujujilu[0] = 翻转.ins._v * 10f / 4;
            info[0].text = (翻转.ins._v * 10f / 4).ToString();
            shujujilu[1] = 翻转.ins._v * 10f / 4 / 5;
            info[3].text = (翻转.ins._v * 10f / 4 / 5).ToString();
        }
        if (index == 1) {
            shujujilu[2] = 翻转.ins._v * 10f / 4;
            info[1].text = (翻转.ins._v * 10f / 4).ToString();
            shujujilu[3] = 翻转.ins._v * 10f / 4 / 5;
            info[4].text = (翻转.ins._v * 10f / 4 / 5).ToString();
        }
        if (index == 2) {
            shujujilu[4] = 翻转.ins._v * 10f / 4;
            info[2].text = (翻转.ins._v * 10f / 4).ToString();
            shujujilu[5] = 翻转.ins._v * 10f / 4 / 5;
            info[5].text = (翻转.ins._v * 10f / 4 / 5).ToString();
        }
        index++;
    }

    public void chakan() //查看数据页面，并计算最终结果 {
        panel.SetActive(!panel.activeSelf);
        info[6].text = (shujujilu[0] / shujujilu[1]).ToString();
        info[7].text = (shujujilu[2] / shujujilu[3]).ToString();
        info[8].text = (shujujilu[4] / shujujilu[5]).ToString();
        info[9].text = (
            (
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

    public void chongzhi() //重新开始实验 {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
