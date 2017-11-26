using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalDamageDealt : MonoBehaviour {

	public GameObject damageEffect;
	public Transform hitPoint;
	public GameObject damageNumber;

	private int chance;

	public Weapon weap;
	public PlayerStats playerStat;
	private float calculateDamage;
	public ActivateSkill skill;

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
			if (weap.keyDelay == true) {

				//Calculate Damage
				calculateDamage = playerStat.totalDamage;

				if (skill.focusActive) {
					calculateDamage = calculateDamage * 2;
				}

				chance = Random.Range (0, playerStat.crit);
				if (chance < playerStat.crit) {
					calculateDamage = calculateDamage * 2;
				}
			
				other.gameObject.GetComponent<MonsterStats> ().HurtMonster ((int)calculateDamage);
				var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, hitPoint.rotation);
				clone.GetComponent<FloatingNumbers> ().damageNum = calculateDamage.ToString();
				weap.keyDelay = false;

				Vector2 direction = (other.transform.position - transform.position).normalized;

				other.GetComponent<Rigidbody2D>().AddForce (direction * other.GetComponent<EnemyBehaviour> ().knockBackStrength);

				other.GetComponent<EnemyBehaviour> ().knocked = true;

				if (playerStat.powerBar < 100) {
					playerStat.powerBar = playerStat.powerBar + 5; 
				}
			}
			}
		}
	}
