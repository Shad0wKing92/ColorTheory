using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {

    public float time;

    void Start()
    {//destroys the object after some time, I use this for the particle effects so they don't clog up memory.
        Destroy(this.gameObject, time);
	}
}
