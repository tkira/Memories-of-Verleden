using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateSkill : MonoBehaviour {

	public PlayerStats playerStats;

	public Text powerStrikeCooldownText;
	public Slider powerStrikeCooldownSlider;
	private bool powerStrikeCooldown;
	public GameObject powerStrikeCDT;
	public Animator animator;
	public GameObject upAni;
	public GameObject downAni;
	public GameObject rightAni;
	public GameObject leftAni;

	public Text fireballCooldownText;
	public Slider fireballCooldownSlider;
	private bool fireballCooldown;
	public GameObject fireballCDT;
	public Rigidbody2D arrow;                // Prefab of the arrow.
	public float projSpeed = 20f;            // The speed of the projectile
	public Vector3 Rotation;                // Vector 3 to hold rotation
	public BowScript bowS;
	public Transform bullutPos;

	public GameObject healAnimation;
	public GameObject healCost;
	public Text healCooldownText;
	public Slider healCooldownSlider;
	private bool healCooldown;
	public GameObject healCDT;

	public GameObject focusActiveG;
	public Text focusActiveText;
	public bool focusActive;
	public GameObject focusCost;
	public Text focusCooldownText;
	public Slider focusCooldownSlider;
	private bool focusCooldown;
	public GameObject focusCDT;

	public GameObject auraAnimation;
	public GameObject auraCost;
	public Text auraShockCooldownText;
	public Slider auraShockCooldownSlider;
	private bool auraShockCooldown;
	public GameObject auraShockCDT;

	// Use this for initialization
	void Start () {
		focusActive = false;

		powerStrikeCooldown = false;
		fireballCooldown = false;
		healCooldown = false;
		focusCooldown = false;
		auraShockCooldown = false;
		powerStrikeCooldownSlider.value = 0;
		fireballCooldownSlider.value = 0;
		healCooldownSlider.value = 0;
		focusCooldownSlider.value = 0;
		auraShockCooldownSlider.value = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1) && powerStrikeCooldown == false) {
			powerStrikeCooldownSlider.maxValue = playerStats.skillPowerStrikeCD;
			powerStrikeCDT.SetActive (true);
			powerStrikeCooldown = true;

			animator.SetBool ("Attack", true);
			if (bowS.moveUp) {
				upAni.SetActive (true);
			} else if (bowS.moveDown) {
				downAni.SetActive (true);
			} else if (bowS.moveRight) {
				rightAni.SetActive (true);
			} else if (bowS.moveLeft) {
				leftAni.SetActive (true);
			}

			StartCoroutine (powerStrikeCD ());
		} else if (Input.GetKeyDown (KeyCode.Alpha2) && fireballCooldown == false) {
			fireballCooldownSlider.maxValue = playerStats.skillFireballCD;
			fireballCDT.SetActive (true);
			fireballCooldown = true;

			Rigidbody2D arrowInstance = Instantiate(arrow, bullutPos.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;

			if (bowS.moveUp) {
				arrowInstance.velocity = Vector3.up * projSpeed;
				arrowInstance.rotation = 90;
			} else if (bowS.moveDown) {
				arrowInstance.velocity = Vector3.down * projSpeed;
				arrowInstance.rotation = -90;
			} else if (bowS.moveRight) {
				arrowInstance.velocity = Vector3.right * projSpeed;
			} else if (bowS.moveLeft) {
				arrowInstance.velocity = Vector3.left * projSpeed;
				arrowInstance.rotation = 180;
			}

			StartCoroutine (fireballCD ());
		} else if (Input.GetKeyDown (KeyCode.Alpha3) && healCooldown == false && playerStats.powerBar >= 50) {
			healCooldownSlider.maxValue = playerStats.skillHealCD;
			healCDT.SetActive (true);
			healCooldown = true;
			healCost.SetActive (false);
			healAnimation.SetActive (true);

			playerStats.powerBar =  playerStats.powerBar - 50;
			float percentHeal = (playerStats.maxHealth / 100) * playerStats.skillHeal;
			playerStats.playerCurrentHealth = Mathf.RoundToInt(playerStats.playerCurrentHealth + percentHeal);

			StartCoroutine (healCD ());
		} else if (Input.GetKeyDown (KeyCode.Alpha4) && focusCooldown == false && playerStats.powerBar >= 30) {
			focusCooldown = true;
			focusCost.SetActive (false);

			playerStats.powerBar =  playerStats.powerBar - 30;
			focusActive = true;
			StartCoroutine (focusActiveRun ());

		} else if (Input.GetKeyDown (KeyCode.Q) && auraShockCooldown == false && playerStats.powerBar >= 100) {
			auraShockCooldownSlider.maxValue = playerStats.skillauraShockCD;
			auraShockCDT.SetActive (true);
			auraShockCooldown = true;
			auraCost.SetActive (false);

			playerStats.powerBar =  playerStats.powerBar - 100;
			auraAnimation.SetActive (true);

			StartCoroutine (auraCD ());
		}
	}

	IEnumerator powerStrikeCD(){
		powerStrikeCooldownSlider.value = playerStats.skillPowerStrikeCD;
		powerStrikeCooldownText.text = (powerStrikeCooldownSlider.value).ToString();
		yield return new WaitForSeconds (1);
		leftAni.SetActive (false);
		rightAni.SetActive (false);
		downAni.SetActive (false);
		upAni.SetActive (false);
		while (powerStrikeCooldownSlider.value > 0){
			yield return new WaitForSeconds (1);
			powerStrikeCooldownSlider.value = powerStrikeCooldownSlider.value - 1;
			powerStrikeCooldownText.text = (powerStrikeCooldownSlider.value).ToString();
		}
		powerStrikeCooldown = false;
		powerStrikeCDT.SetActive (false);
		yield return null;
	}

	IEnumerator fireballCD(){
		fireballCooldownSlider.value = playerStats.skillFireballCD;
		fireballCooldownText.text = (fireballCooldownSlider.value).ToString();
		while (fireballCooldownSlider.value > 0){
			yield return new WaitForSeconds (1);
			fireballCooldownSlider.value = fireballCooldownSlider.value - 1;
			fireballCooldownText.text = (fireballCooldownSlider.value).ToString();
		}
		fireballCooldown = false;
		fireballCDT.SetActive (false);
		yield return null;
	}

	IEnumerator healCD(){
		healCooldownSlider.value = playerStats.skillHealCD;
		healCooldownText.text = (healCooldownSlider.value).ToString();

		yield return new WaitForSeconds (1);
		healAnimation.SetActive (false);

		while (healCooldownSlider.value > 0){
			yield return new WaitForSeconds (1);
			healCooldownSlider.value = healCooldownSlider.value - 1;
			healCooldownText.text = (healCooldownSlider.value).ToString();
		}
		healCost.SetActive (true);
		healCooldown = false;
		healCDT.SetActive (false);
		yield return null;
	}

	IEnumerator focusCD(){
		focusCooldownSlider.value = playerStats.skillFocusCD;
		focusCooldownText.text = (focusCooldownSlider.value).ToString();
		while (focusCooldownSlider.value > 0){
			yield return new WaitForSeconds (1);
			focusCooldownSlider.value = focusCooldownSlider.value - 1;
			focusCooldownText.text = (focusCooldownSlider.value).ToString();
		}
		focusCost.SetActive (true);
		focusCooldown = false;
		focusCDT.SetActive (false);
		yield return null;
	}

	IEnumerator focusActiveRun (){
		int activeTime = playerStats.skillFocus;
		focusActiveG.SetActive (true);
		focusActiveText.text = (activeTime).ToString();
		while (activeTime > 0){
			yield return new WaitForSeconds (1);
			activeTime = activeTime - 1;
			focusActiveText.text = (activeTime).ToString();
		}
		focusActiveG.SetActive (false);
		focusActive = false;
		focusCooldownSlider.maxValue = playerStats.skillFocusCD;
		focusCDT.SetActive (true);

		StartCoroutine (focusCD ());
	}
		
	IEnumerator auraCD(){
		auraShockCooldownSlider.value = playerStats.skillauraShockCD;
		auraShockCooldownText.text = (auraShockCooldownSlider.value).ToString();
		yield return new WaitForSeconds (1.5f);
		auraAnimation.SetActive (false);
		while (auraShockCooldownSlider.value > 0){
			yield return new WaitForSeconds (1);
			auraShockCooldownSlider.value = auraShockCooldownSlider.value - 1;
			auraShockCooldownText.text = (auraShockCooldownSlider.value).ToString();
		}
		auraCost.SetActive (true);
		auraShockCooldown = false;
		auraShockCDT.SetActive (false);
		yield return null;
	}

}
