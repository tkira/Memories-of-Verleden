using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenJournal : MonoBehaviour {

	public GameObject journal;

	public GameObject character;

	public GameObject page;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.O)) {
			if (journal.activeInHierarchy == true) {
				journal.SetActive (false);
			} else {
				journal.SetActive (true);
				page.SetActive (false);
			}
			if (character.activeInHierarchy == true) {
				character.SetActive (false);
			}
		}

		if (journal.activeInHierarchy == true) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}
