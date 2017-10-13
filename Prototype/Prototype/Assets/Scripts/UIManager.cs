using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthSystem playerHealth;
	public PlayerStats playerStats;

	public Slider healthBarMonster;
	public Text HPTextMonster;
	public Text monsterName;
	public GameObject monsterBar;
	public int monsterHealth;
	public int monsterMaxHealth;

	public Slider playerExp;
	public Text playerExpText;
	public GameObject expBar;

	// Use this for initialization
	void Start () {
		monsterBar.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerStats.maxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "" + playerHealth.playerCurrentHealth + "/" + playerStats.maxHealth;

		healthBarMonster.maxValue = monsterMaxHealth;
		healthBarMonster.value = monsterHealth;
		HPTextMonster.text = "" + monsterHealth + "/" + monsterMaxHealth;

		playerExp.maxValue = playerStats.expNeedToLvl;
		playerExp.value = playerStats.currentExp;
		playerExpText.text = "" + playerStats.currentExp + "/" + playerStats.expNeedToLvl;

		if (monsterHealth < monsterMaxHealth){
			monsterBar.SetActive(true);
		}

		if (monsterHealth <= 0){
			monsterBar.SetActive(false);
		}
			
	}
}
