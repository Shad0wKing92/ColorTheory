﻿using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {

	public GameObject child;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			print("fall");
			child.gameObject.AddComponent<Rigidbody2D>();
		}
	}
}
