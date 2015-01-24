using UnityEngine;
using System.Collections;

public class ManageRooms : MonoBehaviour {
	
	public GameObject[] rooms;
	private Vector3[]	roomsPositions;

	public GameObject[] poolRoomsS;
	public GameObject[] poolRoomsR;
	public GameObject[] poolRoomsF;

	public float speedChange = 2.0f;

	public int roomsToTop = 1;
	public int roomsToFloor = 1;
	private int level=0;


	private GameObject newRoom=null;

	private Vector3 currentRoomPosition;
	private Vector3 targetRoomPosition;

	private float startTime = 1.0f;
	private bool isMoving = false;
	private int choice=0;

	void Start () {
		currentRoomPosition=rooms[0].transform.position;
		targetRoomPosition=currentRoomPosition;
		targetRoomPosition.z = 1.0f;

		roomsPositions = new Vector3[rooms.Length];
		for(int i=0;i<rooms.Length;i++)
			roomsPositions[i]=rooms[i].transform.position;

		Destroy(rooms[1]);
		Destroy(rooms[2]);
		Destroy(rooms[3]);

		rooms[1]=MakeRoom(level+1,roomsPositions[1]);
		rooms[2]=MakeRoom(level,roomsPositions[2]);
		rooms[3]=MakeRoom(level-1,roomsPositions[3]);

	}

	void Update () {


		if(!isMoving && Input.GetKey("1") && level != roomsToTop){
			newRoom=rooms[1];
			startTime = 0.0f;
			choice=1;
			level +=1;
			isMoving=true;
		}
		if(!isMoving && Input.GetKey("2")){
			newRoom=rooms[2];
			choice=2;
			startTime = 0.0f;
			isMoving=true;
		}
		if(!isMoving && Input.GetKey("3") && level != -roomsToFloor){
			newRoom=rooms[3];
			startTime = 0.0f;
			choice=3;
			level -=1;
			isMoving=true;
		}
		
		if(newRoom){
			isMoving=true;
			MoveObject(rooms[0].transform,rooms[0].transform.position,targetRoomPosition,1);
			MoveObject(newRoom.transform,newRoom.transform.position,currentRoomPosition,1);

			if(newRoom.transform.position==currentRoomPosition){

				Destroy(rooms[0]);
				rooms[0]=newRoom;
				if(choice!=1)
					Destroy(rooms[1]);
				if(choice!=2)
					Destroy(rooms[2]);
				if(choice!=3)
					Destroy(rooms[3]);
				choice=0;

				if(level!=roomsToTop)
					rooms[1]=MakeRoom(level+1,roomsPositions[1]);
				rooms[2]=MakeRoom(level,roomsPositions[2]);
				if(level!=-roomsToFloor)
					rooms[3]=MakeRoom(level-1,roomsPositions[3]);

				isMoving=false;

				newRoom=null;

			}
				
		}

	
	}


	private void MoveObject( Transform thisTransform, Vector3 startPos ,  Vector3 endPos, float time ) {
		float rate = speedChange/time; if (startTime < 1.0f) {
			startTime += Time.deltaTime * rate; thisTransform.position = Vector3.Lerp(startPos, endPos, startTime); 
		}
	}

	private GameObject MakeRoom(int level, Vector3 position){

		GameObject inst=null;
		if(level == roomsToTop){
			inst=poolRoomsR[Random.Range(0,poolRoomsR.Length)];
		}
		if(level < roomsToTop && level > -roomsToFloor){
			inst=poolRoomsS[Random.Range(0,poolRoomsS.Length)];
		}
		if(level == -roomsToTop){
			inst=poolRoomsF[Random.Range(0,poolRoomsF.Length)];
		}
		

		return GameObject.Instantiate(inst,position,Quaternion.identity) as GameObject;

	}



}


