using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour {

	Image bottleImage;

	public Sprite FullBottle;
	public Sprite HalfBottle;
	public Sprite quarterBottle;
	public Sprite almostEmptyBottle;
	public Sprite emptyBottle;
	public int currentBottleAmount = 100;
	public int MaxBottleLevel = 100;
	public PlayerStats playerStats;

	// Use this for initialization
	void Start () {
		GameObject Bottle = GameObject.Find("Bottle1");
		bottleImage = Bottle.GetComponent<Image>();

	}

	// Update is called once per frame
	void Update () {
		if (currentBottleAmount == 100) {
			bottleImage.sprite = FullBottle;
			}
		if (currentBottleAmount <= 10) {
			bottleImage.sprite = almostEmptyBottle;
		}

		if (Input.GetKeyUp (KeyCode.H)) {
			GameObject player = GameObject.Find ("Player");
			if (currentBottleAmount >= 30) {
				player.GetComponent<PlayerHealthSystem> ().HealPlayer (10);
				currentBottleAmount = currentBottleAmount - 30;
				if (currentBottleAmount < 0)
					currentBottleAmount = 0;
			}
		}
	}
}
