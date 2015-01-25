using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {

	public GameObject satelliteA;
	public GameObject satelliteX;
	public GameObject satelliteY;
	public GameObject satelliteB;
	public float timeToRotate = 2f;
	public GameObject winLabel;
//	public GameObject winVolume;
	private float t;
	private bool canTurnA;
	private bool canTurnX;
	private bool canTurnY;
	private bool canTurnB;
	private int posIndexA = 0;
	private int posIndexX = 0;
	private int posIndexY = 0;
	private int posIndexB = 0;
	private int stopIndexA = 0;
	private int stopIndexX = 0;
	private int stopIndexY = 0;
	private int stopIndexB = 0;
	private int winIndex;
	// Use this for initialization
	
	public RoomTimer timer;
	public ManageRooms stanza;
	
	
	void Start () {
	
		stanza = GameObject.Find("Room").GetComponent<ManageRooms>();
		stanza.GetComponent<ManageRooms>();
		
		timer = GameObject.Find("Timer").GetComponent<RoomTimer>();
		timer.GetComponent<RoomTimer>();
		
		timer.seconds=6;
		timer.StartTimer();
	
		canTurnA = true;
		canTurnX = true;
		canTurnY = true;
		canTurnB = true;
		winIndex = 0;
		stopIndexA = 0;
		stopIndexB = 1;
		stopIndexX = 2;
		stopIndexY = 3;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (t > timeToRotate) {
			t -= timeToRotate;
			if(canTurnA){
				satelliteA.transform.Rotate(0, 0, -45);
				if(posIndexA < 7)
					posIndexA++;
				else
					posIndexA = 0;
			}
			if(canTurnX){
				satelliteX.transform.Rotate(0, 0, 45);
				if(posIndexX < 7)
					posIndexX++;
				else
					posIndexX = 0;
			}
			if(canTurnY){
				satelliteY.transform.Rotate(0, 0, -45);
				if(posIndexY < 7)
					posIndexY++;
				else
					posIndexY = 0;
			}
			if(canTurnB){
				satelliteB.transform.Rotate(0, 0, 45);
				if(posIndexB < 7)
					posIndexB++;
				else
					posIndexB = 0;
			}
		}

//		if (canTurnA) {
//			satelliteA.transform.Rotate(new Vector3(0,0,1));
//		}
//		if (canTurnX) {
//			satelliteX.transform.Rotate(new Vector3(0,0,-0.9f));
//		}
//		if (canTurnY) {
//			satelliteY.transform.Rotate(new Vector3(0,0,1.1f));
//		}
//		if (canTurnB) {
//			satelliteB.transform.Rotate(new Vector3(0,0,-1));
//		}
		if (Input.GetButtonDown ("A") && canTurnA) {
			canTurnA = false;
			stopIndexA = posIndexA;
		}
		else if (Input.GetButtonDown("A") && !canTurnA)
			canTurnA = true;
		if (Input.GetButtonDown ("X") && canTurnX) {
			canTurnX = false;
			stopIndexX = posIndexX;
		}
		else if (Input.GetButtonDown("X") && !canTurnX)
			canTurnX = true;
		if (Input.GetButtonDown ("Y") && canTurnY) {
			canTurnY = false;
			stopIndexY = posIndexY;
		}
		else if (Input.GetButtonDown("Y") && !canTurnY)
			canTurnY = true;
		if (Input.GetButtonDown ("B") && canTurnB) {
			canTurnB = false;
			stopIndexB = posIndexB;
		}
		else if (Input.GetButtonDown("B") && !canTurnB)
			canTurnB = true;
		if (!canTurnA) {
			Debug.Log("A "+stopIndexA + "X "+stopIndexX + "Y "+stopIndexY + "B "+stopIndexB);
			if (stopIndexA == stopIndexB && stopIndexB == stopIndexY && stopIndexY == stopIndexX)
				//winLabel.SetActive (true);
			{timer.StopTimer();
				stanza.Win();}
		}
	}

//	void OnTriggerEnter(Collider c){
//		Debug.Log("trigger");
//		if (c.tag == "Satellite")  {
//
//			winIndex++;
//			if (winIndex == 4)
//					winLabel.SetActive (true);
//		}
//	}
}
