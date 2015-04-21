using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	RespawnScript RS;
	GameManager GM;
	SoundManager SM;

	// Use this for initialization
	void Start () {
		RS = GameObject.FindGameObjectWithTag ("Respawner").GetComponent<RespawnScript> ();
		GM = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Grabbable"){
//			if(RS.GrabbableInFeild){
				//Destroy (other.gameObject);
			SM.GrabbableDeath.Play();
			other.rigidbody.velocity = new Vector2(0,0);
			other.transform.position = RS.grabbable.transform.position;
			other.transform.rotation = RS.grabbable.transform.rotation;
//			RS.GrabbableInFeild = false;
//			}
		}
		if(other.gameObject.tag == "Player"){
//			Destroy(other.gameObject.rigidbody2D);
			SM.PlayerDeath.Play();
			other.rigidbody.velocity = new Vector2(0,0);
			other.transform.position = RS.transform.position;
			other.transform.rotation = RS.transform.rotation;
			GM.RemoveFromLives();
//			other.gameObject.AddComponent<Rigidbody2D>();
//			other.transform.rotation = RS.transform.rotation;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			SM.PlayerDeath.Play();
			other.rigidbody2D.velocity = new Vector2 (0, 0);
			other.transform.position = RS.transform.position;
			other.transform.rotation = RS.transform.rotation;
			GM.RemoveFromLives();
		} else if (other.gameObject.tag == "Grabbable") {
			SM.GrabbableDeath.Play();
			other.rigidbody2D.velocity = new Vector2 (0, 0);
			other.transform.position = RS.grabbable.transform.position;
			other.transform.rotation = RS.grabbable.transform.rotation;
		}
	}
}
