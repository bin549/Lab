using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hezi : MonoBehaviour
{
    Rigidbody rigidbody;
    public float hezispeed;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hezispeed = rigidbody.velocity.magnitude;
        
    }
    public void rigidbodyadd()
    {
        rigidbody.mass = rigidbody.mass + 1;

    }
    public void rigidbodyuse()
    {
        rigidbody.useGravity = true;
    }
    }
