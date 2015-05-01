using UnityEngine;
using System.Collections;

public class FallingSpike : MonoBehaviour {

	public GameObject Parent;
	SoundManager SM;


	// Use this for initialization
	void Start () {
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			SM.SpikeHitting.Play();
			Destroy(this.gameObject.rigidbody2D);
			this.transform.position = Parent.transform.position;
        }
        else if (other.gameObject.tag == "Ground")
        {
            SM.SpikeHitting.Play();
            Destroy(this.gameObject.rigidbody2D);
            this.transform.position = Parent.transform.position;
            StartCoroutine(SpikeTimer(2f));
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
