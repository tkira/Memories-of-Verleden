using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {

	public GameObject damageNumber;

	private int chance;
	private float calculateDamage;


	void Update(){

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject);
			//Calculate Damage
			calculateDamage = GameObject.Find ("Player").GetComponent<PlayerStats> ().totalMagicDam;

			calculateDamage = calculateDamage / 2;
			Debug.Log (calculateDamage);

			if (GameObject.Find ("Skills").GetComponent<ActivateSkill> ().focusActive) {
				calculateDamage = calculateDamage * 2;
			}

			chance = Random.Range (0, GameObject.Find ("Player").GetComponent<PlayerStats> ().magicCrit);
			if (chance < GameObject.Find ("Player").GetComponent<PlayerStats> ().magicCrit) {
				calculateDamage = calculateDamage * 2;
			}

			Mathf.RoundToInt (calculateDamage);

			other.gameObject.GetComponent<MonsterStats> ().HurtMonster (Mathf.RoundToInt (calculateDamage));
			var clone = (GameObject)Instantiate (damageNumber, other.transform.position, other.transform.rotation);
			clone.GetComponent<FloatingNumbers> ().damageNum = (Mathf.RoundToInt (calculateDamage) * 2).ToString ();

			Vector2 direction = (other.transform.position - transform.position).normalized;

			other.GetComponent<Rigidbody2D> ().AddForce (direction * other.GetComponent<EnemyBehaviour> ().knockBackStrengthRanged);

			other.GetComponent<EnemyBehaviour> ().knocked = true;

			Destroy (gameObject);

			if (GameObject.Find ("Player").GetComponent<PlayerStats> ().powerBar < 100) {
				GameObject.Find ("Player").GetComponent<PlayerStats> ().powerBar = GameObject.Find ("Player").GetComponent<PlayerStats> ().powerBar + 5; 
			}
		}
		if (other.gameObject.tag == "Bounds"){
			Destroy (gameObject);
		}
		}
	}

