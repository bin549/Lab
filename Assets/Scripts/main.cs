using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour {
    public void jiasudu() {
        SceneManager.LoadScene("重力加速度");
    }
    
    public void mocali() {
        SceneManager.LoadScene("摩擦力");
    }
    
    public void midu() {
        SceneManager.LoadScene("天平");
    }
    
    public void sanyuanse() {
        SceneManager.LoadScene("三原色");
    }
    
    public void PH() {
        SceneManager.LoadScene("PH酸碱性");
    }
}