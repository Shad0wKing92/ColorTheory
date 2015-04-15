using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int PlayerLives;
	public int CurrentLevel;

	static private GameManager instance;
	
	static public GameManager Instance{
		get{ return instance;}
	}
	
	void Awake () {
		if(instance != null && instance != this){
			Destroy (gameObject);
		}else{
			instance = this;
		}
		
		DontDestroyOnLoad (gameObject);
	}

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

//	public void AddToLevel(){
//		CurrentLevel++;
//	}
}
