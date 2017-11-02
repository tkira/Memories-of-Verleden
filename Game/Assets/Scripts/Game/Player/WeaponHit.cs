using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour {

	public GameObject damageEffect;
	public Transform hitPoint;
	public GameObject damageNumber;

	public Weapon weap;
	public PlayerStats playerStat;
	private float calculateDamage;
	public UIManager UI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		calculateDamage = playerStat.Strength + 2;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject);
			if (weap.keyDelay == true) {
				other.gameObject.GetComponent<MonsterStats> ().HurtMonster ((int)calculateDamage);
				var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, hitPoint.rotation);
				clone.GetComponent<FloatingNumbers> ().damageNum = (int)calculateDamage;
				weap.keyDelay = false;

				UI.monsterName.text = other.gameObject.GetComponent<MonsterStats>().monsterName;
				UI.monsterHealth = other.gameObject.GetComponent<MonsterStats>().monsterHealth;
				UI.monsterMaxHealth = other.gameObject.GetComponent<MonsterStats> ().monsterMaxHealth;
			}
			}
		}
	}
