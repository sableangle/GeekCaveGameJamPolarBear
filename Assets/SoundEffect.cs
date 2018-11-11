using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {
	public static SoundEffect Instance;

	public AudioSource source;
	public AudioClip loseSound;
	public AudioClip btnSound;
	public AudioClip hitSound;
	public AudioClip addSound;
	public AudioClip uchiSound;
	public AudioClip fishJumpSound;
	// Use this for initialization
	void Awake () {
		Instance = this;

	}
	
	public void PlayLoseSound(){
		source.PlayOneShot(loseSound);
	}
	public void PlayBtnSound(){
		source.PlayOneShot(btnSound);
	}

	public void PlayHitSound(){
		source.PlayOneShot(hitSound);
	}
	public void PlayAddSound(){
		source.PlayOneShot(addSound);
	}
	public void PlayUchiSound(){
		source.PlayOneShot(uchiSound);
	}

	public void PlayFishJumpSound(){
		source.PlayOneShot(fishJumpSound);
	}
}
