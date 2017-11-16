using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryObject : MonoBehaviour {

	public int storyNumber;

	public FragmentMemoryManager memoryManager;

	public string storyName;
	public string story;
	public string realm;

	public Text realmText;
	public Text titleText;
	public Text storyText;
	
	// Update is called once per frame
	void Update () {
		if (memoryManager.storiesCollected [storyNumber]) {
			gameObject.SetActive (false);
		}



	}
		
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Yea");
			memoryManager.StartStory (storyNumber);
			realmText.text = realm;
			titleText.text = storyName;
			storyText.text = story;
		}
	}
}
	

