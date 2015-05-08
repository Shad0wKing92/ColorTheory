using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float RotateSpeed;
	public enum Rotation{None, Forward, Backward, Up, Down, Right, Left}
	public Rotation CurrentRotate;

    
	void Update () {//rotation stuff for the background things
		if(CurrentRotate == Rotation.Forward)
			this.gameObject.transform.Rotate (Vector3.forward * Time.deltaTime * RotateSpeed);
		else if(CurrentRotate == Rotation.Backward)
			this.gameObject.transform.Rotate (-Vector3.forward * Time.deltaTime * RotateSpeed);
		else if(CurrentRotate == Rotation.Up)
			this.gameObject.transform.Rotate (Vector3.up * Time.deltaTime * RotateSpeed);
		else if(CurrentRotate == Rotation.Down)
			this.gameObject.transform.Rotate (-Vector3.up * Time.deltaTime * RotateSpeed);
		else if(CurrentRotate == Rotation.Right)
			this.gameObject.transform.Rotate (Vector3.right * Time.deltaTime * RotateSpeed);
		else if(CurrentRotate == Rotation.Left)
			this.gameObject.transform.Rotate (-Vector3.right * Time.deltaTime * RotateSpeed);
	}
}
