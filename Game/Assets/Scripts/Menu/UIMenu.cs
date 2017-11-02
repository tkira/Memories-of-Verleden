using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour {

	public GameObject settings;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enableSettings(){
		if (settings.activeInHierarchy == true) {
			settings.SetActive (false);
		} else {
			settings.SetActive (true);
		}
	}

	public void setResolution(){

	}

	public void startGame(){
		SceneManager.LoadScene ("Main");

	}

	public void loadGame(){

	}

}

