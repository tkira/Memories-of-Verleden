using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FightCode : MonoBehaviour {

	public Transform battleStart, fightMenu, concludes;
	public string lvl =  "Level1";
	public int ranAtk;
	public int chance;
	public bool turns = true;
	public bool heal;
	public bool stun;
	public bool critY;
	public bool winCondition;

	[SerializeField]
	private Text dialog = null;
	[SerializeField]
	private Text charHealths = null;
	[SerializeField]
	private Text dragHealths = null;

	public static class GlobalVariables{
		public static int charMaxHealth = 40;
		public static int charHealth = 40;
		public static int dragMaxHealth;
		public static int dragHealth;
		public static bool win = false;
	}

	public BattleButtons batBTNs;

	public int damage;

	// Use this for initialization
	void Start () {
	}

	public void engage(){
		FightCode.GlobalVariables.win = false;
		Debug.Log ("ENGAGE");
		dialog.text = "What will you do?";
		turns = false;
		stun = false;
		critY = false;
	}

	public void specialMove(){
		dialog.text = "You use Special Move!";
		FightCode.GlobalVariables.dragHealth -= 15;
		damage = 15;

		dragHealths.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
		Debug.Log (FightCode.GlobalVariables.dragHealth);
		turns = false;
		stun = false;
		critY = false;
		StartCoroutine (damStats ());
	}

	public void crit(){
		dialog.text = "You use Critical Strike!";
		chance = Random.Range (1, 10);
		if (chance <= 2) {
			damage = 30;
			FightCode.GlobalVariables.dragHealth -= 30;
			critY = true;
		} else {
			damage = 15;
			FightCode.GlobalVariables.dragHealth -= 15;
			critY = false;
		}
		dragHealths.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
		Debug.Log (FightCode.GlobalVariables.dragHealth);
		turns = false;
		stun = false;
		StartCoroutine (damStats ());
	}

	public void stunAtk(){
		dialog.text = "You use Stun Attack!";
		damage = 15;
		chance = Random.Range (1, 10);
		if (chance <= 4) {
			damage = 10;
			FightCode.GlobalVariables.dragHealth -= 10;
			turns = true;
			stun = true;
		} else {
			damage = 10;
			FightCode.GlobalVariables.dragHealth -= 10;
			turns = false;
			stun = false;
		}
		dragHealths.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
		Debug.Log (FightCode.GlobalVariables.dragHealth);
		critY = false;
		StartCoroutine (damStats ());
	}

	public void healM(){
		dialog.text = "You use Recover!";
		heal = true;
		FightCode.GlobalVariables.charHealth += 20;
		damage = 0;
		if (FightCode.GlobalVariables.charHealth >= 50) {
			FightCode.GlobalVariables.charHealth = 50;
		}

		dragHealths.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		Debug.Log (FightCode.GlobalVariables.dragHealth);
		turns = false;
		stun = false;
		critY = false;
		StartCoroutine(damStats());
	}
		
	private IEnumerator damStats()
	{
		yield return new WaitForSeconds (1);
		if (heal == true) {
			dialog.text = "You heal for 20hp!!!";
			heal = false;
			yield return new WaitForSeconds (1);
		} else if (stun == true) {
			dialog.text = "You  stun the dragon.";
			stun = false;
			yield return new WaitForSeconds (1);
		} else if (critY = true) {
				dialog.text = "Critical!!!";
				critY = false;
		}
		dialog.text = "Dealt " + damage + " damage";
		yield return new WaitForSeconds (1);
		stun = false;
		critY = false;
		checkGame ();
	}

	public IEnumerator winStats()
	{
		Debug.Log ("GameEnd");
		yield return new WaitForSeconds (1);
		if (winCondition == true) {
			dialog.text = "You Win!";
			yield return new WaitForSeconds (1);
			Encounter.GlobalVariables.checkEncout = true;
			Application.LoadLevel (lvl);
		} else if (winCondition == false) {
			dialog.text = "You Lose!";
			yield return new WaitForSeconds (1);
			dialog.text = "Return to town!";
			Encounter.GlobalVariables.checkEncout = false;
			yield return new WaitForSeconds (1);
			Application.LoadLevel (lvl);
	}
	}
		
	public void checkGame () {
		if (FightCode.GlobalVariables.dragHealth <= 0) {
			concludes.gameObject.SetActive (true);
			battleStart.gameObject.SetActive (false);
			fightMenu.gameObject.SetActive (false);
			FightCode.GlobalVariables.win = true;
			winCondition = true;
			StartCoroutine(winStats());
		}
		if (FightCode.GlobalVariables.charHealth <= 0) {
				concludes.gameObject.SetActive (true);
				battleStart.gameObject.SetActive (false);
				fightMenu.gameObject.SetActive (false);
				FightCode.GlobalVariables.win = false;
				winCondition = false;
				Debug.Log ("GameEnd2");
			StartCoroutine(winStats());
		} else if (turns == false){
			concludes.gameObject.SetActive (false);
			battleStart.gameObject.SetActive (false);
			fightMenu.gameObject.SetActive (false);
			dragAttackTurn ();
		} else if (turns == true && FightCode.GlobalVariables.dragHealth > 0){
			fightMenu.gameObject.SetActive (true);
			dialog.text = "What will you do?";
		}
}

	public void dragAttackTurn(){
		dialog.text = "Wild Dragon!";
		ranAtk = Random.Range (1, 4);

		if (ranAtk == 1) {
			dialog.text = "Wild Dragon used Special Move!";
			FightCode.GlobalVariables.charHealth -= 20;
			damage = 20;

			charHealths.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
			Debug.Log (FightCode.GlobalVariables.charHealth);
			turns = true;
			StartCoroutine (damStats ());
		} else if (ranAtk == 2) {
			dialog.text = "Wild Dragon used Critical Strike!";

			chance = Random.Range (1, 10);
			if (chance <= 3) {
				damage = 30;
				FightCode.GlobalVariables.charHealth -= 30;
				critY = true;
			} else {
				damage = 15;
				FightCode.GlobalVariables.charHealth -= 15;
				critY = false;
			}
			charHealths.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
			Debug.Log (FightCode.GlobalVariables.charHealth);
			turns = true;
			StartCoroutine (damStats ());
		} else if (ranAtk == 3) {
			dialog.text = "Wild Dragon used Wing Slash!";
			FightCode.GlobalVariables.charHealth -= 20;
			damage = 20;

			charHealths.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
			Debug.Log (FightCode.GlobalVariables.charHealth);
			turns = true;
			StartCoroutine (damStats ());
		} else if (ranAtk == 4) {
			dialog.text = "Wild Dragon used Quick Attack!";
			FightCode.GlobalVariables.charHealth -= 15;
			damage = 15;

			charHealths.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
			Debug.Log (FightCode.GlobalVariables.charHealth);
			turns = true;
			StartCoroutine (damStats ());
		}
	}
}
