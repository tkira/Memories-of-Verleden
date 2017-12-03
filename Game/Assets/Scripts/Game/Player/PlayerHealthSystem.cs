using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour {

	public PlayerStats playerStats;
	public SaveManager playerSave;

	// Use this for initialization
	void Start () {
		playerStats.playerCurrentHealth = playerStats.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerStats.playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
			playerSave.LoadData ();
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		}
	}

	public void HurtPlayer(int damageToGive){
		playerStats.playerCurrentHealth -= damageToGive; 
	}


	public void SetMaxHealth(){
		playerStats.playerCurrentHealth = playerStats.maxHealth;
	}
}
