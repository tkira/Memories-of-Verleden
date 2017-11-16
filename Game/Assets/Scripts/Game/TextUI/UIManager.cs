using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public bool powerBarFull;

	public Slider healthBar;
	public Text HPText;
	public PlayerStats playerStats;
	public PlayerHealthSystem playerHealth;

	public Slider powerBar;
	public Text powerBarText;

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
		healthBar.value = playerStats.playerCurrentHealth;
		HPText.text = "" + playerStats.playerCurrentHealth + "/" + playerStats.maxHealth;

		playerExp.maxValue = playerStats.expNeedToLvl;
		playerExp.value = playerStats.currentExp;
		playerExpText.text = "" + playerStats.currentExp + "/" + playerStats.expNeedToLvl;

		powerBar.maxValue = playerStats.maxPowerBar;
		powerBar.value = playerStats.powerBar;
		powerBarText.text = "" + playerStats.powerBar + "/" + playerStats.maxPowerBar;

	}
		
	public void bossHealth(){
		if (monsterHealth < monsterMaxHealth){
			monsterBar.SetActive(true);
		}

		if (monsterHealth <= 0){
			monsterBar.SetActive(false);
		}

		healthBarMonster.maxValue = monsterMaxHealth;
		healthBarMonster.value = monsterHealth;
		HPTextMonster.text = "" + monsterHealth + "/" + monsterMaxHealth;
	}
}
