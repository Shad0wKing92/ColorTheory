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
	
	void OnTriggerEnter2D(Collider2D other){//changes the world rift
		if (other.gameObject.tag == "Player") {
			SM.RiftSwitch.Play();
            if (RMS.currentRift == RiftManagerScript.rifts.red)
            {
                if (MS.powerActive == true)//checks to make sure the power is not active
                {
                    MS.powerActive = false;//if it is it deactivates
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
