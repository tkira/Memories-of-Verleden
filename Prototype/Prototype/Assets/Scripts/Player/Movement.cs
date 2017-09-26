using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Animator animator;
	public float DashVelocity;
	private Rigidbody2D rigBody;
	public float moveSpeed;

	void Start(){
		animator = GetComponent < Animator>();
		rigBody = GetComponent < Rigidbody2D>();
	}

	public bool facingRightFlip = true; //Depends on if your animation is by default facing right or left
	public bool facingRight = true; //Dash Direction
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
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
		}
	
		animator.SetFloat("MoveX", Input.GetAxisRaw ("Horizontal"));
		animator.SetFloat("MoveY", Input.GetAxisRaw ("Vertical"));
	}

	void DashControl() {
	//Dash 
		if (Input.GetKeyDown(KeyCode.Space)) {
			animator.Play ("Dash");
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5) {
				rigBody.AddForce (new Vector3 (Input.GetAxisRaw ("Horizontal") * DashVelocity, 0f, 0f));
			}

			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5) {
				rigBody.AddForce (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * DashVelocity, 0f));
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (!(Input.GetKey (KeyCode.K))) {
			DashControl ();
			MovementControl ();
		}
	}

}