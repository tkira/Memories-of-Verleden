using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float moveSpeed;
	public Weapon weap;
	private Rigidbody2D rigBod2d;
	public Transform Player;
	public int argroRange = 10;

	private bool moving;
	public bool attacked;

	public float timeBetweenMove;
	public float timeToMove;
	private float timeBetweenMoveCounter;
	private float timeToMoveCounter;
	public int knockBack;

	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		rigBod2d = GetComponent<Rigidbody2D>();
		attacked = false;
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) 
		{
			timeToMoveCounter -= Time.deltaTime;

			rigBod2d.velocity = moveDirection;

			if (timeToMoveCounter < 0f) 
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;

			rigBod2d.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0f) 
			{
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			}
		}


		if (Vector2.Distance (transform.position, Player.position) <= argroRange && attacked == false) {
			moving = false;
			transform.position = Vector2.MoveTowards (transform.position, Player.position, moveSpeed * Time.deltaTime);
		}
	}
}
