using UnityEngine;
using System.Collections;

public class ZoneChange : MonoBehaviour {

	RiftManagerScript RMS;
	SoundManager SM;
    MovementScript MS;
	public enum rifts{normal, red, orange, yellow, green, blue, purple};

	public rifts currentRift;

	// Use this for initialization
	void Start () {
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
        MS = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
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
			SM.RiftSwitch.Play();
            if (RMS.currentRift == RiftManagerScript.rifts.red)
            {
                if (MS.powerActive == true)
                {
                    MS.powerActive = false;
                    MS.rigidbody2D.gravityScale = 1;
                }
                RMS.currentRift = RiftManagerScript.rifts.yellow;
                
            }
            else if (RMS.currentRift == RiftManagerScript.rifts.yellow)
            {
                RMS.currentRift = RiftManagerScript.rifts.blue;
                
            }
            else if (RMS.currentRift == RiftManagerScript.rifts.blue)
            {
                if (MS.powerActive == true)
                {
                    MS.powerActive = false;
                    Time.timeScale = 1;
                }
                RMS.currentRift = RiftManagerScript.rifts.red;
                
            }
		}
	}
}
