using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public int tap = 0;
	bool attack = true;
	float timer;
	float LastPress;
	public Animator animator;
	public string Combo1 = "SwordCombo1";
	public string Combo2 = "SwordCombo2";
	public string Combo3 = "SwordCombo3";
	//public string Combo4 = "SpinAttack";
	bool keyDelay;

	public PlayerStats playerStats;
	public int playerStatDamage;

	public GameObject weapon;

	void Start(){
		animator = GetComponent < Animator>();
		keyDelay = false;
		weapon = GameObject.FindGameObjectWithTag ("Weapon");
		weapon.SetActive (false);
		playerStatDamage = playerStats.Strength;
	}

	void Update () {
		timer = Time.timeSinceLevelLoad;

		if (Input.GetKey (KeyCode.K) && !keyDelay) {
			LastPress = Time.timeSinceLevelLoad;

			if (tap > 3) {
				tap = 1;
			} else {
				tap++;
			}
			weapon.SetActive (true);
			Combo ();
		}		
		if (timer - LastPress > 1) {
			tap = 0;
		}
	}

	void Combo ()
	{
		if (attack == true) {
			switch (tap) {
			case 0:
				//Reset to idle
				break;

			case 1:
				//Combo1
				animator.Play (Combo1);
				StartCoroutine (delay());
				break;

			case 2:
				//Combo1
				animator.Play (Combo2);
				StartCoroutine (delay());
				break;

			case 3:
				//Combo1
				animator.Play (Combo3);
				StartCoroutine (delay());
				break;
		}
		}
	}

	IEnumerator delay(){
		keyDelay = true;
		yield return new WaitForSeconds(.5f);
		weapon.SetActive (false);
		keyDelay = false;
	}

}