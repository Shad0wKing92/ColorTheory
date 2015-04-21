using UnityEngine;
using System.Collections;

public class FallingSpike : MonoBehaviour {

	public GameObject Parent;
	SoundManager SM;


	// Use this for initialization
	void Start () {
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground" || other.gameObject.tag == "Grabbable") {
			SM.SpikeHitting.Play();
			Destroy(this.gameObject.rigidbody2D);
			this.transform.position = Parent.transform.position;
		}
	}
}
