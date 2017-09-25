using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Animator animator;
	public float DashVelocity;
	public Rigidbody2D rigBody;

	void Start(){
		animator = GetComponent < Animator>();
		rigBody = GetComponent < Rigidbody2D>();
	}

	public bool facingRightFlip = true; 
	public bool facingRight = true; //Depends on if your animation is by default facing right or left
	public bool facingUp = true;
	public bool facingDown = true;
	public bool facingLeft = true;

	void FixedUpdate()	//Flip Character
	{
		float h = Input.GetAxis ("Horizontal");
		if (h > 0 && !facingRightFlip) {
			FlipH ();
		} else if (h < 0 && facingRightFlip)
			FlipH ();
	}

	void FlipH ()
	{
		facingRightFlip = !facingRightFlip;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Movement Controls
	void MovementControl() {
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector2.left * 3f * Time.deltaTime);
			animator.SetInteger ("movement", 1);
			facingRight = false;
			facingUp = false;
			facingDown = false;
			facingLeft = true;
		} else if (Input.GetKey (KeyCode.D)) {	
			transform.Translate (Vector2.right * 3f * Time.deltaTime);
			animator.SetInteger ("movement", 1);
			facingRight = true;
			facingUp = false;
			facingDown = false;
			facingLeft = false;
		} else if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * 3f * Time.deltaTime);
			animator.SetInteger ("movement", 2);
			facingRight = false;
			facingUp = true;
			facingDown = false;
			facingLeft = false;
		} else if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector2.down * 3f * Time.deltaTime);
			facingRight = false;
			facingUp = false;
			facingDown = true;
			facingLeft = false;
			animator.SetInteger ("movement", 3);
		} else {
			animator.SetInteger ("movement", 0);
		}
	}


	void DashControl() {
	//Dash 
		if (Input.GetKeyDown(KeyCode.Space)) {
			animator.Play ("Dash");
			//animator.SetInteger ("movement", 4);
			if (facingRight == true) {
				rigBody.AddForce (transform.right * DashVelocity);
			} else if (facingLeft == true){
				rigBody.AddForce (-transform.right * DashVelocity);
			} else if (facingUp == true){
				rigBody.AddForce (transform.up * DashVelocity);
			} else if (facingDown == true){
				rigBody.AddForce (-transform.up * DashVelocity);
			}
		}
	}



	// Update is called once per frame
	void Update () {
		DashControl ();
		MovementControl ();
	}

}