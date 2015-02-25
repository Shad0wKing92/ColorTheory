using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public GameObject grabbable;
	public GameObject Player;
	[HideInInspector]public bool GrabbableInFeild;
	[HideInInspector]public bool PlayerInFeild;

	public enum spawner{player, grabbable};
	public spawner spawnerType; 

	// Use this for initialization
	void Start () {
		GrabbableInFeild = true;
		PlayerInFeild = true;
		//grabbable = GameObject.Find("Grabbable");
	}
	
	// Update is called once per frame
	void Update () {
//		if (!GrabbableInFeild && spawnerType == spawner.grabbable) {
//			Instantiate(grabbable, transform.position, transform.rotation);
//			GrabbableInFeild=true;
//		}
//		if (!PlayerInFeild && spawnerType == spawner.player) {
//			Instantiate(Player, transform.position, transform.rotation);
//			PlayerInFeild=true;
//		}
	}
}
