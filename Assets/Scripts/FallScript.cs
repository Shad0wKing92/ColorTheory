using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {

	public GameObject child;
	SoundManager SM;

	// Use this for initialization
	void Start () {
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			SM.SpikeFalling.Play();
			child.gameObject.AddComponent<Rigidbody2D>();
		}
	}
}
