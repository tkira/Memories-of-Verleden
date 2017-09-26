using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {

	public int weaponDamage;
	public GameObject damageEffect;
	public Transform hitPoint;

	public GameObject damageNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject);
			other.gameObject.GetComponent<MonsterHealth> ().HurtMonster (weaponDamage);
			Instantiate (damageEffect, hitPoint.position, hitPoint.rotation);
			var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, hitPoint.rotation);
			clone.GetComponent<FloatingNumbers> ().damageNum = weaponDamage;
		}
	}
}
