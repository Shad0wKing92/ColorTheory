using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int PlayerLives;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 150, 150), ("Player Lives: " + PlayerLives));
	}

	public void RemoveFromLives(){
		PlayerLives--;
	}
}
