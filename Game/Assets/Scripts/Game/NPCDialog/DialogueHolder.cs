using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	//public string dialogue;
	private DialogManager dialogManager;
	private QuestManager questManager;

	public GameObject question;
	public GameObject mark;

	public Sprite avatar; 

	public int questNo;
	public bool hasQuest;

	public string[] dialogLine;
	public bool[] displayChar;
	public string[] names;

	public bool finishChat;
	public string[] dialogLine2;
	public bool[] displayChar2;
	public string[] names2;

	public bool hasStory;

	public bool mainStart;

	// Use this for initialization
	void Start () {
		dialogManager = FindObjectOfType<DialogManager> ();
		questManager = FindObjectOfType<QuestManager> ();
		if (hasQuest == true) {
			question.SetActive (true);
		}
		finishChat = false;

		if (hasQuest) {
			if (questManager.questCompleted [questNo] == true) {
				hasQuest = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hasStory) {
			if (hasQuest && questManager.questActive == false) {
				questManager.questActive = true;
				questManager.StartQuest (questNo);
			}
				dialogManager.dialogLines = dialogLine;
				dialogManager.names = names;
				dialogManager.displayChar = displayChar;
				dialogManager.currentLine = 0;
				dialogManager.avatar = avatar;
			dialogManager.showDialogue ();
			hasStory = false;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			Debug.Log ("Activating");
			if (Input.GetKeyUp (KeyCode.Space)) {
				//dialogManager.showBox (dialogue);

				if (!dialogManager.dialogActive) {
					if (finishChat) {
						dialogManager.dialogLines = dialogLine2;
						dialogManager.names = names2;
						dialogManager.displayChar = displayChar2;
						dialogManager.currentLine = 0;
						dialogManager.avatar = avatar;
					} else {
						dialogManager.dialogLines = dialogLine;
						dialogManager.names = names;
						dialogManager.displayChar = displayChar;
						dialogManager.currentLine = 0;
						dialogManager.avatar = avatar;
						finishChat = true;
					}
						if (hasQuest && questManager.questActive == false) {
							questManager.questActive = true;
							questManager.StartQuest (questNo);
						}
					}
					dialogManager.showDialogue ();
				}

			}
		}
	}

