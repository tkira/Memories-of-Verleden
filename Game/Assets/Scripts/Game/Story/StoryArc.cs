using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryArc : MonoBehaviour {

	public int arcNo;

	public string arcName;
	public string story;

	public StoryManager storyManager;
	public PlayerStats playerStats;

	public GameObject image2;
	public Image image;

	public GameObject acr1Dia;
	public DialogueHolder acr1DiaHold;
	public GameObject acr2Dia;
	public DialogueHolder acr2DiaHold;
	public GameObject acr3Dia;
	public DialogueHolder acr3DiaHold;

	public bool completed;

	public GameObject arcDisable;


	// Use this for initialization
	void Start () {
		completed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !completed){
			image2.SetActive (true);
			StartCoroutine(FadeOut(0.6f, image));
			StartCoroutine(timer());
			completed = true;
		}
	}

	public IEnumerator FadeOut(float t, Image i){
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadeIn(float t, Image i){
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}

	IEnumerator timer(){
		yield return new WaitForSeconds (1f);
		StartCoroutine(FadeIn(0.6f, image));
		StartCoroutine(timer2());
		arcDisable.SetActive (false);
	}

	IEnumerator timer2(){
		yield return new WaitForSeconds (1f);
		image2.SetActive (false);
		storyManager.arcCompleted [arcNo] = true;
		if (arcNo == 0) {
			acr1Dia.SetActive (true);
			acr1DiaHold.hasStory = true;
			gameObject.SetActive (false);
		}
		if (playerStats.memoryCount == 5 && arcNo == 1) {
			acr2Dia.SetActive (true);
			acr2DiaHold.hasStory = true;
			gameObject.SetActive (false);
		}
		if (playerStats.memoryCount == 9 && arcNo == 2) {
			acr3Dia.SetActive (true);
			acr3DiaHold.hasStory = true;
			gameObject.SetActive (false);
		}
	}
}
