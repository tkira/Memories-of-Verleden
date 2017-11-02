using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour {

	public GameObject enemy;
	public Transform spwanPoint;
	public float timetoSpwan;
	private float timetoSpwanTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timetoSpwanTimer -= Time.deltaTime;

		if (timetoSpwanTimer <= 0) {
			Instantiate (enemy, spwanPoint.position, spwanPoint.rotation);

			timetoSpwanTimer = timetoSpwan;
		}
	}
}


