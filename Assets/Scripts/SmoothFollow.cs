//using UnityEngine;
//using System.Collections;
//
//public class SmoothFollow : MonoBehaviour {
//
//	Transform target;
//	Transform thisTransform;
//	Vector2 velocity;
//	public float smoothTime = 0.3f;
//
//	Transform tempx;
//	Transform tempy;
//
//	// Use this for initialization
//	void Start () {
//		thisTransform = transform;
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		tempx = thisTransform;
//		tempy = thisTransform;
//
//		tempx = Mathf.SmoothDamp( thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
//		tempy = Mathf.SmoothDamp( thisTransform.position.y, target.position.y, ref velocity.y, smoothTime);
//	}
//}
