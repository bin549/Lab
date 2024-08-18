using System.Collections.Generic;
using UnityEngine;

public class 选中物体 : MonoBehaviour {
    public Texture2D tex;
    GameObject obj;
    public GameObject camera;
    public shiyanjindu shiyanjindu;

    private void Start() {
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                obj = hit.collider.gameObject;
                if (obj.name.Equals("学生电源")) {
                    camera.transform.position =new Vector3( obj.transform.position.x, obj.transform.position.y+0.40807f, obj.transform.position.z-0.4822f);
                }
                if (obj.name.Equals("开关")) {
                   
                    camera.transform.position = new Vector3(obj.transform.position.x+0.022f, obj.transform.position.y + 0.148f, obj.transform.position.z - 0.1256f);
                }
                if (obj.name.Equals("滑动电阻")) {
                    
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.2f, obj.transform.position.z - 0.2f);
                }
                if (obj.name.Equals("电流表")) {
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.15f, obj.transform.position.z - 0.15f);
                    shiyanjindu.disibu();
                }
                if (obj.name.Equals("电压表")) {
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.15f, obj.transform.position.z - 0.15f);
                    shiyanjindu.disibu();
                }
                if (obj.name.Equals("负载")) {
                    camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.2f, obj.transform.position.z - 0.2f);
                }
            }
        }
    }
}