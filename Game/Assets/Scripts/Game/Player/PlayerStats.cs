using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public Transform playerPos;

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

	public int memoryCount;

	public int skillHeal;
	public int skillHealCD;

	public int skillPowerStrike;
	public int skillPowerStrikeCD;

	public int skillFireball;
	public int skillFireballCD;

	public int skillFocus;
	public int skillFocusCD;

	public int skillauraShock;
	public int skillauraShockCD;

	private bool regenActiveP;
	private bool regenActiveH;

	public int healPotion;
	public int healPotionNo;
	public int healPotionMax;

	public GameObject lvlUP;
	public Transform hitPoint;

	// Use this for initialization
	void Start () {
		regenActiveH = false;
		regenActiveP = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (powerBar < 100 && !regenActiveP) {
			regenActiveP = true;
			StartCoroutine (regenPower ());
		} else if (powerBar > 100) {
			powerBar = 100;
		}
			
		if (playerCurrentHealth < maxHealth && !regenActiveH) {
			regenActiveH = true;
			StartCoroutine (regenPower ());
		} else if (playerCurrentHealth > maxHealth){
			playerCurrentHealth = maxHealth;
		}
			
		if (currentExp >= expNeedToLvl){
			currentLvl++;
			maxHealth += 10; 
			statPoints += 5; 
			gameObject.GetComponent<PlayerHealthSystem> ().SetMaxHealth ();

			var clone = (GameObject)Instantiate (lvlUP, hitPoint.position, hitPoint.rotation);

			arua.lvlUp = true;

			currentExp -= expNeedToLvl;	//Reset Exp bar and keep extra exp

			expNeedToLvl = expNeedToLvl * 2; //Double exp need for next lvl;

		}
}

	IEnumerator regenPower(){
		while (powerBar < 100) {
			yield return new WaitForSeconds(1);
			powerBar = powerBar + 1;
		}
		regenActiveP = false;
	}

	IEnumerator regenHealth(){
		while (playerCurrentHealth < maxHealth) {
			yield return new WaitForSeconds(1);
			playerCurrentHealth = playerCurrentHealth + 1;
		}
		regenActiveH = false;
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