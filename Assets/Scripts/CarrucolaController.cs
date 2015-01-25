using UnityEngine;
using System.Collections;

public class CarrucolaController : MonoBehaviour {

	private bool disableA;
	private bool disableX;
	private bool disableY;
	private bool disableB;
	private bool disableUp;
	private bool disableDown;
	private bool disableLeft;
	private bool disableRight;
	public GameObject[] inventory;
	public GameObject[] objects;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("A") && !disableA) {
			disableA = true;
			objects[0].transform.position = inventory[0].transform.position;
		}
		if (Input.GetButtonDown ("X") && !disableX) {
			disableX = true;
			objects[1].transform.position = inventory[1].transform.position;
		}
		if (Input.GetButtonDown ("Y") && !disableY) {
			disableY = true;
			objects[2].transform.position = inventory[2].transform.position;
		}
		if (Input.GetButtonDown ("B") && !disableB) {
			disableB = true;
			objects[3].transform.position = inventory[3].transform.position;
		}
		else if (Input.GetAxis("Horizontal") < 0 && !disableLeft) {
			disableLeft = true;
			objects[4].transform.position = inventory[0].transform.position;
		}
		else if (Input.GetAxis ("Vertical") > 0 && !disableUp) {
			disableUp = true;
			objects[5].transform.position = inventory[1].transform.position;
		}
		else if (Input.GetAxis("Horizontal") > 0 && !disableRight) {
			disableRight = true;
			objects[6].transform.position = inventory[2].transform.position;
		}
		else if (Input.GetAxis ("Vertical") < 0 && !disableDown) {
			disableDown = true;
			objects[7].transform.position = inventory[3].transform.position;
		}


	}
}
