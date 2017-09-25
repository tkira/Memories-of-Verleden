using UnityEngine;
using System.Collections;

public class BattleButtons : MonoBehaviour {
	public Transform battleStart, fightMenu;
	public string lvl =  "Level1";

	void Start(){
	}

	public void FightBtn(bool clicked){
		if (clicked == true) {
			fightMenu.gameObject.SetActive (clicked);
			battleStart.gameObject.SetActive (false);
		} else {
			fightMenu.gameObject.SetActive (clicked);
			battleStart.gameObject.SetActive (true);
		}
	}

	public void back(bool click){
		if (click == true) {
			battleStart.gameObject.SetActive (click);
			fightMenu.gameObject.SetActive (false);
		} else {
			battleStart.gameObject.SetActive (click);
			fightMenu.gameObject.SetActive (true);
		}
	}

	public void RUNN(){
		Encounter.GlobalVariables.checkEncout = true;
		Application.LoadLevel (lvl);
	}
}
