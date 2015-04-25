using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {


	public GUISkin myGUISkin;
	public Texture2D background, logo, Controller;
	public Rect windowRect = new Rect ((Screen.width / 2), (Screen.height / 2), 200, 200);

    public int ContX;
    public int ContY;

	string menuState;
	string main = "main";
	string options = "options";
	string credits = "credits";
	string textToDisplay = "Credits: \n";
	float volume;

	public string[] creditsTextLines;

//	static private UIManager instance;
//	
//	static public UIManager Instance{
//		get { return instance;}
//	}
	
//	void Awake () {
//		if(instance != null && instance != this){
//			Destroy (gameObject);
//		}else{
//			instance = this;
//		}
//		
//		DontDestroyOnLoad (gameObject);
//	}
	// Use this for initialization
	void Start () {
		menuState = main;

		for (int i = 0; i < creditsTextLines.Length; i++) {
			textToDisplay += creditsTextLines[i] + "\n";
		}
		textToDisplay += "Press Back To Go Back";
	}
	
	// Update is called once per frame
	void Update () {
		if (menuState == credits && Input.GetKeyDown (KeyCode.Joystick1Button6))
			menuState = main;
	}

	void OnGUI(){
		if (background != null) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		}
		if (logo != null) {
			GUI.DrawTexture(new Rect(Screen.width / 2 - 100, 30, 300,200), logo);
		}
        if (Controller != null)
        {
            GUI.DrawTexture(new Rect(ContX, ContY, 300, 200), Controller);
        }

		GUI.skin = myGUISkin;

		if (menuState == main) {
			windowRect = GUI.Window(0, windowRect, MenuFunc, "Main Menu");
		}
		if (menuState == options) {
			windowRect = GUI.Window(1, windowRect, OptionsFunc, "Options");
		}
		if (menuState == credits) {
			GUI.Box(new Rect(0,0,Screen.width,Screen.height), textToDisplay);
		}
	}

	void MenuFunc(int id){
		if (GUILayout.Button ("Play game")) 
		{
			Application.LoadLevel(1);
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
}
