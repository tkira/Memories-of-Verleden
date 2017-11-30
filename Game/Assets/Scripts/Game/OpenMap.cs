using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour {

	public GameObject map;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.M)) {
			if (map.activeInHierarchy == true) {
				map.SetActive (false);
			} else {
				map.SetActive (true);
			}
		}
		}
	}
