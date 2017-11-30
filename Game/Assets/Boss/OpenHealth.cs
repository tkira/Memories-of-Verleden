using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHealth : MonoBehaviour {

	public GameObject health;

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			health.SetActive (true);
		}
	}
}
