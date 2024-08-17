using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class buttonListener2 : MonoBehaviour
{
	
	private bool flag;
	

	public GameObject menu;
	
	// Use this for initialization
	void Start () {
		
		flag = true;

		


	}
	
	private void B1Pressed(object sender)
	{
		if (menu.activeSelf==false)
		{
//			print("run1");
			menu.SetActive(true);
			flag = false;

		}
		else
		{
			menu.SetActive(false);
			flag = true;
			
		}
		
		
	}

}
