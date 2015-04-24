using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public GameObject grabbable;
	public GameObject Player;
	public bool GrabbableInFeild;
	public bool PlayerInFeild;

	public enum spawner{player, grabbable};
	public spawner spawnerType; 

	// Use this for initialization
	void Start () {
		GrabbableInFeild = true;
		PlayerInFeild = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GrabbableInFeild && spawnerType == spawner.grabbable)
        {
            Instantiate(grabbable, this.transform.position, this.transform.rotation);
            GrabbableInFeild = true;
        }
        //if (!PlayerInFeild && spawnerType == spawner.player)
        //{
        //    Instantiate(Player, transform.position, transform.rotation);
        //    PlayerInFeild = true;
        //}
	}

	public void MoveObject(GameObject thing){
		thing.rigidbody2D.velocity = new Vector2(0,0);
		thing.transform.position = this.transform.position;
		thing.transform.rotation = this.transform.rotation;
	}
}
