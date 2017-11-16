using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateStory : MonoBehaviour {

	public FragmentMemoryManager manager;
	public int storyNo;



	void OnTriggerEnter2D (Collider2D other){
	if (other.gameObject.tag == "Player") {
			manager.StartStory (storyNo);
	}
}
}
