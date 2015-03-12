using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void powerUpHandler(bool isPoweredUP);

	public static event powerUpHandler Handle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnGUI(){
//		if (GUI.Button (new Rect (5, 5, 150, 40), "Power UP")) {
//			if(Handle != null){
//				Handle(true);
//			}
//		}
//		if (GUI.Button (new Rect (5, 50, 150, 40), "Power Down")) {
//			if(Handle != null){
//				Handle(false);
//			}
//		}
//	}
}
