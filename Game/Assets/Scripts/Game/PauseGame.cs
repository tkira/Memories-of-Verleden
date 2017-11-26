using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public void pauseGame(bool pause){
		if (pause) {
			Time.timeScale = 0;
		} else if (!pause) {
			Time.timeScale = 1;
		}
	}
}
