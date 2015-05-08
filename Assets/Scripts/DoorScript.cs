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
	void Update () {//if the button is active the collider on the door is active
		if (BS._active) {
			this.gameObject.layer = 9;
			this.collider2D.enabled = true;
		}else{
			this.gameObject.layer = 10;
			this.collider2D.enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){//I ran into the problem where certain effects will carry over to the next level
		if (other.gameObject.tag == "Player"){
            if (Time.timeScale != 1)//checks to make sure the time is not slowed, if it is it returns it to normal.
            {
                Time.timeScale = 1;
            }
            if (GM.CurrentLevel != 4)//lazy way of transitioning level. the game manager will add to the currentlevel and then calls the next level.
            {
                GM.AddToLevel();
                Application.LoadLevel(GM.CurrentLevel);
            }
            else if (GM.CurrentLevel == 4)//returns to home screen.
            {
                Application.LoadLevel(0);
            }
		}
	}
}
