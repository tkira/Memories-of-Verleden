using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadMemory : MonoBehaviour {

	public Text memoryButton;

	public Text title;
	public Text realm;
	public Text story;



	public int memoryNumber;

	public FragmentMemoryManager memoryManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (memoryManager.storiesCollected [memoryNumber] == true) {
			memoryButton.text = memoryManager.stories [memoryNumber].storyName;
		} else {
			memoryButton.text = "??????????????????????????";
		}
	}

	public void openStory(){
		if (memoryManager.storiesCollected [memoryNumber] == true) {
			title.text = memoryManager.stories [memoryNumber].storyName;
			realm.text = memoryManager.stories [memoryNumber].realm;
			story.text = memoryManager.stories [memoryNumber].story;
		}
	}
}
