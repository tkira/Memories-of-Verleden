using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int currentLvl;
	public int currentExp;
	public int expNeedToLvl;
	public int totalExp;

	public int Strength;
	public int maxHealth;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentExp >= expNeedToLvl){
			currentLvl++;
			maxHealth = maxHealth + 10; 
			gameObject.GetComponent<PlayerHealthSystem> ().SetMaxHealth ();
		}
	}
}
