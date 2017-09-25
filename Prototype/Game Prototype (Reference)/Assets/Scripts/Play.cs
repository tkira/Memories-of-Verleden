using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
	public string Lvl;
	public void PlayMe(){
		Application.LoadLevel (Lvl);
	}
}