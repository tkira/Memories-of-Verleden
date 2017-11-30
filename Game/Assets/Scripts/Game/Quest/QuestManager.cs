using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;

	public bool[] questCompleted;

	public bool questActive;

	public string enemyKilled;

	public GameObject questname;
	public GameObject questdescription;

	// Use this for initialization
	void Start () {
		questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartQuest(int questNo){
		questname.SetActive (true);
		questdescription.SetActive (true);

		if (questActive && !questCompleted [questNo]) {
			if (!quests [questNo].gameObject.activeSelf) {
				quests [questNo].gameObject.SetActive(true);
			}
		}
	}

	public void EndQuest(int questNumber){
		questCompleted [questNumber] = true;
		gameObject.SetActive (false);

	}
}
