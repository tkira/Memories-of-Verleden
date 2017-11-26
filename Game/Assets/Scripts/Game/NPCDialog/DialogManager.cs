using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public Text nameText;
	public PauseGame pause;

	public bool dialogActive;

	public string[] dialogLines;
	public string[] names;
	public bool[] displayChar;
	public int currentLine;

	public Image player;
	public Image NPC;
	public Sprite avatar;

	public GameObject image;
	//public GameObject arc1;
	//public GameObject arc2;
	//public GameObject arc3;
	//public GameObject arc4;

	// Use this for initialization
	void Start () {
		currentLine = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyUp (KeyCode.Space)) {
			//dBox.SetActive (false);
			//dialogActive = false;
			currentLine++;
		}
		if (currentLine >= dialogLines.Length) {
			dialogActive = false;
			dBox.SetActive (false);
			currentLine = 0;
			pause.pauseGame (false);
			image.SetActive (false);
			//arc1.SetActive (false);
			//arc2.SetActive (false);
			//arc3.SetActive (false);
			//.SetActive (false);
		}
		if (dialogActive == true) {
			dText.text = dialogLines [currentLine];
			nameText.text = names [currentLine];
		}

		if (displayChar [currentLine] == true) {
			player.color = new Color32 (255, 255, 255, 255);
			NPC.color = new Color32 (125, 125, 125, 255);
		} else {
			NPC.color = new Color32 (255, 255, 255, 255);
			player.color = new Color32 (125, 125, 125, 255);
		}
	}

	public void showBox(string dialogue){
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
		pause.pauseGame (true);
	}

	public void showDialogue(){
		dialogActive = true;
		dBox.SetActive (true);
		NPC.sprite = avatar;
		currentLine = 0;
		pause.pauseGame (true);
	}
}
