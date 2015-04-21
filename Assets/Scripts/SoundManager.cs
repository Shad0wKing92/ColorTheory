using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource jump;
	public AudioSource BackgroundMusic;
	public AudioSource RiftSwitch;
	public AudioSource RedPower;
	public AudioSource YellowPower;
	public AudioSource BluePower;
	public AudioSource SpikeFalling;
	public AudioSource SpikeHitting;
	public AudioSource PlayerDeath;
	public AudioSource GrabbableDeath;
	public AudioSource Door;


	static private SoundManager instance;
	
	static public SoundManager Instance{
		get { return instance;}
	}

	void Awake () {
		if(instance != null && instance != this){
			Destroy (gameObject);
		}else{
			instance = this;
		}
		
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {

	}
}
