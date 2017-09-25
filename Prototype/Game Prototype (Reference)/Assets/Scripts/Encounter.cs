using UnityEngine;
using System.Collections;

public class Encounter : MonoBehaviour {

	public GameObject Player;

	private bool playerInZone;

	public string Lvl = "Fight";
	int counterChance;

	public static class GlobalVariables{
		public static float saveAreaX;
		public static float saveAreaY;
		public static float saveAreaZ = -0.2f;
		public static bool checkEncout = false;
	}

	void Start(){
		playerInZone = false;
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){
		counterChance = Random.Range (0, 100);

		Debug.Log (counterChance);

		if (counterChance < 10) {
			ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

			GlobalVariables.saveAreaX = Player.transform.position.x;
			GlobalVariables.saveAreaY = Player.transform.position.y;
			Debug.Log (GlobalVariables.saveAreaX);
			Debug.Log (GlobalVariables.saveAreaY);
			GlobalVariables.checkEncout = true;

			yield return StartCoroutine (sf.FadeToBlack ());

			playerInZone = true;
			Debug.Log ("HIT ME");

			Application.LoadLevel (Lvl);
			yield return StartCoroutine (sf.FadeToClear ());
		}
	}

	void OnTriggerExit2D(Collider2D other){
		playerInZone = false;
	}

}
