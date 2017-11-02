using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogActive;

	public string[] dialogLines;
	public int currentLine;

	// Use this for initialization
	void Start () {
		currentLine = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyDown (KeyCode.Space)) {
			//dBox.SetActive (false);
			//dialogActive = false;
			currentLine++;
		}
		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;
			currentLine = 0;
		}
		dText.text = dialogLines [currentLine];
	}

	public void showBox(string dialogue){
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}

	public void showDialogue(){
		dialogActive = true;
		dBox.SetActive (true);
	}
}
