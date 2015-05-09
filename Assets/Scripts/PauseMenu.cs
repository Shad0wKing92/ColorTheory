using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool paused = false;
	public KeyCode pause;

	void Update () {
        if (Application.loadedLevel != 0)
        {
            if (Application.loadedLevel != 5)
            {
                if (Application.loadedLevel != 6)
                {
                    if (Input.GetKeyDown(pause))
                    {
                        paused = togglePause();
                    }
                }
            }
        }
	}

	bool togglePause(){
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);
		}
	}

	void OnGUI()
	{
		if(paused)
		{
			GUI.Box(new Rect(0,0, Screen.width, Screen.height), "");
			GUI.Box(new Rect(Screen.width/2 - 50,Screen.height/2 - 10, 200, 200), "");
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 100), ("PAUSED!"));
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 75, 100, 50), "Menu")){
				Application.LoadLevel(0);
                paused = togglePause();
			}
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 25, 100, 50), "Resume")){
				paused = togglePause();
			}
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 125, 100, 50), "Quit")){
				Application.Quit();
			}
		}
	}
}
