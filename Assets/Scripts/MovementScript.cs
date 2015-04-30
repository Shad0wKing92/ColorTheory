using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {



	KeyManagerScript KMS;
	RiftManagerScript RMS;
	SoundManager SM;
	public float force;
	public float speed;
    [HideInInspector]public bool grabbed;
	GameObject grabbable;
    [HideInInspector]public bool grabbing;
	int count = 4;
	[HideInInspector]public bool powerActive;
	[HideInInspector]public bool grounded;

	// Use this for initialization
	void Start () {
		//find the scripts for the components
		KMS = GameObject.FindGameObjectWithTag ("KeyManager").GetComponent<KeyManagerScript> ();
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
		SM = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		grabbed = false;
		grabbable = null;
		grabbing = false;
//		SM.BackgroundMusic.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0){

			//make player jump
            if (Input.GetKeyDown(KMS.jump) || Input.GetKeyDown(KMS.KeyBoardjump))
            {
				//check if object is on ground (see GroundBehavior)
				if(grounded){
					if(RMS.currentRift == RiftManagerScript.rifts.red && powerActive){
						rigidbody2D.AddForce(-Vector2.up * force);
						SM.jump.Play();
					}else{
						rigidbody2D.AddForce(Vector2.up * force);
						SM.jump.Play();
					}
				}
			}
			if (Input.GetKeyDown(KMS.power) || Input.GetKeyDown(KMS.KeyBoardpower) || Input.GetKeyDown(KMS.power2))
            {
				if(RMS.currentRift == RiftManagerScript.rifts.yellow){
					MultiJump();
				}
				if(RMS.currentRift == RiftManagerScript.rifts.blue){
					powerActive = true;
					SlowWorld();
				}
				if(RMS.currentRift == RiftManagerScript.rifts.red){
					powerActive = true;
					GravitySwitch(true);
				}
			}
//			if(!powerActive){
//				ResetVaules();
//			}
			//move player right
            if (Input.GetAxis("HorizontalJoy") >= 0.1 || Input.GetKey(KMS.right))
            {
				rigidbody2D.AddForce (Vector2.right * speed);
			}
			//move player left
            if (Input.GetAxis("HorizontalJoy") <= -0.1 || Input.GetKey(KMS.left))
            {
				rigidbody2D.AddForce (-Vector2.right * speed);
			}
		}
        if (Input.GetKeyDown(KMS.grab) || Input.GetKeyDown(KMS.KeyBoardgrab))
        {
			grabbing = true;

	        if (grabbed)
	        {
	            if (Input.GetKeyDown(KMS.grab) || Input.GetKeyDown(KMS.KeyBoardgrab))
	            {
	                Release();
	            }
	        }
        }

        


	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            ResetCount();
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

	//make player grab cubes or whatever
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		}

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
//		if(!grabbable == null){
			if (grabbable.tag == "Grabbable") {
				if(grabbable.gameObject.rigidbody2D == null){
					grabbable.gameObject.AddComponent<Rigidbody2D>();
					grabbable.transform.parent = null;
				}
			}
//		}
	}
	//Color Yellow Power
	void MultiJump(){
		if(count == 4){
			rigidbody2D.AddForce(Vector2.up * (0.8f * force));
			count--;
			SM.YellowPower.Play();
		}else if(count == 3){
			rigidbody2D.AddForce(Vector2.up * (0.6f * force));
			count--;
			SM.YellowPower.Play();
		}else if(count == 2){
			rigidbody2D.AddForce(Vector2.up * (0.4f * force));
			count--;
			SM.YellowPower.Play();
		}else if(count == 1){
			rigidbody2D.AddForce(Vector2.up * (0.2f * force));
			count--;
			SM.YellowPower.Play();
		}else if(count == 0){
			rigidbody2D.AddForce(Vector2.up * 0);
		}
		if(grounded){
			count = 4;
		}
	}

	IEnumerator PowerSpeed(float time){
		yield return new WaitForSeconds (time);
		powerActive = false;
		ResetVaules ();
	}
	//Color Blue Power
	void SlowWorld(){
		if(Time.timeScale != 0){
			if (powerActive) {
				SM.BluePower.Play();
				Time.timeScale = 0.5f;
				speed = 8f;
				StartCoroutine(PowerSpeed(2f));
			}
		}
	}

	void GravitySwitch(bool active){
		if (powerActive) {
			SM.RedPower.Play();
			this.rigidbody2D.gravityScale = -1f;
			StartCoroutine(PowerSpeed(6f));
		}
	}

	void ResetCount(){
		count = 4;
	}

	void ResetVaules(){
		Time.timeScale = 1;
		force = 400;
		speed = 5f;
		rigidbody2D.gravityScale = 1;
	}

    public void Release()
    {
        if (grabbed)
        {
            AddRigidbody();
            grabbed = false;
        }
        grabbing = false;
    }
}
