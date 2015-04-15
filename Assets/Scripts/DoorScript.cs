using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	ButtonScript BS;
	GameManager GM;

	// Use this for initialization
	void Start () {
		GM = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		BS = GameObject.FindGameObjectWithTag ("Button").GetComponent<ButtonScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (BS._active) {
			//this.renderer.enabled = false;
			this.gameObject.layer = 9;
			this.collider2D.enabled = true;
		}else{
			//this.renderer.enabled = true;
			this.gameObject.layer = 10;
			this.collider2D.enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player"){
			if (GM.CurrentLevel == 0) {
				Application.LoadLevel (1);
				//GM.AddToLevel();
			}else if(GM.CurrentLevel == 1){
				Application.LoadLevel(2);
				//GM.AddToLevel();
			}
		}
	}
}
