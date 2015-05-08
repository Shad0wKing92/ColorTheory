using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {

    public float time;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {//destroys the object after some time, I use this for the particle effects so they don't clog up memory.
        Destroy(this.gameObject, time);
	}
}
