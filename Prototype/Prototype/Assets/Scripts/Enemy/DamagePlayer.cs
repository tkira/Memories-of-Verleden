using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	public int damage;
	bool keyDelay;
	public GameObject damageEffect;
	public Transform hitPoint;
	public GameObject damageNumber;
	public EnemyBehaviour ene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" && keyDelay == false) {
			if (ene.attacked == false) {
				other.gameObject.GetComponent<PlayerHealthSystem> ().HurtPlayer (damage);
				Instantiate (damageEffect, hitPoint.position, hitPoint.rotation);
				var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, hitPoint.rotation);
				clone.GetComponent<FloatingNumbers> ().damageNum = damage;
				StartCoroutine (delay ());
			}
		}
	}

	IEnumerator delay(){
		keyDelay = true;
		ene.attacked = true;
		yield return new WaitForSeconds(1f);
		keyDelay = false;
		ene.attacked = false;
	}
}
