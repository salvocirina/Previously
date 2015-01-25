using UnityEngine;
using System.Collections;

public class ManageRooms : MonoBehaviour
{

		//stanze (prima + dummies per le posizioni)
		public GameObject[] rooms;
		private Vector3[]	roomsGamesPositions;
		public Animator anim;
		public GameObject hik;
		public GameObject door;
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
		private InfoPorte porte;
		private Vector3 support;
		private float journeyLength;
		
	public RoomTimer timer;
	//private GameObject timerObj;
		
		public void Win(){
			endedGame=true;
			inGame=false;
		}
		
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


			porte = rooms [0].transform.GetComponent<InfoPorte> ();

			//timer=timerObj.GetComponent<RoomTimer>();
			timer.seconds=2;
			timer.StartTimer();
		
		}

		void Update ()
		{
		//DEBUG
				if (inGame && Input.GetKey (KeyCode.Space)) {
						endedGame = true;
						inGame = false;
						
				} else if (Input.GetButtonDown ("Start")) {
//					hik.transform.position = door.transform.position;
					hik.transform.position = Vector3.Lerp(hik.transform.position, door.transform.position, Time.time *1.7f);
				}
	
				if (!inGame) {
	
						if (endedGame) {
							if(newRoom)
								newRoom.transform.position = support;
								if (rooms [0] != game) {
				
										Destroy (rooms [0]);
										rooms [0] = game;
										newRoom = MakeRoom (level, roomsGamesPositions [4]);
										porte = newRoom.transform.GetComponent<InfoPorte> ();
										startTime = 0.0f;
								}
				
				
								MoveObject (rooms [0].transform, rooms [0].transform.position, targetRoomPosition, 1);
								MoveObject (newRoom.transform, newRoom.transform.position, currentRoomPosition, 1);
								support = newRoom.transform.position;
								if (newRoom.transform.position == currentRoomPosition) {
					
										game = null;
										Destroy (rooms [0]);
										rooms [0] = newRoom;
										score++;
										Debug.Log (score);
					
										isMoving = false;
					
										newRoom = null;
										endedGame = false;
										
					
										timer.seconds=2;
										timer.StartTimer();
								}
						} else {		
				
							//Nulla=0, Button = 1 , Speed = 2, Enigmi = 3
								
								if (!isMoving && Input.GetKey ("1") && porte.containsChoice(1) || Input.GetButtonDown("X")){ //&& level != roomsToTop) {
										
										choice = 1;
										
								}
								if (!isMoving && Input.GetKey ("2") && porte.containsChoice(2) || Input.GetButtonDown("Y")) {
										
										choice = 2;
										
								}
								if (!isMoving && Input.GetKey ("3") && porte.containsChoice(3) || Input.GetButtonDown("B")) {// && level != -roomsToFloor) {
										
										choice = 3;
										
								}
				
								if (choice != 0) {
										
										
										if(game)
											game.transform.position=support;
											
										if (!isMoving) {
												
												porta = 0;
												if (porte.portaSu==choice){
													level += 1;
													porta=1;
												}
												else if (porte.portaDx==choice){
													porta=2;
												}else if (porte.portaGiu==choice){
													level -= 1;
													porta=3;
												}
					
												timer.StopTimer();
												game = MakeRoomGame (choice, roomsGamesPositions [porta]);
												startTime = 0.0f;
										}
					
										isMoving = true;
					
										MoveObject (rooms [0].transform, rooms [0].transform.position, targetRoomPosition, 1);
										MoveObject (game.transform, game.transform.position, currentRoomPosition, 1);
										support=game.transform.position;
		
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


