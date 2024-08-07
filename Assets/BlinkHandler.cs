using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpen = true;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.isOpen = !this.isOpen;
            if (this.isOpen) 
            {
                this.animator.SetTrigger("open");
            } 
            else
            {
                this.animator.SetTrigger("close");
            }
        }
    }
}
