using UnityEngine;
using System.Collections;

public class ManageRooms : MonoBehaviour
{

		//stanze (prima + dummies per le posizioni)
		public GameObject[] rooms;
		private Vector3[]	roomsGamesPositions;

		//stanze di livello e 
		public GameObject[] poolRoomsS;
		public GameObject[] poolRoomsR;
		public GameObject[] poolRoomsF;
		public GameObject[] poolRoomsGamesB;
		public GameObject[] poolRoomsGamesS;
		public GameObject[] poolRoomsGamesE;
		public int score = 0;
		public float speedChange = 2.0f;
		public int roomsToTop = 1;
		public int roomsToFloor = 1;
		public bool inGame = false;
		private int level = 0;
		private int porta = 0;
		private GameObject newRoom = null;
		private Vector3 currentRoomPosition;
		private Vector3 targetRoomPosition;
		private float startTime = 1.0f;
		private bool isMoving = false;
		private int choice = 0;
		private bool endedGame = false;
		private GameObject game;

		void Start ()
		{
				currentRoomPosition = rooms [0].transform.position;
				targetRoomPosition = currentRoomPosition;
				targetRoomPosition.z = 1.0f;

				roomsGamesPositions = new Vector3[rooms.Length];
				for (int i=0; i<rooms.Length; i++)
						roomsGamesPositions [i] = rooms [i].transform.position;

				Destroy (rooms [1]);
				Destroy (rooms [2]);
				Destroy (rooms [3]);
				Destroy (rooms [4]);

//		rooms[1]=MakeRoom(level+1,roomsGamesPositions[1]);
//		rooms[2]=MakeRoom(level,roomsGamesPositions[2]);
//		rooms[3]=MakeRoom(level-1,roomsGamesPositions[3]);

		}

		void Update ()
		{
				//DEBUG
				if (inGame && Input.GetKey (KeyCode.Space)) {
						endedGame = true;
						inGame = false;
				}
	
				if (!inGame) {
	
						if (endedGame) {
				
								if (rooms [0] != game) {
				
										Destroy (rooms [0]);
										rooms [0] = game;
										newRoom = MakeRoom (level, roomsGamesPositions [4]);
										startTime = 0.0f;
								}
				
				
								MoveObject (rooms [0].transform, rooms [0].transform.position, targetRoomPosition, 1);
								MoveObject (newRoom.transform, newRoom.transform.position, currentRoomPosition, 1);
				
								if (newRoom.transform.position == currentRoomPosition) {
					
										//	if (choice != 1)
										//		Destroy (rooms [1]);
										//	if (choice != 2)
										//		Destroy (rooms [2]);
										//	if (choice != 3)
										//		Destroy (rooms [3]);
					
										game = null;
										Destroy (rooms [0]);
										rooms [0] = newRoom;
										score++;
										Debug.Log (score);
					
										isMoving = false;
					
										newRoom = null;
										endedGame = false;
					
								}
						} else {		
				
								if (!isMoving && Input.GetKey ("1") && level != roomsToTop) {
										//newRoom = rooms [1];
										//startTime = 0.0f;
										choice = 1;
										level += 1;
										//isMoving = true;
								}
								if (!isMoving && Input.GetKey ("2")) {
										//newRoom = rooms [2];
										choice = 2;
										//startTime = 0.0f;
										//isMoving = true;
								}
								if (!isMoving && Input.GetKey ("3") && level != -roomsToFloor) {
										//newRoom = rooms [3];
										//startTime = 0.0f;
										choice = 3;
										level -= 1;
										//isMoving = true;
								}
				
								if (choice != 0) {
					
										if (!isMoving) {
												InfoPorte porte = rooms [0].transform.GetComponent<InfoPorte> ();
												porta = 0;
												if (choice == 1)
														porta = porte.portaSu;
												if (choice == 2)
														porta = porte.portaDx;
												if (choice == 3)
														porta = porte.portaGiu;
					
					
												game = MakeRoomGame (porta, roomsGamesPositions [choice]);
												startTime = 0.0f;
										}
					
										isMoving = true;
					
										MoveObject (rooms [0].transform, rooms [0].transform.position, targetRoomPosition, 1);
										MoveObject (game.transform, game.transform.position, currentRoomPosition, 1);

										//MoveObject(newRoom.transform,newRoom.transform.position,currentRoomPosition,1);
		
										if (game.transform.position == currentRoomPosition) {
												choice = 0;
												inGame = true;
												//Parte gioco, se non perdo continua
										}
								}
						}
					
					
		

				}

		}

		private void MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
		{
				float rate = speedChange / time;
				if (startTime < 1.0f) {
						startTime += Time.deltaTime * rate;
						thisTransform.position = Vector3.Lerp (startPos, endPos, startTime); 
				}
		}

		private GameObject MakeRoom (int level, Vector3 position)
		{

				GameObject inst = null;
				if (level == roomsToTop) {
						inst = poolRoomsR [Random.Range (0, poolRoomsR.Length)];
				}
				if (level < roomsToTop && level > -roomsToFloor) {
						inst = poolRoomsS [Random.Range (0, poolRoomsS.Length)];
				}
				if (level == -roomsToTop) {
						inst = poolRoomsF [Random.Range (0, poolRoomsF.Length)];
				}
	

				return GameObject.Instantiate (inst, position, Quaternion.identity) as GameObject;

		}

		private GameObject MakeRoomGame (int type, Vector3 position)
		{
	
				GameObject inst = null;
				if (type == 1) {
						inst = poolRoomsGamesB [Random.Range (0, poolRoomsGamesB.Length)];
				}
				if (type == 2) {
						inst = poolRoomsGamesS [Random.Range (0, poolRoomsGamesS.Length)];
				}
				if (type == 3) {
						inst = poolRoomsGamesE [Random.Range (0, poolRoomsGamesE.Length)];
				}
	
				return GameObject.Instantiate (inst, position, Quaternion.identity) as GameObject;
	
		}



}


