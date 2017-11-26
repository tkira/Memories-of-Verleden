using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour {

	Transform gemSpot;


	//this is currently a rather large mess that needs to be cleaned
	//due to just getting things working as quick as possible.


	public void SpawnGem() {
		Sprite gemSprite;
		GameObject gem = new GameObject("Gem");
		gem.transform.position = new Vector3 (-5, 15, 0);
		//gem.transform.SetParent (SpawnItem.);
		gem.AddComponent<SpriteRenderer>();
		gem.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("gemtest", typeof(Sprite)) as Sprite;
		gem.GetComponent<SpriteRenderer> ().sortingLayerName = "Player";

		gem.AddComponent<Item>();
	}
}
