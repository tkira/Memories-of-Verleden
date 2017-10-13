using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int currentLvl;
	public int currentExp;
	public int expNeedToLvl;
	public int totalExp;

	public int statPoints;

	public int Strength;
	public int Vitality;
	public int Defence;

	public int maxHealth;
	public AuraEffects arua;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentExp >= expNeedToLvl){
			currentLvl++;
			maxHealth += 10; 
			statPoints += 5; 
			gameObject.GetComponent<PlayerHealthSystem> ().SetMaxHealth ();

			arua.lvlUp = true;

			currentExp -= expNeedToLvl;	//Reset Exp bar and keep extra exp

			expNeedToLvl = expNeedToLvl * 2; //Double exp need for next lvl;
		}
}

	public void addStrength(){
		Strength++;
		statPoints--;
	}

	public void addVitality(){
		Vitality++;
		statPoints--;
	}

	public void addDefence(){
		Defence++;
		statPoints--;
	}
}