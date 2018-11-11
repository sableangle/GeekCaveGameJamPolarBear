using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class BGMSwitcher : MonoBehaviour {
	public GameObject Gaming;
	public GameObject Lose;
	public static BGMSwitcher Instance;
	// Use this for initialization
	void Awake () {
		Instance = this;
	}

	void Start(){
		PlayGameingBGM();
	}

	public void PlayGameingBGM(){
		Gaming.SetActive(true);
		Lose.SetActive(false);
	}
	
	public void PlayDeadBGM(){
		Gaming.SetActive(false);
		Lose.SetActive(true);
	}
	
}
