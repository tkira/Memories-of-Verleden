using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingLvl : MonoBehaviour {
	public class FloatingNumbers : MonoBehaviour {

		public float moveSpeed;
		public string stringText;
		public Text display;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			display.text = "" + stringText; 
			transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.transform.position.z);
		}
	}
}