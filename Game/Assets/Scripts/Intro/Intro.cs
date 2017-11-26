using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Intro: MonoBehaviour {

	public Image image;
	public GameObject image2;



	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			image2.SetActive (true);
			StartCoroutine(FadeOut(0.6f, image));
			StartCoroutine(timer());
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

	IEnumerator timer(){
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Main");
	}
}
