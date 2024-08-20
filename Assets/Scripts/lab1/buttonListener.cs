using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class buttonListener : MonoBehaviour
{
	private bool flag;
	
	public GameObject lab1;

	public GameObject menu;
	
	private void Start () {
		flag = true;
	}
	
	private void B1Pressed(object sender) {
		if (flag)
		{
			lab1.SetActive(false);
			menu.SetActive(true);
			flag = false;

		} else
		{
			lab1.SetActive(true);
			menu.SetActive(false);
			flag = true;
			
		}
	}

}
