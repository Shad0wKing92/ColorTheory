using UnityEngine;
using System.Collections;

public class ZoneChange : MonoBehaviour {

	RiftManagerScript RMS;

	public enum rifts{normal, red, orange, yellow, green, blue, purple};

	public rifts currentRift;

	// Use this for initialization
	void Start () {
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		//fix, it works but not in the right way

//		if(currentRift == rifts.knew){
//			if(RMS.currentRift == RiftManagerScript.rifts.knew){
//				this.gameObject.renderer.enabled = false;
//				this.gameObject.collider.enabled = false;
//			}
//			else{
//				this.gameObject.renderer.enabled = true;
//				this.gameObject.collider.enabled = true;
//			}
//		}
//
//		if(currentRift == rifts.old){
//			if(RMS.currentRift == RiftManagerScript.rifts.old){
//				this.gameObject.renderer.enabled = false;
//				this.gameObject.collider.enabled = false;
//			}else{
//				this.gameObject.renderer.enabled = true;
//				this.gameObject.collider.enabled = true;
//			}
//		}	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			if (RMS.currentRift == RiftManagerScript.rifts.red)
				RMS.currentRift = RiftManagerScript.rifts.orange;
			else if (RMS.currentRift == RiftManagerScript.rifts.orange)
				RMS.currentRift = RiftManagerScript.rifts.yellow;
			else if (RMS.currentRift == RiftManagerScript.rifts.yellow)
				RMS.currentRift = RiftManagerScript.rifts.green;
			else if (RMS.currentRift == RiftManagerScript.rifts.green)
				RMS.currentRift = RiftManagerScript.rifts.blue;
			else if (RMS.currentRift == RiftManagerScript.rifts.blue)
				RMS.currentRift = RiftManagerScript.rifts.purple;
			else if (RMS.currentRift == RiftManagerScript.rifts.purple)
				RMS.currentRift = RiftManagerScript.rifts.red;
//			} else if (RMS.currentRift == RiftManagerScript.rifts.old && currentRift == rifts.knew) {
//				RMS.currentRift = RiftManagerScript.rifts.knew;
//			}
		}
	}
}
