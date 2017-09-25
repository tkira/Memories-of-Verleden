using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Animator animator;

	void Start(){
		animator = GetComponent < Animator>();
	}

	// Use this for initialization
	void MovementControl() {
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector2.left * 3f * Time.deltaTime);
			animator.SetInteger ("movement", 1);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * 3f * Time.deltaTime);
			animator.SetInteger ("movement", 2);
		} else if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * 3f * Time.deltaTime);
			animator.SetInteger ("movement", 3);
		} else if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector2.down * 3f * Time.deltaTime);
			animator.SetInteger ("movement", 4);
		} else {
			animator.SetInteger ("movement", 0);
		}
	}	
	// Update is called once per frame
	void Update () {
		MovementControl ();
	}
}
