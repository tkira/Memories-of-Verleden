using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;

	public GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		float posX = Mathf.SmoothDamp (transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX); 
		float posY = Mathf.SmoothDamp (transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY); 

		transform.position = new Vector3 (posX, posY, transform.position.z);
}

}
