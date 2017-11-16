using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour {

	public GameObject menu;
	public GameObject journal;
	public GameObject character;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (menu.activeInHierarchy == true) {
				menu.SetActive (false);
			} else {
				menu.SetActive (true);
			}
			if (journal.activeInHierarchy == true) {
					journal.SetActive (false);
			}
			if (character.activeInHierarchy == true) {
				character.SetActive (false);
			}
		}

		if (menu.activeInHierarchy == true) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void goToMainMenu(){
		SceneManager.LoadScene ("Menu");
	}

	public void closeGame(){
		Application.Quit();
	}
}
