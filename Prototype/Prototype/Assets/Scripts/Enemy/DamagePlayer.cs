using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	public int damage;
	bool keyDelay;
	public GameObject damageEffect;
	public Transform hitPoint;
	public GameObject damageNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" && keyDelay == false) {
			other.gameObject.GetComponent<PlayerHealthSystem> ().HurtPlayer (damage);
			Instantiate (damageEffect, hitPoint.position, hitPoint.rotation);
			var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, hitPoint.rotation);
			clone.GetComponent<FloatingNumbers> ().damageNum = damage;
			StartCoroutine (delay ());
		}
	}

	IEnumerator delay(){
		keyDelay = true;
		yield return new WaitForSeconds(.3f);
		keyDelay = false;
	}
}
