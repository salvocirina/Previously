using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {

	public GameObject satelliteA;
	public GameObject satelliteX;
	public GameObject satelliteY;
	public GameObject satelliteB;
	public float timeToRotate = 2f;
	public GameObject winLabel;
	private float t;
	private bool canTurnA;
	private bool canTurnX;
	private bool canTurnY;
	private bool canTurnB;
	// Use this for initialization
	void Start () {
		canTurnA = true;
		canTurnX = true;
		canTurnY = true;
		canTurnB = true;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (t > timeToRotate) {
			t -= 2f;
			if(canTurnA)
				satelliteA.transform.Rotate(0, 0, -45);
			if(canTurnX)
			satelliteX.transform.Rotate(0, 0, 45);
			if(canTurnY)
			satelliteY.transform.Rotate(0, 0, -45);
			if(canTurnB)
			satelliteB.transform.Rotate(0, 0, 45);
		}
		if (Input.GetButtonDown("A") && canTurnA)
			canTurnA = false;
		else if (Input.GetButtonDown("A") && !canTurnA)
			canTurnA = true;
		if (Input.GetButtonDown("X") && canTurnX)
			canTurnX = false;
		else if (Input.GetButtonDown("X") && !canTurnX)
			canTurnX = true;
		if (Input.GetButtonDown("Y") && canTurnY)
			canTurnY = false;
		else if (Input.GetButtonDown("Y") && !canTurnY)
			canTurnY = true;
		if (Input.GetButtonDown("B") && canTurnB)
			canTurnB = false;
		else if (Input.GetButtonDown("B") && !canTurnB)
			canTurnB = true;
	}

}
