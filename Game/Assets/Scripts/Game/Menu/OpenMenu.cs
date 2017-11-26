using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour {

	public GameObject menu;
	public GameObject journal;
	public GameObject character;
	public PauseGame pause;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (menu.activeInHierarchy == true) {
				menu.SetActive (false);
				pause.pauseGame (false);
			} else {
				menu.SetActive (true);
				pause.pauseGame (true);
			}
			if (journal.activeInHierarchy == true) {
					journal.SetActive (false);
			}
			if (character.activeInHierarchy == true) {
				character.SetActive (false);
			}
		}
	}

	public void goToMainMenu(){
		SceneManager.LoadScene ("Menu");
	}

	public void closeGame(){
		Application.Quit();
	}
}
