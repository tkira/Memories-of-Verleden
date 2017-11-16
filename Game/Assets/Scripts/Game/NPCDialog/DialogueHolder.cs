using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	//public string dialogue;
	private DialogManager dialogManager;
	private QuestManager questManager;

	public GameObject question;

	public Sprite avatar; 

	public int questNo;
	public bool hasQuest;

	public string[] dialogLine;
	public bool[] displayChar;
	public string[] names;

	// Use this for initialization
	void Start () {
		dialogManager = FindObjectOfType<DialogManager> ();
		questManager = FindObjectOfType<QuestManager> ();
		if (hasQuest == true) {
			question.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.name == "Player") {
			Debug.Log ("Activating");
			if (Input.GetKeyUp (KeyCode.Space)) {
				//dialogManager.showBox (dialogue);

				if (!dialogManager.dialogActive) {
					dialogManager.dialogLines = dialogLine;
					dialogManager.names = names;
					dialogManager.displayChar = displayChar;
					dialogManager.currentLine = 0;
					dialogManager.avatar = avatar;

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
