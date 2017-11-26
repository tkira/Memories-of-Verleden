using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentMemoryManager : MonoBehaviour {

	public StoryObject[] stories;
	public PlayerStats playerStats;
	public bool[] storiesCollected;

	public GameObject page; 

	public int storyNo; 

	public PauseGame pause;
	public StoryManager storyManager;

	public StartStory startArc2;
	public StartStory startArc3;
	public StartStory startArc4;

	public GameObject memoryDia;
	public DialogueHolder memoryDiaHold;

	public GameObject arc2;
	public GameObject arc3;
	public GameObject arc4;

	// Update is called once per frame
	void Update () {
	}

	public void StartStory(int storyNo2){
			page.SetActive (true);
			pause.pauseGame (true);
			storyNo = storyNo2;
		}

	public void EndStory(){
		storiesCollected [storyNo] = true;
		stories [storyNo].gameObject.SetActive(false);
		page.SetActive (false);
		pause.pauseGame (false);
		playerStats.memoryCount = playerStats.memoryCount + 1;

		if (playerStats.memoryCount == 1) {
			memoryDia.SetActive (true);
			memoryDiaHold.hasStory = true;
		}
		else if (playerStats.memoryCount == 5) {
			arc2.SetActive (true);
			startArc2.startArc ();
		}
		else if (playerStats.memoryCount == 9) {
			arc3.SetActive (true);
			startArc3.startArc ();
		}
	}
}
