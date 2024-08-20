using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryRope : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Rope"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Rope"))
        {
            Destroy(other.gameObject);
        }
    }
}
