using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	float timer;
	float LastPress;
	public Animator animator;
	public bool keyDelay;

	void Start(){
		animator = GetComponent < Animator>();
		keyDelay = false;
		animator.SetBool ("Attack", true);
	}

	void Update () {
		timer = Time.timeSinceLevelLoad;

		if (Input.GetKeyDown (KeyCode.K) && !keyDelay) {
			LastPress = Time.timeSinceLevelLoad;
			animator.SetBool ("Attack", true);
			keyDelay = true;
		}		
		if (timer - LastPress > 0.4f) {
			animator.SetBool ("Attack", false);
			keyDelay = false;

		}
	}
}