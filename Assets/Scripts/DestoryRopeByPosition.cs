using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestoryRopeByPosition : MonoBehaviour
{
    Vector3 position;
    public GameObject target;

    void Start()
    {
        position = target.GetComponent<RecordRopeInitDestoryPosition>().getPosition();
    }

    void FixedUpdate()
    {
        if (this.transform.position.x < position.x)
        {
            Destroy(gameObject);
        }
    }
}
