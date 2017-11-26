using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	public void fadeout(){
		StartCoroutine(FadeTextToZeroAlpha(0.6f, GetComponent<Image>()));
	}

	public IEnumerator FadeTextToZeroAlpha(float t, Image i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

}