using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPotions : MonoBehaviour {

	public PlayerStats playerS;

	public Text text;
	public Image image;
	public AudioSource drink;

	public Sprite heal1;
	public Sprite heal2;
	public Sprite heal3;
	public Sprite heal4;
	public Sprite heal5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = (playerS.healPotionNo).ToString();

		if (playerS.healPotion == 0) {
			image.sprite = heal1;
		} else if (playerS.healPotion == 25) {
			image.sprite = heal2;
		} else if (playerS.healPotion == 50) {
			image.sprite = heal3;
		} else if (playerS.healPotion == 75) {
			image.sprite = heal4;
		} else if (playerS.healPotion == 100) {
			image.sprite = heal5;
		}

		if (playerS.healPotion > playerS.healPotionMax) {
			playerS.healPotionNo++;
			playerS.healPotion = playerS.healPotion - 100;
		}

		if ((Input.GetKeyDown (KeyCode.E)) && (playerS.playerCurrentHealth < playerS.maxHealth)) {
			if (playerS.healPotionNo > 0) {
				drink.Play();
				playerS.healPotionNo--;
				float percentHeal = (playerS.maxHealth / 100) * playerS.skillHeal;
				playerS.playerCurrentHealth = Mathf.RoundToInt (playerS.playerCurrentHealth + percentHeal);
			}
		}
	}
}
