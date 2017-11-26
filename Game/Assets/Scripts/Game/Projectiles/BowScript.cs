using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour {

	public Rigidbody2D arrow;                // Prefab of the arrow.
	public float projSpeed = 20f;            // The speed of the projectile
	public Vector3 Rotation;                // Vector 3 to hold rotation
	private Movement playerMove;        // Reference to the PlayerControl script.
	//private PlayerRotation playerRot;        // Reference to the Player Rotation Script

	public bool moveUp;
	public bool moveDown;
	public bool moveRight;
	public bool moveLeft;

	public bool delay;

	public Transform bullutPos;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.W)) {
			moveUp = true;
			moveDown = false;
			moveRight = false;
			moveLeft = false;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			moveUp = false;
			moveDown = true;
			moveRight = false;
			moveLeft = false;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			moveUp = false;
			moveDown = false;
			moveRight = false;
			moveLeft = true;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			moveUp = false;
			moveDown = false;
			moveRight = true;
			moveLeft = false;
		}

		if(Input.GetKeyDown(KeyCode.L) && !delay)
		{
			delay = true;
			StartCoroutine(resetdelay ());
			// Instantiate an arrow!
			Rigidbody2D arrowInstance = Instantiate(arrow, bullutPos.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;

			if (moveUp) {
				arrowInstance.velocity = Vector3.up * projSpeed;
				arrowInstance.rotation = 90;
			} else if (moveDown) {
				arrowInstance.velocity = Vector3.down * projSpeed;
				arrowInstance.rotation = -90;
			} else if (moveRight) {
				arrowInstance.velocity = Vector3.right * projSpeed;
			} else if (moveLeft) {
				arrowInstance.velocity = Vector3.left * projSpeed;
				arrowInstance.rotation = 180;
			}
		}
	}

		IEnumerator resetdelay(){
			yield return new WaitForSeconds (0.5f);
			delay = false;
		}
}
		