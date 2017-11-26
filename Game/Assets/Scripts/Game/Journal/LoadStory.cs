using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadStory : MonoBehaviour {

	public Text storyButton;

	public Text title;
	public Text story;

	public int storyNumber;

	public StoryManager storyManager;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (storyManager.arcCompleted [storyNumber] == true) {
			storyButton.text = storyManager.arcs [storyNumber].arcName;
		} else {
			storyButton.text = "??????????????????????????";
		}
	}

	public void openStory(){
		if (storyManager.arcCompleted [storyNumber] == true) {
			title.text = storyManager.arcs [storyNumber].arcName;
			story.text = storyManager.arcs [storyNumber].story;
		}
	}
}
