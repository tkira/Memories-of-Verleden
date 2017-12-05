using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public MonsterStats monsterStat;
	public Slider healthBarMonster;
	public Text monsterNameText;
	public Text monsterHPText;
	public GameObject monsterBar;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		healthBarMonster.maxValue = monsterStat.monsterMaxHealth;
		healthBarMonster.value = monsterStat.monsterHealth;
		monsterNameText.text = "LVL:" + monsterStat.monsterLvl + " " + monsterStat.monsterName;
		monsterHPText.text = "" + monsterStat.monsterHealth + "/" + monsterStat.monsterMaxHealth;

		if (monsterStat.monsterHealth < monsterStat.monsterMaxHealth){
			monsterBar.SetActive(true);
		}

	}
}
