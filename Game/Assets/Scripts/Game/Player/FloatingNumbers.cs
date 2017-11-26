﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour {

	public float moveSpeed;
	public string damageNum;
	public Text displayNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		displayNumber.text = "" + damageNum + "!"; 
		transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.transform.position.z);
	}
}
