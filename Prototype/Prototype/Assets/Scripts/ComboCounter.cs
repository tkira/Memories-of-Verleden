using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour {

	public int comboCount;
	public int percentageBonus;
	public Text comboCountT;
	public Text comboPerT;

	// Use this for initialization
	void Start () {
		comboCount = 1;
		percentageBonus = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (comboCount == 10){
			percentageBonus = 5;
		} else if (comboCount == 20){
			percentageBonus = 10;
		} else if (comboCount == 30){
			percentageBonus = 15;
		} else if (comboCount == 40){
			percentageBonus = 20;
		} else if (comboCount == 50){
			percentageBonus = 25;
		} else if (comboCount == 60){
			percentageBonus = 30;
		} else if (comboCount == 70){
			percentageBonus = 35;
		}
		comboCountT.text = "" + comboCount + " COMBO!!";
		comboPerT.text = "" + percentageBonus + "% Bonus!!";
	}

	public void resetCounter(){
		comboCount = 1;
		percentageBonus = 1;
	}
}
