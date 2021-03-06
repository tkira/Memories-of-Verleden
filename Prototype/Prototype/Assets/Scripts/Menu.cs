using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject menu;

	public PlayerStats playerStats;
	public Text strength;
	public Text vitality;
	public Text defence;
	public Text lvl;
	public Text expNeeded;
	public Text totalExp;

	public Text statPoints;

	public GameObject addStrength;
	public GameObject addVitality;
	public GameObject addDefence;

	// Update is called once per frame
	void Update () {
		statPoints.text = "" + playerStats.statPoints;
		strength.text = "" + playerStats.Strength;
		vitality.text = "" + playerStats.Vitality;
		defence.text = "" + playerStats.Defence;
		lvl.text = "Level: " + playerStats.currentLvl;
		expNeeded.text = "Exp: " + playerStats.currentExp + "/" + playerStats.expNeedToLvl;
		totalExp.text = "Total: " + playerStats.totalExp;

		if (playerStats.statPoints != 0) {
			addStrength.SetActive (true);
			addVitality.SetActive (true);
			addDefence.SetActive (true);
		} else {
			addStrength.SetActive (false);
			addVitality.SetActive (false);
			addDefence.SetActive (false);
		}

		if (menu.activeInHierarchy == true) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

}
