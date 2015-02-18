using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	[HideInInspector]public bool _active;

	// Use this for initialization
	void Start () {
		_active = false;
	}
	
	// Update is called once per frame
	void Update () {
		print (_active);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == ("Grabbable")){
			_active = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == ("Grabbable")) {
			_active = false;
		}
	}
}
