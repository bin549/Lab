using UnityEngine;

public class pengzhaung : MonoBehaviour  {
    public string collname;//需要判断的物体名字
    public GameObject obj;//碰撞显示的物体
    public GameObject tishitext;//碰撞清除的提示

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == collname) {
            Destroy(other.gameObject);//销毁碰撞到的物体
            obj.SetActive(true);//显示实际物体
            this.GetComponent<BoxCollider>().enabled = false;//关闭触发器，防止无限触发（本文碰撞器就是触发器）
            if (tishitext != null)//有些物体没有提示文本，判空操作
            {
                tishitext.SetActive(false);//关闭提示文本
            }
        }
    }
}