using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public GameObject grabbable;
	public GameObject Player;
	public bool GrabbableInFeild;
	public bool PlayerInFeild;
    public GameObject DeathParticle;

	public enum spawner{player, grabbable};
	public spawner spawnerType; 

	// Use this for initialization
	void Start () {
		GrabbableInFeild = true;
		PlayerInFeild = true;
	}
	
	// Update is called once per frame
	void Update () {//if the grabbable is destroyed it will spawn a new one
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

	public void MoveObject(GameObject thing){//moves the player, the camera still has to find the player and if the player is destroyed the camera will not be able to find the player.
		thing.rigidbody2D.velocity = new Vector2(0,0);
		thing.transform.position = this.transform.position;
		thing.transform.rotation = this.transform.rotation;
	}
}
