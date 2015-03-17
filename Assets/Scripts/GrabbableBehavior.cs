using UnityEngine;
using System.Collections;

public class GrabbableBehavior : MonoBehaviour {

	MovementScript MS;
	RiftManagerScript RMS;

	// Use this for initialization
	void Start () {
		MS = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovementScript> ();
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (RMS.currentRift == RiftManagerScript.rifts.red && MS.powerActive) {
			this.rigidbody2D.gravityScale = -1;
		}else{
			this.rigidbody2D.gravityScale = 1;
		}
	}
}
