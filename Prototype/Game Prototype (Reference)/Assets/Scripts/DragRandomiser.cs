using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DragRandomiser : MonoBehaviour {

	public Text Dialog;
	public Text charHealth;
	public Text dragHealth;

	int dragType;
	public GameObject drag1;
	public GameObject drag2;
	public GameObject drag3;
	public GameObject drag4;
	public GameObject drag5;
	public GameObject drag6;
	public GameObject drag7;
	private GameObject _instance;

	public Transform dragLoca;


	// Use this for initialization
	void Start () {
		dragType = Random.Range (1, 7);
		Debug.Log (dragType);
		if (dragType == 1) {
			drag1.gameObject.SetActive (true);
			_instance = (GameObject) Instantiate (drag1, dragLoca.position, dragLoca.rotation);
			FightCode.GlobalVariables.dragHealth = 30;
			FightCode.GlobalVariables.dragMaxHealth = 30;
			dragHealth.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
			charHealth.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		} else if (dragType == 2) {
			drag2.gameObject.SetActive (true);
			_instance = (GameObject) Instantiate (drag2, dragLoca.position, dragLoca.rotation);
			FightCode.GlobalVariables.dragHealth = 35;
			FightCode.GlobalVariables.dragMaxHealth = 35;
			dragHealth.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
			charHealth.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		} else if (dragType == 3) {
			drag3.gameObject.SetActive (true);
			_instance = (GameObject) Instantiate (drag3, dragLoca.position, dragLoca.rotation);
			FightCode.GlobalVariables.dragHealth = 25;
			FightCode.GlobalVariables.dragMaxHealth = 25;
			dragHealth.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
			charHealth.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		} else if (dragType == 4) {
			drag4.gameObject.SetActive (true);
			_instance = (GameObject) Instantiate (drag4, dragLoca.position, dragLoca.rotation);
			FightCode.GlobalVariables.dragHealth = 30;
			FightCode.GlobalVariables.dragMaxHealth = 30;
			dragHealth.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
			charHealth.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		} else if (dragType == 5) {
			drag5.gameObject.SetActive (true);
			_instance = (GameObject) Instantiate (drag5, dragLoca.position, dragLoca.rotation);
			FightCode.GlobalVariables.dragHealth = 35;
			FightCode.GlobalVariables.dragMaxHealth = 35;
			dragHealth.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
			charHealth.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		} else if (dragType == 6) {
			drag6.gameObject.SetActive (true);
			_instance = (GameObject) Instantiate (drag6, dragLoca.position, dragLoca.rotation);
			FightCode.GlobalVariables.dragHealth = 45;
			FightCode.GlobalVariables.dragMaxHealth = 45;
			dragHealth.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
			charHealth.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		} else if (dragType == 7) {
			drag7.gameObject.SetActive (true);
			_instance = (GameObject) Instantiate (drag7, dragLoca.position, dragLoca.rotation);
			FightCode.GlobalVariables.dragHealth = 50;
			FightCode.GlobalVariables.dragMaxHealth = 50;
			dragHealth.text = FightCode.GlobalVariables.dragHealth + "/" + FightCode.GlobalVariables.dragMaxHealth;
			charHealth.text = FightCode.GlobalVariables.charHealth + "/" + FightCode.GlobalVariables.charMaxHealth;
		}
	}

	// Update is called once per frame
	void Update () {
		if (FightCode.GlobalVariables.win == true) {
			Debug.Log ("Delete");
			Destroy(_instance);
			dragHealth.text = "";
		}
	}
}
