using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	public int damage;
	public float reducedDamage;
	public int armorRating;
	public float finalDamageOutput;
	public int convertedDam;

	bool keyDelay;
	public GameObject damageEffect;
	public Transform hitPoint;
	public GameObject damageNumber;
	public EnemyBehaviour ene;
	public MonsterStats monsterStats;
	public PlayerStats playerStats;

	public float knockBack = 1000;

	public Movement move;

	// Use this for initialization
	void Start () {
		damage = monsterStats.monsterDamage;
	}
	
	// Update is called once per frame
	void Update () {
		damage = monsterStats.monsterDamage;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" && keyDelay == false) {
			if (ene.attacked == false) {
				damage = monsterStats.monsterDamage;

				//Reduce Damage from Armor
				if (playerStats.armor > 0) {
					armorRating = 100 - playerStats.armor;
					reducedDamage = damage * 1.0f / 100;
					finalDamageOutput = reducedDamage * armorRating;
					convertedDam = Mathf.RoundToInt (finalDamageOutput);
				} else {
					convertedDam = monsterStats.monsterDamage;
				}


				//KnockBack WIP
				//Vector2 direction = (transform.position - other.transform.position).normalized;

				//other.GetComponent<Rigidbody2D>().AddForce (direction * knockBack);


				Debug.Log (armorRating);
				Debug.Log (reducedDamage);
				Debug.Log (finalDamageOutput);
				Debug.Log (convertedDam);


				other.gameObject.GetComponent<PlayerHealthSystem> ().HurtPlayer (convertedDam);
				Instantiate (damageEffect, hitPoint.position, hitPoint.rotation);
				var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, hitPoint.rotation);
				clone.GetComponent<FloatingNumbers> ().damageNum = convertedDam;
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
