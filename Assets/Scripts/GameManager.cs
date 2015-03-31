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

	public void RemoveFromLives(){
		PlayerLives--;
	}
}
