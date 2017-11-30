using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTown : MonoBehaviour {

	public AudioSource vill;
	public AudioSource plains;

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			vill.Play ();
			plains.Stop ();
		}
	}
}
