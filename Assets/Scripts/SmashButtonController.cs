﻿using UnityEngine;
using System.Collections;

public class SmashButtonController : MonoBehaviour {

	public UIProgressBar smashbar;
	public GameObject win;
	public GameObject A;
	public GameObject X;
	private bool disableA;
	private bool disableX;
	public int difficulty;
	// Use this for initialization
	void Start () {
		A.SetActive (true);
		difficulty = Random.Range (1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		if (difficulty == 1) {
			if (smashbar.value < 0.5f) {
				if (Input.GetButtonDown ("A") && !disableA)
						smashbar.value += 0.15f;
			} else if (smashbar.value >= 0.5f) {
				if (Input.GetButtonDown ("A") && !disableX)
				smashbar.value += 0.10f;
			}
		}
		else if(difficulty == 2){
			if (smashbar.value < 0.5f) {
				disableX = true;
				disableA = false;
				A.SetActive (true);
				X.SetActive (false);
			if (Input.GetButtonDown ("A") && !disableA)
				smashbar.value += 0.15f;
			}else if (smashbar.value >= 0.5f) {
				A.SetActive (false);
				X.SetActive (true);
				disableA = true;
				disableX = false;
			if (Input.GetButtonDown ("X") && !disableX)
				smashbar.value += 0.12f;
			}
		}
		if (smashbar.value != 1) {
			smashbar.value -= 0.01f;
		} else {
			win.SetActive(true);
		}
	}
}
