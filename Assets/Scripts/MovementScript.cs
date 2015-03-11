using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	KeyManagerScript KMS;
	GroundBehavior GB;
	RiftManagerScript RMS;
	public float force;
	public float speed;
	bool grabbed;
	GameObject grabbable;
	bool grabbing;
	int count = 4;
	bool powerActive;

	// Use this for initialization
	void Start () {
		//find the scripts for the components
		KMS = GameObject.FindGameObjectWithTag ("KeyManager").GetComponent<KeyManagerScript> ();
		GB = GameObject.FindGameObjectWithTag ("Ground").GetComponent<GroundBehavior> ();
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
		grabbed = false;
		grabbable = null;
		grabbing = false;
	}
	
	// Update is called once per frame
	void Update () {
		print (GB.grounded);

		//make player jump
		if(Input.GetKeyDown(KMS.jump)){
			//check if object is on ground (see GroundBehavior)
			if(GB.grounded && RMS.currentRift != RiftManagerScript.rifts.yellow){
				rigidbody2D.AddForce(Vector2.up * force);
			}
		}
		if (Input.GetKeyDown (KMS.power)) {
			if(RMS.currentRift == RiftManagerScript.rifts.yellow){
				MultiJump();
			}
			if(RMS.currentRift == RiftManagerScript.rifts.blue){
				powerActive = true;
				SlowWorld();
			}
		}
		if(!powerActive){
			Time.timeScale = 1;
			force = 400;
			speed = 10;
			rigidbody2D.drag = 0.2f;
		}
		print (powerActive);
		print (Time.timeScale);
//		if (Input.GetKeyUp (KMS.power)) {
//			powerActive=false;
//		}
		//move player right
		if (Input.GetKey (KMS.right)) {
			rigidbody2D.AddForce (Vector2.right * speed);
		}
		//move player left
		if (Input.GetKey (KMS.left)) {
			rigidbody2D.AddForce (-Vector2.right * speed);
		}
		if (Input.GetKeyDown (KMS.grab)) {
			grabbing=true;
		}
		if (Input.GetKeyUp (KMS.grab)) {
			grabbing=false;
			AddRigidbody();
		}
	}

	//make player grab cubes or whatever
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
	//Color Yellow Power
	void MultiJump(){
		if(count == 4){
			rigidbody2D.AddForce(Vector2.up * (0.8f * force));
			count--;
		}else if(count == 3){
			rigidbody2D.AddForce(Vector2.up * (0.6f * force));
			count--;
		}else if(count == 2){
			rigidbody2D.AddForce(Vector2.up * (0.4f * force));
			count--;
		}else if(count == 1){
			rigidbody2D.AddForce(Vector2.up * (0.2f * force));
			count--;
		}else if(count == 0){
			rigidbody2D.AddForce(Vector2.up * 0);
		}
		if(GB.grounded == true){
			count = 4;
		}
	}

	IEnumerator PowerSpeed(float time){
		yield return new WaitForSeconds (time);
		powerActive = false;
	}
	//Color Blue Power
	void SlowWorld(){
		if (powerActive) {
			Time.timeScale = 0.5f;
			speed = speed * 2;
			force = force * 2;
			rigidbody2D.drag = rigidbody2D.drag * 2;
			StartCoroutine(PowerSpeed(2f));

		}
	}
}
