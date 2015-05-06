using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {


	public GUISkin myGUISkin;
	public Texture2D background, logo, Controller;
    Rect windowRect = new Rect(Screen.width / 10, Screen.height /2 - 100, 200, 200);

    public int ContX;
    int ContY = Screen.height - 250;

	string menuState;
	string main = "main";
    string levelSelect = "level select";
	string options = "options";
	string credits = "credits";
	string textToDisplay = "Credits: \n";
	float volume;

	public string[] creditsTextLines;

	void Start () {
		menuState = main;

		for (int i = 0; i < creditsTextLines.Length; i++) {
			textToDisplay += creditsTextLines[i] + "\n";
		}
	}
	
	// Update is called once per frame
	void Update () {
        //if (menuState == credits && Input.GetKeyDown (KeyCode.Joystick1Button6))
        //    menuState = main;
	}

	void OnGUI(){
		if (background != null) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		}
		if (logo != null) {
			GUI.DrawTexture(new Rect(30, 30, 450, 300), logo);
		}
        if (Controller != null)
        {
            GUI.DrawTexture(new Rect(ContX, ContY, 450, 300), Controller);
        }

		GUI.skin = myGUISkin;

		if (menuState == main) {
			windowRect = GUI.Window(0, windowRect, MenuFunc, "Main Menu");
		}
		if (menuState == options) {
			windowRect = GUI.Window(1, windowRect, OptionsFunc, "Options");
		}
		if (menuState == credits) {
            windowRect = GUI.Window(3, windowRect, CreditsFunc, "Credits");
            //GUI.Box(new Rect(0,0,Screen.width,Screen.height), textToDisplay);
		}
        if (menuState == levelSelect)
        {
            windowRect = GUI.Window(2, windowRect, LevelSelectFunc, "Level Select");
        }
	}

	void MenuFunc(int id){
		if (GUILayout.Button ("Play game")) 
		{
			Application.LoadLevel(1);
		}
        if (GUILayout.Button("Level Select"))
        {
            menuState = levelSelect;
        }
        if (GUILayout.Button("Options"))
        {
			menuState = options;
		}
        if (GUILayout.Button("Credits"))
        {
			menuState = credits;
		}
		if (GUILayout.Button ("Quit Game")) {
			Application.Quit();
		}
	}

	void OptionsFunc(int id){
		GUILayout.Box("Volume");
		volume = GUILayout.HorizontalSlider (volume, 0.0f, 1.0f);
		AudioListener.volume = volume;
		if (GUILayout.Button ("Back")) {
			menuState = main;
		}
	}

    void LevelSelectFunc(int id)
    {
        if (GUILayout.Button("Intro"))
        {
            Application.LoadLevel(1);
        }
        if (GUILayout.Button("Level Red"))
        {
            Application.LoadLevel(2);
        }
        if (GUILayout.Button("Level Yellow"))
        {
            Application.LoadLevel(3);
        }
        if (GUILayout.Button("Level Blue"))
        {
            Application.LoadLevel(4);
        }
    }

    void CreditsFunc(int id)
    {
        GUILayout.Box("Credits");
        GUILayout.Label(textToDisplay);
        //GUI.Label(windowRect, textToDisplay);
        if (GUILayout.Button("Back"))
        {
            menuState = main;
        }
    }
}
