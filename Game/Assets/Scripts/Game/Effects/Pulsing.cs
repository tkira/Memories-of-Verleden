using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pulsing : MonoBehaviour
{


	void Start(){
		StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
	}

	public IEnumerator FadeTextToFullAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
		StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
	}

	public IEnumerator FadeTextToZeroAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
		StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
	}
}
