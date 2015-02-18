using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {

	ButtonScript BS;

	// Use this for initialization
	void Start () {
		BS = GameObject.FindGameObjectWithTag ("Button").GetComponent<ButtonScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (BS._active) {
			this.renderer.enabled = false;
			this.collider2D.enabled = false;
		}else{
			this.renderer.enabled = true;
			this.collider2D.enabled = true;
		}
	}
}
