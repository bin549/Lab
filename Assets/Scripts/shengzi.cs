using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shengzi : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform hualun;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       lineRenderer.SetPosition(0,transform.position );
        lineRenderer.SetPosition(1,hualun.transform.position );
    }
}
