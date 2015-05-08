using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	RespawnScript RS;
    RespawnScript PRS;
	GameManager GM;
	SoundManager SM;
    MovementScript MS;

	void Start () {
        RS = GameObject.FindGameObjectWithTag("GRespawner").GetComponent<RespawnScript>();
        PRS = GameObject.FindGameObjectWithTag("Respawner").GetComponent<RespawnScript>();
		GM = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
        MS = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
	}
	
	void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Grabbable")//if the grabbable hits the killzone it will be destroyed.
        {
            SM.GrabbableDeath.Play();
            Instantiate(RS.DeathParticle, other.transform.position, other.transform.rotation);
            RS.GrabbableInFeild = false;
            Destroy(other.gameObject);
        }
		if(other.gameObject.tag == "Player"){//if player hits killzone they will be destroyed.
			SM.PlayerDeath.Play();
            if (MS.grabbed)
            {
                MS.Release();
            }
            StartCoroutine(WaitTime(2f, other.gameObject));
			GM.RemoveFromLives();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {//if the player is holding the grabbable and is destroyed they will drop it
			SM.PlayerDeath.Play();
            if (MS.grabbed)
            {
                MS.Release();
            }
            StartCoroutine(WaitTime(2f, other.gameObject));
			GM.RemoveFromLives();
        //} else if (other.gameObject.tag == "Grabbable") {
        //    SM.GrabbableDeath.Play();
        //    RS.GrabbableInFeild = false; 
        //    Destroy(other.gameObject);
        }
	}

    IEnumerator WaitTime(float time, GameObject other)
    {//coroutine for death makes sure you can't:
        other.renderer.enabled = false; //see the player,
        other.collider2D.enabled = false; //interact with the player,
        other.rigidbody2D.gravityScale = 0; //that the player doesnt fall off the map.
        Instantiate(RS.DeathParticle, other.transform.position, other.transform.rotation); //particle effect
        MS.dead = true; //move the player,
        yield return new WaitForSeconds(time);
        PRS.MoveObject(other.gameObject);
        other.renderer.enabled = true;
        other.collider2D.enabled = true;
        other.rigidbody2D.gravityScale = 1;
        MS.dead = false;
    }
}
