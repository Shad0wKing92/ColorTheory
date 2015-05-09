using UnityEngine;
using System.Collections;

public class RiftBehavior : MonoBehaviour {

	RiftManagerScript RMS;

	// Use this for initialization
	void Start () {
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {//changes the color of the object based on the the rift manager
		if(RMS.currentRift == RiftManagerScript.rifts.normal)
			this.gameObject.renderer.material.color = Color.gray;
		if(RMS.currentRift == RiftManagerScript.rifts.red)
			this.gameObject.renderer.material.color = Color.red;
		if(RMS.currentRift == RiftManagerScript.rifts.orange)
			this.gameObject.renderer.material.color = Color.black;
		if(RMS.currentRift == RiftManagerScript.rifts.yellow)
			this.gameObject.renderer.material.color = Color.yellow;
		if(RMS.currentRift == RiftManagerScript.rifts.green)
			this.gameObject.renderer.material.color = Color.green;
		if(RMS.currentRift == RiftManagerScript.rifts.blue)
			this.gameObject.renderer.material.color = Color.blue;
		if(RMS.currentRift == RiftManagerScript.rifts.purple)
			this.gameObject.renderer.material.color = Color.magenta;
		//this is for the camera scripts
        //changes the layer of the player
		if(this.gameObject.tag == "Player"){
			if (RMS.currentRift == RiftManagerScript.rifts.red) {
				this.gameObject.layer = 11;
			}
			if (RMS.currentRift == RiftManagerScript.rifts.yellow) {
				//this.gameObject.layer = 12;
			}
			if (RMS.currentRift == RiftManagerScript.rifts.blue) {
				this.gameObject.layer = 13;
			}
		}
        //changes the layer of the background stuff
		if(this.gameObject.tag == "Cube"){
			if (RMS.currentRift == RiftManagerScript.rifts.red) {
				this.gameObject.layer = 14;
			}
			if (RMS.currentRift == RiftManagerScript.rifts.yellow) {
				this.gameObject.layer = 15;
			}
			if (RMS.currentRift == RiftManagerScript.rifts.blue) {
				this.gameObject.layer = 16;
			}
		}
	}
}
