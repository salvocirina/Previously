using UnityEngine;
using System.Collections;

public class SmashActive : MonoBehaviour {

	public GameObject smash;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("A") || Input.GetButtonDown ("X") || Input.GetButtonDown ("Y") || Input.GetButtonDown ("B")) {
			smash.SetActive(true);
		}

	}
}
