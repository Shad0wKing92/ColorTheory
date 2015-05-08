using UnityEngine;
using System.Collections;

public class FallingSpike : MonoBehaviour {

	public GameObject Parent;
	SoundManager SM;
    public bool CanFall;


	// Use this for initialization
	void Start () {
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
        //CanFall = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){//when the spike is destroyed either on player contact or ground contact the spike is reset.
        //I did trigger and not collider enter because in collider enter it slightly rotates the spike before destroying spike.
		if (other.gameObject.tag == "Player") {
			SM.SpikeHitting.Play();
			Destroy(this.gameObject.rigidbody2D);
			this.transform.position = Parent.transform.position;
            if (CanFall)
            {
                StartCoroutine(SpikeTimer(2f));
            }
        }
        else if (other.gameObject.tag == "Ground")
        {
            SM.SpikeHitting.Play();
            Destroy(this.gameObject.rigidbody2D);
            this.transform.position = Parent.transform.position;
            if (CanFall)
            {
                StartCoroutine(SpikeTimer(2f));
            }
        }
	}

    IEnumerator SpikeTimer(float time){
        this.gameObject.renderer.enabled = false;
        this.gameObject.collider2D.enabled = false;
        this.Parent.collider2D.enabled = false;
        yield return new WaitForSeconds(time);
        this.gameObject.renderer.enabled = true;
        this.gameObject.collider2D.enabled = true;
        this.Parent.collider2D.enabled = true;
    }
}
