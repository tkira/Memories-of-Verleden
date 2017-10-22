using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour {

	public PlayerStats playerStats;
	public int playerCurrentHealth;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerStats.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		}
	}

	public void HurtPlayer(int damageToGive){
		playerCurrentHealth -= damageToGive; 
	}


	public void SetMaxHealth(){
		playerCurrentHealth = playerStats.maxHealth;
	}
}
