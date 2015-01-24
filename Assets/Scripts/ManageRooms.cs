using UnityEngine;
using System.Collections;

public class ManageRooms : MonoBehaviour {
	
	public GameObject[] rooms;

	public float speedChange = 2.0f;

	private GameObject newRoom=null;

	private Vector3 currentRoomPosition;
	private Vector3 targetRoomPosition;

	private float startTime = 1.0f;

	void Start () {
		currentRoomPosition=rooms[0].transform.position;
		targetRoomPosition=currentRoomPosition;
		targetRoomPosition.z = 1.0f;
	}

	void Update () {


		if(Input.GetKey("1")){
			newRoom=rooms[1];
			startTime = 0.0f;
		}
		if(Input.GetKey("2")){
			newRoom=rooms[2];
			startTime = 0.0f;
		}
		if(Input.GetKey("3")){
			newRoom=rooms[3];
			startTime = 0.0f;
		}
		
		if(newRoom){
		

			MoveObject(rooms[0].transform,rooms[0].transform.position,targetRoomPosition,1);
			MoveObject(newRoom.transform,newRoom.transform.position,currentRoomPosition,1);

			if(newRoom.transform.position==transform.position){
				newRoom=null;
			}
				
		}

	
	}


	private void MoveObject( Transform thisTransform, Vector3 startPos ,  Vector3 endPos, float time ) {
		float rate = speedChange/time; if (startTime < 1.0f) {
			startTime += Time.deltaTime * rate; thisTransform.position = Vector3.Lerp(startPos, endPos, startTime); 
		}
	}

}
