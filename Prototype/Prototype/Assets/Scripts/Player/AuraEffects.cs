using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraEffects : MonoBehaviour {

	private Animator ani;
	public bool lvlUp;

	// Use this for initialization
	void Start () {
		ani = GetComponent < Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lvlUp == true) {
			ani.SetBool ("lvlUp", true);
			StartCoroutine (delay ());
		}
			
	}

	IEnumerator delay(){
		yield return new WaitForSeconds(1f);
		ani.SetBool ("lvlUp", false);
		lvlUp = false;
	}
}
