using UnityEngine;
using System.Collections;

public class GroundBehavior : MonoBehaviour {

	[HideInInspector]public bool grounded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			grounded = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			grounded = false;
		}
	}
}
