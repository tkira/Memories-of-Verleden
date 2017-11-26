using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStory : MonoBehaviour {

	public Image image;
	public GameObject image2;

	public GameObject acrLoad;
	public int arc1;


	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" && arc1 == 0) {
			startArc ();
		}
	}

	public void startArc(){
		image2.SetActive (true);
		StartCoroutine(FadeOut(2f, image));
		StartCoroutine(timer());
	}

	public IEnumerator FadeOut(float t, Image i){
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

	IEnumerator timer(){
		yield return new WaitForSeconds (1);
		StartCoroutine(FadeIn(0.6f, image));
		acrLoad.SetActive (true);
		StartCoroutine(timer2());
	}

	IEnumerator timer2(){
		yield return new WaitForSeconds (0.6f);
		image2.SetActive (false);
		gameObject.SetActive (false);
	}

	public IEnumerator FadeIn(float t, Image i){
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}
}
