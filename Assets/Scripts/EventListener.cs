using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		EventManager.Handle += OnPowered;
	}

	void OnDisable(){
		EventManager.Handle -= OnPowered;
	}

	void OnPowered(bool isPoweredUP){
		print(isPoweredUP);
	}



}
