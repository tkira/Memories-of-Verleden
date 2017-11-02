using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVolume : MonoBehaviour {

	public Slider volume;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void VolumeController(){
		AudioListener.volume = volume.value;
	}
}
