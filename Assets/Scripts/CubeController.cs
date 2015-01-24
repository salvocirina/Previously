﻿using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	
	public GameObject[] posA;
	public GameObject[] posX;
	public GameObject[] posY;
	public GameObject cubeA;
	public GameObject cubeX;
	public GameObject cubeY;
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
		j = 6;
		k = 2;
		cubeA.transform.position = posA[i].transform.position;
		cubeX.transform.position = posX[j].transform.position;
		cubeY.transform.position = posY[k].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (activeCube == cubeA) {
			if (Input.GetAxis ("Vertical") > 0 && i >= 0 && canScroll) {
				cubeA.transform.position =  posA[i--].transform.position;
			}
			else if (Input.GetAxis ("Vertical") < 0 && i < 7 && canScroll) {
				cubeA.transform.position = posA[i++].transform.position;
			}
		
		} else if (activeCube == cubeX) {
			if (Input.GetAxis ("Vertical") > 0 && i >= 0 && canScroll) {
				cubeX.transform.position = posX[i--].transform.position;
			}
			if (Input.GetAxis ("Vertical") < 0 && i < 7 && canScroll) {
				cubeX.transform.position = posX[i++].transform.position;
			}
		} else if (activeCube == cubeY) {
			if (Input.GetAxis ("Vertical") > 0 && i >= 0 && canScroll) {
				cubeY.transform.position = posY[i--].transform.position;
			}
			if (Input.GetAxis ("Vertical") < 0 && i < 7 && canScroll) {
				cubeY.transform.position = posY[i++].transform.position;
			}
		}

		if (Input.GetButtonDown ("A")) {
			activeCube = cubeA;
		}
		
		if (Input.GetButtonDown ("X")) {
			activeCube = cubeX;
		}

		if (Input.GetButtonDown ("Y")) {
			activeCube = cubeY;
		}
		if (Input.GetAxis ("Vertical") == 0)
			canScroll = true;
		else 
			canScroll = false;
		if (cubeA.transform.position == posA[3].transform.position && cubeX.transform.position == posX [3].transform.position && cubeY.transform.position == posY [3].transform.position)
						winLabel.SetActive (true);
	}
}
