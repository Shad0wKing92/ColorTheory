using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	RespawnScript RS;
    RespawnScript PRS;
	GameManager GM;
	SoundManager SM;
    MovementScript MS;

	// Use this for initialization
	void Start () {
        RS = GameObject.FindGameObjectWithTag("GRespawner").GetComponent<RespawnScript>();
        PRS = GameObject.FindGameObjectWithTag("Respawner").GetComponent<RespawnScript>();
		GM = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
        MS = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
        //if(other.gameObject.tag == "Grabbable"){
        //    SM.GrabbableDeath.Play();
        //    RS.GrabbableInFeild = false;
        //    Destroy(other.gameObject);
        //}
		if(other.gameObject.tag == "Player"){
			SM.PlayerDeath.Play();
            PRS.MoveObject(other.gameObject);
			GM.RemoveFromLives();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			SM.PlayerDeath.Play();
            PRS.MoveObject(other.gameObject);
			GM.RemoveFromLives();
        //} else if (other.gameObject.tag == "Grabbable") {
        //    SM.GrabbableDeath.Play();
        //    RS.GrabbableInFeild = false; 
        //    Destroy(other.gameObject);
        }
	}
}
