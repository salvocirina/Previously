using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	
	public GameObject[] posX;
	public GameObject[] posY;
	public GameObject[] posB;
	public GameObject cubeX;
	public GameObject cubeY;
	public GameObject cubeB;
	public GameObject activeCube;
	public GameObject winLabel;
	private int i;
	private int j;
	private int k;
	private bool canScroll;
//	private float deadZone = 0.03f;
	// Use this for initialization
	void Start () {
		i = 0;
		j = 4;
		k = 2;
		cubeX.transform.position = posX[i].transform.position;
		cubeY.transform.position = posY[j].transform.position;
		cubeB.transform.position = posB[k].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (activeCube == cubeX) {
			if (Input.GetAxis ("Vertical") > 0 && i >= 0 && canScroll) {
				cubeX.transform.position =  posX[i--].transform.position;
			}
			else if (Input.GetAxis ("Vertical") < 0 && i < 5 && canScroll) {
				cubeX.transform.position = posX[i++].transform.position;
			}
		} else if (activeCube == cubeY) {
			if (Input.GetAxis ("Vertical") > 0 && i >= 0 && canScroll) {
				cubeY.transform.position = posY[j--].transform.position;
			}
			else if (Input.GetAxis ("Vertical") < 0 && i < 5 && canScroll) {
				cubeY.transform.position = posY[j++].transform.position;
			}
		} else if (activeCube == cubeB) {
			if (Input.GetAxis ("Vertical") > 0 && i >= 0 && canScroll) {
				cubeB.transform.position = posB[k--].transform.position;
			}
			else if(Input.GetAxis ("Vertical") < 0 && i < 5 && canScroll) {
				cubeB.transform.position = posB[k++].transform.position;
			}
		}

		if (Input.GetButtonDown ("X")) {
			activeCube = cubeX;
		}
		
		if (Input.GetButtonDown ("Y")) {
			activeCube = cubeY;
		}

		if (Input.GetButtonDown ("B")) {
			activeCube = cubeB;
		}
		if (Input.GetAxis ("Vertical") == 0)
			canScroll = true;
		else 
			canScroll = false;
		if (cubeX.transform.position == posX[3].transform.position && cubeY.transform.position == posY [3].transform.position && cubeB.transform.position == posB [3].transform.position)
						winLabel.SetActive (true);
	}
}
