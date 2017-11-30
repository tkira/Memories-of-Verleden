using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rigBody;

	public int playerKnockBackStrength;
	public float moveSpeed;
	public bool PlayerMoving;
	private Vector2 lastMove;

	public AudioSource run;

	void Start(){
		animator = GetComponent < Animator>();
		rigBody = GetComponent<Rigidbody2D> ();
		PlayerMoving = false;
	}

	//Movement Controls
	void MovePlayer() {
		PlayerMoving = false;
		//Move with WASD or Arrows
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			PlayerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			if (!run.isPlaying) {
				run.Play();
			}
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			PlayerMoving = true;
			lastMove = new Vector2 (0f , Input.GetAxisRaw ("Vertical"));
			if (!run.isPlaying) {
				run.Play();
			}
		}

		animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

		animator.SetBool ("PlayerMoving", PlayerMoving);
		animator.SetFloat ("LastMoveX", lastMove.x);
		animator.SetFloat ("LastMoveY", lastMove.y);
	}

	// Update is called once per frame
	void Update () {	
	//if (!(Input.GetKey (KeyCode.K))) {
			//DashControl ();
			MovePlayer ();
	//	}

		if (!PlayerMoving) {
			transform.Translate (Vector3.zero);
			run.Stop ();
		}

		if (!Input.anyKeyDown) {
			transform.Translate (Vector3.zero);
		}

		//if (Input.GetKeyDown(KeyCode.J) ){
		//	rigBody.AddForce(transform.right * playerKnockBackStrength);
		//}
			
		//rigBody.velocity = Vector3.zero;
		//rigBody.angularVelocity = Vector3.zero;
	}
		

}

	//const int LEFT_MOUSE_BUTTON = 0;
	//public Vector2 oldPos;
	//public Vector2 currentPos;
	//public float posX;
	//public float posY;
	//private Vector2 targetPosition;

	//Click to move (WIP)
	//if (Input.GetMouseButton (0)) {
	//	Debug.Log ("MouseClicked");
	//	targetPosition = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
	//	oldPos = transform.position;
	//}

	//if ((Vector2)transform.position != targetPosition) {
	//	transform.position = Vector2.MoveTowards (transform.position, targetPosition, moveSpeed * Time.deltaTime);
	//	isMoving = true;
	//}

	//if ((Vector2)transform.position == targetPosition) {
	//	isMoving = false;
	//	posX = 0;
	//	posY = 0;
	//	animator.SetInteger ("MoveX", (int)posX);
	//	animator.SetInteger ("MoveY", (int)posY);
	//	oldPos = transform.position;
	//}
	//if (isMoving) {
	//}


