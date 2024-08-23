using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entry2 : MonoBehaviour {
	void Start() {
		this.GetComponent<Button>().onClick.AddListener(OnClick);
	}

	void OnClick() {
		SceneManager.LoadScene("experiment2");
	}
}
