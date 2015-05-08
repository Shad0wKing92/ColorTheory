using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource jump;
	public AudioSource Bell;
	public AudioSource RiftSwitch;
	public AudioSource RedPower;
	public AudioSource YellowPower;
	public AudioSource BluePower;
	public AudioSource SpikeFalling;
	public AudioSource SpikeHitting;
	public AudioSource PlayerDeath;
	public AudioSource GrabbableDeath;
	public AudioSource Door;

    //this script holds the sounds. in the inspector the soundManager will hold all of the sources and then each one is dragged into the public source.
    //when the sound needs to be played the script in the exact moment it happens calls the Sound manager to play the sound it wants.

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
}
