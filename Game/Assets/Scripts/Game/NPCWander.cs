using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWander : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRig;

	public bool isWalking;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int WalkDirection;

	// Use this for initialization
	void Start () {
		myRig = GetComponent<Rigidbody2D> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		chooseDir ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isWalking) {
			walkCounter -= Time.deltaTime;

			switch (WalkDirection) {
			case 0:
				myRig.velocity = new Vector2 (0, moveSpeed);
				break;
			case 1:
				myRig.velocity = new Vector2 (moveSpeed, 0);
				break;
			case 2:
				myRig.velocity = new Vector2 (0, -moveSpeed);
				break;
			case 3:
				myRig.velocity = new Vector2 (-moveSpeed, 0);
				break;
			}

			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}
		} else {
			myRig.velocity = Vector2.zero;
			waitCounter -= Time.deltaTime;
			if (waitCounter < 0) {
				chooseDir ();
			}
		}
	}

	public void chooseDir(){
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}
}
