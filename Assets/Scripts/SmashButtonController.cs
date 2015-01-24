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
		A.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
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
			smashbar.value += 0.15f;
		}
		if (smashbar.value != 1) {
			smashbar.value -= 0.01f;
		} else {
			win.SetActive(true);
		}
	}
}
