﻿using UnityEngine;
using System.Collections;

public class FallingSpike : MonoBehaviour {

	public GameObject Parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground" || other.gameObject.tag == "Grabbable") {
			Destroy(this.gameObject.rigidbody2D);
			this.transform.position = Parent.transform.position;
		}
	}
}