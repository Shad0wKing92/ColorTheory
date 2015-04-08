using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	[HideInInspector]public bool _active;

	SoundManager SM;

	// Use this for initialization
	void Start () {
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		_active = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == ("Grabbable")){
			_active = true;
			SM.testChildObject.audio.Play();
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == ("Grabbable")) {
			_active = false;
		}
	}
}
