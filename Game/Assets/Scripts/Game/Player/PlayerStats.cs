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
	public int Dexterity;
	public int wisdom;
	public int Intelligence;
	public int Vitality;
	public int Defence;

	public int totalDamage;
	public int totalMagicDam;
	public int crit;
	public int magicCrit;
	public int armor;
	public int dodge;
	public int lightDefence;
	public int darkDefence;

	public int maxPowerBar;
	public int powerBar;

	public int maxHealth;
	public int playerCurrentHealth;
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
		totalDamage = totalDamage + 5;
		maxHealth = maxHealth + 10;
		playerCurrentHealth = playerCurrentHealth + 10;
		statPoints--;
	}

	public void addVitality(){
		Vitality++;
		maxHealth = maxHealth + 40;
		playerCurrentHealth = playerCurrentHealth + 40;
		statPoints--;
	}

	public void addDefence(){
		Defence++;
		armor = armor + 2;
		statPoints--;
	}

	public void addDexterity(){
		Dexterity++;
		crit++;
		dodge++;
		statPoints--;
	}

	public void addIntelligence(){
		Intelligence++;
		totalMagicDam = totalMagicDam + 5;
		magicCrit++;
		statPoints--;
	}

	public void addWisdom(){
		wisdom++;
		lightDefence++;
		darkDefence++;
		magicCrit++;
		statPoints--;
	}
		
}