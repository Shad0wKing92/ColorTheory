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
        if (other.gameObject.tag == "Grabbable")
        {
            SM.GrabbableDeath.Play();
            Instantiate(RS.DeathParticle, other.transform.position, other.transform.rotation);
            RS.GrabbableInFeild = false;
            Destroy(other.gameObject);
        }
		if(other.gameObject.tag == "Player"){
			SM.PlayerDeath.Play();
            StartCoroutine(WaitTime(2f, other.gameObject));
			GM.RemoveFromLives();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			SM.PlayerDeath.Play();
            StartCoroutine(WaitTime(2f, other.gameObject));
			GM.RemoveFromLives();
        //} else if (other.gameObject.tag == "Grabbable") {
        //    SM.GrabbableDeath.Play();
        //    RS.GrabbableInFeild = false; 
        //    Destroy(other.gameObject);
        }
	}

    IEnumerator WaitTime(float time, GameObject other)
    {
        other.renderer.enabled = false;
        other.collider2D.enabled = false;
        other.rigidbody2D.gravityScale = 0;
        Instantiate(RS.DeathParticle, other.transform.position, other.transform.rotation);
        yield return new WaitForSeconds(time);
        PRS.MoveObject(other.gameObject);
        other.renderer.enabled = true;
        other.collider2D.enabled = true;
        other.rigidbody2D.gravityScale = 1;
    }
}
