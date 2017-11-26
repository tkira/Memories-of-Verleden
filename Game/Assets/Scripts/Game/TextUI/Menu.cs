using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject charMenu;
	public GameObject journal;

	public PauseGame pause;

	public PlayerStats playerStats;
	public Text strength;
	public Text vitality;
	public Text intelligence;
	public Text wisdom;
	public Text dexterity;
	public Text defence;
	public Text lvl;
	public Text expNeeded;
	public Text totalExp;

	public Text totalDamage;
	public Text totalMagicDam;
	public Text crit;
	public Text magicCrit;
	public Text dodge;
	public Text armor;
	public Text lightDefence;
	public Text darkDefence;

	public Text statPoints;

	public Text health;

	public GameObject addStrength;
	public GameObject addIntelligence;
	public GameObject addWisdom;
	public GameObject addDexterity;
	public GameObject addVitality;
	public GameObject addDefence;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.P)) {
			if (charMenu.activeInHierarchy == true) {
				charMenu.SetActive (false);
				pause.pauseGame (false);
			} else {
				charMenu.SetActive (true);
				pause.pauseGame (true);
			}
			if (journal.activeInHierarchy == true) {
				journal.SetActive (false);
			}
		}

		health.text = "HEALTH: " + playerStats.playerCurrentHealth + "/" + playerStats.maxHealth;
		statPoints.text = "" + playerStats.statPoints;
		strength.text = "" + playerStats.Strength;
		intelligence.text = "" + playerStats.Intelligence;
		dexterity.text = "" + playerStats.Dexterity;
		wisdom.text = "" + playerStats.wisdom;
		vitality.text = "" + playerStats.Vitality;
		defence.text = "" + playerStats.Defence;
		lvl.text = "Level: " + playerStats.currentLvl;
		expNeeded.text = "Exp: " + playerStats.currentExp + "/" + playerStats.expNeedToLvl;
		totalExp.text = "Total: " + playerStats.totalExp;

		totalDamage.text = "" + playerStats.totalDamage;
		totalMagicDam.text = "" + playerStats.totalMagicDam;
		crit.text = "" + playerStats.crit;
		magicCrit.text = "" + playerStats.magicCrit + "%";
		dodge.text = "" + playerStats.dodge + "%";
		armor.text = "" + playerStats.armor + "%";
		lightDefence.text = "" + playerStats.lightDefence + "%";
		darkDefence.text = "" + playerStats.darkDefence + "%";

		if (playerStats.statPoints != 0) {
			addStrength.SetActive (true);
			addVitality.SetActive (true);
			addDefence.SetActive (true);
			addDexterity.SetActive (true);
			addIntelligence.SetActive (true);
			addWisdom.SetActive (true);

			} else {
			addStrength.SetActive (false);
			addVitality.SetActive (false);
			addDefence.SetActive (false);
			addIntelligence.SetActive (false);
			addDexterity.SetActive (false);
			addWisdom.SetActive (false);
		}
	}


	public void OpenMenu(){
		if (charMenu.activeInHierarchy == true) {
			charMenu.SetActive (false);
		} else {
			charMenu.SetActive (true);
		}
}
}
