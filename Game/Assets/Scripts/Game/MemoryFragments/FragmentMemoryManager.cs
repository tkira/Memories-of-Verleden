using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentMemoryManager : MonoBehaviour {

	public StoryObject[] stories;

	public bool[] storiesCollected;

	public GameObject page; 

	public int storyNo; 

	// Update is called once per frame
	void Update () {
		
	}

	public void StartStory(int storyNo2){
				page.SetActive (true);
				storyNo = storyNo2;
	}

	public void EndStory(){
		storiesCollected [storyNo] = true;
		stories [storyNo].gameObject.SetActive(false);
		page.SetActive (false);
	}
}
