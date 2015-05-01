using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {

    public float time;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, time);
	}
}
