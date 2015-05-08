using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int PlayerLives;
	public int CurrentLevel;
    public GUIStyle style;

    #region
    //this prevents the GameManager from being destroyed between scenes.
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

    #endregion
	
	
	void Update ()
    {
        //sets variable to the loaded level.
        CurrentLevel = Application.loadedLevel;
        //if on menu the player lives will always be negative so if the player dies on the menu the scene won't reset
        if (Application.loadedLevel == 0)
        {
            PlayerLives = -1;
        }
        //if player moves off menu level their lives will be set to 5 with the ResetLives method
        if (Application.loadedLevel != 0)
        {
            if (PlayerLives < 0)
            {
                ResetLives(5);
            }
            //if they are not currently on the gameover screen and run out of lives they will go to the game over screen
            if (Application.loadedLevel != 5)
            {
                if (PlayerLives == 0)
                {
                    GameOver();
                }
            }
        }
        
    }

	void OnGUI(){
        if (Application.loadedLevel != 0) //if player is not on start menu
        {
            if (Application.loadedLevel != 5) //if player is not on game over
            {
                //show player lives
                GUI.Label(new Rect(10, 10, 150, 150), ("Player Lives: " + PlayerLives), style);
            }
        }
        if (Application.loadedLevel == 5) //if on gameover screen
        {
            //shows game over GUI and home button
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 150, 150), ("GameOver"), style);
            if(GUI.Button(new Rect(Screen.width / 2, (Screen.height / 2) - 150, 150,150), "Main Menu")){
                Application.LoadLevel(0);
            }
        }
        if (Application.loadedLevel == 6) //if on Win screen
        {
            //shows game over GUI and home button
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 150, 150), ("Congratulations!"), style);
            if (GUI.Button(new Rect(Screen.width / 2, (Screen.height / 2) - 150, 150, 150), "Main Menu"))
            {
                Application.LoadLevel(0);
            }
        }
	}

    public void RemoveFromLives(){
        //subtracts from player lives when called in other scripts
        PlayerLives--;
	}

	public void AddToLevel(){
        //makes changing of level easy, only have to make one method in the door script.
		CurrentLevel++;
	}

    public void GameOver() {
        //if player runs out of lives the player goes to game over screen
        if (PlayerLives == 0) {
            Application.LoadLevel(5);
        }
    }

    public void ResetLives(int lives)
    {
        //resets lives.
        PlayerLives = lives;
    }
}
