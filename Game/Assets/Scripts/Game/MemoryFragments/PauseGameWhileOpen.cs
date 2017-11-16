using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameWhileOpen : MonoBehaviour {

	public GameObject page;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (page.activeInHierarchy == true) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}
