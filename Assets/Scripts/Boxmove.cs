using UnityEngine;
using System.Collections;

public class Boxmove : MonoBehaviour {
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

   
    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            Vector3 targetDirection = new Vector3(h, 0, v);
            float y = Camera.main.transform.rotation.eulerAngles.y;
            targetDirection = Quaternion.Euler(0, y, 0) * targetDirection;

            transform.Translate(targetDirection * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
   
}
