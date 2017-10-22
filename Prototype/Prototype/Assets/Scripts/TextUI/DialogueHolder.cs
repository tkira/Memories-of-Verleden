using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	//public string dialogue;
	private DialogManager dialogManager;
	private QuestManager questManager;

	public int questNo;
	public bool hasQuest;

	public string[] dialogLine;

	// Use this for initialization
	void Start () {
		dialogManager = FindObjectOfType<DialogManager> ();
		questManager = FindObjectOfType<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.Space)) {
				//dialogManager.showBox (dialogue);

				if (!dialogManager.dialogActive) {
					dialogManager.dialogLines = dialogLine;
					dialogManager.currentLine = 0;

					if(hasQuest && questManager.questActive == false){
						questManager.questActive = true;
						questManager.StartQuest (questNo);
					}

					dialogManager.showDialogue ();
				}
			}
		}
	}
}
