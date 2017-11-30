using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	float timer;
	float LastPress;
	public Animator animator;
	public bool keyDelay;
	public AudioSource attack;

	void Start(){
		animator = GetComponent < Animator>();
		keyDelay = false;
		animator.SetBool ("Attack", false);
	}

	void Update () {
		timer = Time.timeSinceLevelLoad;

		if (Input.GetKeyDown (KeyCode.K) && !keyDelay) {
			LastPress = Time.timeSinceLevelLoad;
			animator.SetBool ("Attack", true);
			keyDelay = true;
				attack.Play();
		}		
		if (timer - LastPress > 0.4f) {
			animator.SetBool ("Attack", false);
			keyDelay = false;

		}
	}
}