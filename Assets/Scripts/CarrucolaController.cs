using UnityEngine;
using System.Collections;

public class CarrucolaController : MonoBehaviour {

	private bool disableX;
	public GameObject[] inventory;
	public GameObject[] objects;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("A") && !disableX) {
			disableX = true;
			objects[0].transform.position = inventory[0].transform.position;
		}
	}
}
