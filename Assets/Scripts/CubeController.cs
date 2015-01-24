using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	public GameObject startPosA;
	public GameObject finalPosA;
	public GameObject startPosX;
	public GameObject finalPosX;
	public GameObject cubeA;
	public GameObject cubeX;
//	public GameObject cubeY;
	public GameObject activeCube;
	// Use this for initialization
	void Start () {
		cubeA.transform.position = startPosA.transform.position;
		cubeX.transform.position = startPosX.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (activeCube == cubeA) {
			if (Input.GetAxis ("Vertical") > 0) {
				cubeA.transform.position = finalPosA.transform.position;
			}
			if (Input.GetAxis ("Vertical") < 0) {
				cubeA.transform.position = startPosA.transform.position;
			}
		} else if (activeCube == cubeX) {
			if (Input.GetAxis ("Vertical") > 0) {
				cubeX.transform.position = startPosX.transform.position;
			}
			if (Input.GetAxis ("Vertical") < 0) {
				cubeX.transform.position = finalPosX.transform.position;
			}
		}
		if (Input.GetButtonDown ("A")) {
			activeCube = cubeA;
		}
		
		if (Input.GetButtonDown ("X")) {
			activeCube = cubeX;
		}
	}
}
