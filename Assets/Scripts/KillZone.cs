using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	RespawnScript RS;


	// Use this for initialization
	void Start () {
		RS = GameObject.FindGameObjectWithTag ("Respawner").GetComponent<RespawnScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Grabbable"){
			if(RS.GrabbableInFeild){
				Destroy (other.gameObject);
				RS.GrabbableInFeild = false;
			}
		}
		if(other.gameObject.tag == "Player"){
			other.transform.position = RS.transform.position;
			other.transform.rotation = RS.transform.rotation;
		}

	}
}
