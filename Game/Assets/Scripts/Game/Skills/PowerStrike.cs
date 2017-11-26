using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStrike : MonoBehaviour {

	public GameObject damageEffect;
	public GameObject damageNumber;

	private int chance;

	public PlayerStats playerStat;
	private float calculateDamage;
	public ActivateSkill skill;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject);
				//Calculate Damage
				calculateDamage = playerStat.totalDamage;

				calculateDamage = calculateDamage * playerStat.skillPowerStrike;

				if (skill.focusActive) {
					calculateDamage = calculateDamage * 2;
				}

				chance = Random.Range (0, playerStat.crit);
				if (chance < playerStat.crit) {
					calculateDamage = calculateDamage * 2;
				}

				other.gameObject.GetComponent<MonsterStats> ().HurtMonster ((int)calculateDamage);

				Vector2 direction = (other.transform.position - transform.position).normalized;

				other.GetComponent<Rigidbody2D>().AddForce (direction * 2000);

				other.GetComponent<EnemyBehaviour> ().knocked = true;

				}
			}
		}

