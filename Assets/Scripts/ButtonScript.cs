using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	[HideInInspector]public bool _active;

	SoundManager SM;

	void Start () {
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		_active = false;
	}
	
	void OnCollisionEnter2D(Collision2D other){//if the ball is in the ring the player can go through the door.
		if(other.gameObject.tag == ("Grabbable")){
			_active = true;
			SM.Door.Play();
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == ("Grabbable")) {
			_active = false;
		}
	}
}
