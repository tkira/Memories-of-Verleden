using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealGem : MonoBehaviour {

	private AudioSource a;

	void Start(){
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			GameObject.Find ("Player").GetComponent<PlayerStats> ().healPotion = GameObject.Find ("Player").GetComponent<PlayerStats> ().healPotion + 25;
			Destroy (gameObject);
		}
	}
}
