using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	Animator anim;
	bool isFading = false;
	public GameObject Player;
	public CameraFollow camBools;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag("Player");
		if (Encounter.GlobalVariables.checkEncout == true) {
			Player.transform.position = new Vector3 (Encounter.GlobalVariables.saveAreaX, Encounter.GlobalVariables.saveAreaY, Encounter.GlobalVariables.saveAreaZ);
			GameObject wB = GameObject.FindGameObjectWithTag ("MainCamera");
			camBools = wB.GetComponent<CameraFollow> ();
			camBools.bounds = true;
			camBools.bounds2 = false;

			Encounter.GlobalVariables.checkEncout = false;
		}
	}

	public IEnumerator FadeToClear(){
		isFading = true;
		anim.SetTrigger("FadeIn");

		yield return null;
	}

	public IEnumerator FadeToBlack(){
		isFading = true;
		anim.SetTrigger("FadeOut");

		yield return null;
	}

	void AnimationComplete(){
		isFading = false;
	}

}
