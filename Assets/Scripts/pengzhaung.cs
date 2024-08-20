using UnityEngine;

public class pengzhaung : MonoBehaviour  {
    public string collname;
    public GameObject obj;
    public GameObject tishitext;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == collname) {
            Destroy(other.gameObject);
            obj.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            if (tishitext != null) {
                tishitext.SetActive(false);
            }
        }
    }
}