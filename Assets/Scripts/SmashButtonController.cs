using UnityEngine;
using System.Collections;

public class SmashButtonController : MonoBehaviour {

	public UIProgressBar smashbar;
	public GameObject win;
	public GameObject A;
	public GameObject X;
	private bool disableA;
	private bool disableX;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("A") && !disableA) {
			disableX = true;
			A.SetActive (true);
			smashbar.value += 0.15f;
		}
		if (Input.GetButtonDown ("X") && !disableX) {
			disableA = true;
			X.SetActive (true);
			smashbar.value += 0.15f;
		}
		if (smashbar.value != 1) {
			smashbar.value -= 0.01f;
		} else {
			win.SetActive(true);
		}
	}
}
