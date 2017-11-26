using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public GameObject image;

	void Awake(){
		StartCoroutine(FadeTextToZeroAlpha(0.3f, GetComponent<Image>()));
		StartCoroutine (timer());
	}

	public IEnumerator FadeTextToZeroAlpha(float t, Image i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}

	IEnumerator timer(){
		yield return new WaitForSeconds (2);
		image.SetActive (false);
	}

}
