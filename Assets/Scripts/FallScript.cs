using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {

	public GameObject child;
	SoundManager SM;

	// Use this for initialization
	void Start () {
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){//if player enters trigger zone, spike will fall
		if (other.gameObject.tag == "Player") {
			SM.SpikeFalling.Play();
			child.gameObject.AddComponent<Rigidbody2D>();
		}
	}
}
