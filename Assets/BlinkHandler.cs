using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlinkHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpen = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.isOpen = !this.isOpen;
            this.animator.SetBool("isOpen", this.isOpen);
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && !this.isOpen)
        {
            StartCoroutine(this.SceneBack(LabsTag.START_SCENE));
        }
    }


    private IEnumerator SceneBack(string sceneName)
    {
        yield return new WaitForSeconds(0.0f);
        SceneManager.LoadScene(sceneName);
    }

}
