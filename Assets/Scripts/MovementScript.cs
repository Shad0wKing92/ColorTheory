using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	KeyManagerScript KMS;
	GroundBehavior GB;
	public float force;
	public float speed;
	bool grabbed;
	GameObject grabbable;
	bool grabbing;

	// Use this for initialization
	void Start () {
		//find the scripts for the components
		KMS = GameObject.FindGameObjectWithTag ("KeyManager").GetComponent<KeyManagerScript> ();
		GB = GameObject.FindGameObjectWithTag ("Ground").GetComponent<GroundBehavior> ();
		grabbed = false;
		grabbable = null;
		grabbing = false;
	}
	
	// Update is called once per frame
	void Update () {
		//make player jump
		if(Input.GetKeyDown(KMS.jump)){
			//check if object is on ground (see GroundBehavior)
			if(GB.grounded){
				rigidbody2D.AddForce(Vector2.up * force);
//				if(grabbable != null)
//					grabbable.rigidbody2D.AddForce(Vector2.up * force);
			}
		}
		//move player right
		if (Input.GetKey (KMS.right)) {
			rigidbody2D.AddForce (Vector2.right * speed);
//			if(grabbable != null)
//				grabbable.rigidbody2D.AddForce(Vector2.right * speed);
		}
		//move player left
		if (Input.GetKey (KMS.left)) {
			rigidbody2D.AddForce (-Vector2.right * speed);
//			if(grabbable != null)
//				grabbable.rigidbody2D.AddForce(-Vector2.right * speed);
		}
		if (Input.GetKeyDown (KMS.grab)) {
			print("grabbing");
			grabbing=true;
		}
		if (Input.GetKeyUp (KMS.grab)) {
			print("not grabbing");
			grabbing=false;
			AddRigidbody();
		}


		//make player grab cubes or whatever
	}

	void OnCollisionStay2D(Collision2D other){
		if(grabbing){
			if (other.gameObject.tag == "Grabbable") {			
				other.transform.parent = this.transform;
				grabbable = other.gameObject;
				grabbed = true;
				Destroy(other.gameObject.rigidbody2D);
			}
		}else
			grabbed = false;
		}

	void AddRigidbody(){
		if (grabbable.tag == "Grabbable") {
			if(grabbable.gameObject.rigidbody2D == null){
				grabbable.gameObject.AddComponent<Rigidbody2D>();
				grabbable.transform.parent = null;
			}
		}
	}
}
