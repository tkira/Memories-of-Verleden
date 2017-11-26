using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraShock : MonoBehaviour {

	public GameObject damageNumber;

	private int chance;
	private float calculateDamage;

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject);
			//Calculate Damage
			calculateDamage = GameObject.Find ("Player").GetComponent<PlayerStats> ().totalMagicDam;

			calculateDamage = calculateDamage / 2;
			Debug.Log (calculateDamage);

			calculateDamage = calculateDamage * GameObject.Find ("Player").GetComponent<PlayerStats> ().skillauraShock; //Aura damage 2

			if (GameObject.Find ("Skills").GetComponent<ActivateSkill> ().focusActive) {
				calculateDamage = calculateDamage * 2;
			}

			chance = Random.Range (0, GameObject.Find ("Player").GetComponent<PlayerStats> ().magicCrit);
			if (chance < GameObject.Find ("Player").GetComponent<PlayerStats> ().magicCrit) {
				calculateDamage = calculateDamage * 2;
			}

			Mathf.RoundToInt (calculateDamage);

			other.gameObject.GetComponent<MonsterStats> ().HurtMonster (Mathf.RoundToInt (calculateDamage));

			Vector2 direction = (other.transform.position - transform.position).normalized;

			other.GetComponent<Rigidbody2D> ().AddForce (direction * 1000);

			other.GetComponent<EnemyBehaviour> ().knocked = true;

			}
		}
	}