using System.Collections;
using UnityEngine;

public class shizhi : MonoBehaviour {
    public AnimationCurve curve; 
    public int intt;
    public GameObject yinjiprefab;
    public string text;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "水滴") {
            
        }
    }

    private void OnCollisionEnter(Collision ctl) {
        if (ctl.gameObject.name == "试纸1")  {
            ContactPoint contact = ctl.contacts[0];
            Vector3 pos = contact.point;
            GameObject go = Instantiate(
                yinjiprefab,
                new Vector3(pos.x, ctl.transform.position.y + 0.01f, pos.z),
                Quaternion.identity
            );
            go.GetComponent<Renderer>().material.color =
                this.GetComponent<Renderer>().material.color;
            go.gameObject.GetComponent<yinji>().intt = intt;
            go.gameObject.GetComponent<yinji>().text.text = text;
            Destroy(gameObject);
        }
        if (ctl.gameObject.name == "试纸2")  {
            ContactPoint contact = ctl.contacts[0];
            Vector3 pos = contact.point;
            GameObject go = Instantiate(
                yinjiprefab,
                new Vector3(pos.x, ctl.transform.position.y + 0.01f, pos.z),
                Quaternion.identity
            );
            go.GetComponent<Renderer>().material.color =
                this.GetComponent<Renderer>().material.color;
            go.gameObject.GetComponent<yinji>().intt = intt;
            go.gameObject.GetComponent<yinji>().text.text = text;
            Destroy(gameObject);
        }
        if (ctl.gameObject.name == "试纸3")  {
            ContactPoint contact = ctl.contacts[0];
            Vector3 pos = contact.point;
            GameObject go = Instantiate(
                yinjiprefab,
                new Vector3(pos.x, ctl.transform.position.y + 0.01f, pos.z),
                Quaternion.identity
            );
            go.GetComponent<Renderer>().material.color =
                this.GetComponent<Renderer>().material.color;
            go.gameObject.GetComponent<yinji>().intt = intt;
            go.gameObject.GetComponent<yinji>().text.text = text;
            Destroy(gameObject);
        }
    }
}
