using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int PlayerLives;
	public int CurrentLevel;
    public GUIStyle style;

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
        //if (Application.loadedLevel == 1)
        //{
        //    PlayerLives = 5;
        //}
        
	}
	
	// Update is called once per frame
	void Update () {
        CurrentLevel = Application.loadedLevel;
        if (Application.loadedLevel == 0)
        {
            PlayerLives = -1;
        }

        if (Application.loadedLevel != 0)
        {
            if (PlayerLives < 0)
            {
                ResetLives(5);
            }
            if (PlayerLives == 0)
            {
                GameOver();
            }
        }

	}

	void OnGUI(){
        if (Application.loadedLevel != 0 || Application.loadedLevel != 5)
        {
            GUI.Label(new Rect(10, 10, 150, 150), ("Player Lives: " + PlayerLives), style);
        }
        if (Application.loadedLevel == 5)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 150, 150), ("GameOver"), style);
            if(GUI.Button(new Rect(Screen.width / 2, (Screen.height / 2) - 150, 150,150), "Main Menu")){
                Application.LoadLevel(0);
            }
        }
	}

	public void RemoveFromLives(){
		PlayerLives--;
	}

	public void AddToLevel(){
		CurrentLevel++;
	}

    public void GameOver() {
        if (PlayerLives == 0) {
            Application.LoadLevel(5);
        }
    }

    public void ResetLives(int lives)
    {
        PlayerLives = lives;
    }
}
