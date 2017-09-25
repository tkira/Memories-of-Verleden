﻿using UnityEngine;
using System.Collections;

public class WarpA : MonoBehaviour {

	public Transform warpTarget;
	public CameraFollow camBools;

	IEnumerator OnTriggerEnter2D(Collider2D other){

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		Debug.Log ("Warp Start");
		yield return StartCoroutine (sf.FadeToBlack ());

		Debug.Log ("Warp Detected");

		GameObject wB = GameObject.FindGameObjectWithTag ("MainCamera");
		camBools = wB.GetComponent<CameraFollow> ();
		camBools.bounds = true;
		camBools.bounds2 = false;

		other.gameObject.transform.position = warpTarget.position;
		Camera.main.transform.position = warpTarget.position;

		yield return StartCoroutine (sf.FadeToClear ());

		Debug.Log ("Warp Complete");
	}

}
