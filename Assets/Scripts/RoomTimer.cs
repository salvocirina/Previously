using UnityEngine;
using System.Collections;

public class RoomTimer : MonoBehaviour {


	public float seconds = 10.0f;
	
	//public AudioSource tocktock;
	private float timer = 0.0f;
	private float delta = 0.0f;
	private float p=0.0f;
	private bool started;
	private int primo = 0;
	private int secondo = 0;
	private int terzo = 0;
	
	//void StartTimer () {
	void Start () {
		
		//toktok=audio;
		
		delta = seconds/24.0f;		
		
		p = delta / audio.pitch;
		 
		Debug.Log(p);
		audio.pitch = Mathf.Clamp( p, 0.02f, 1.0f);
		started=true;
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(started){
			
			timer+=Time.deltaTime;
			
			if(timer >= delta*18 && !audio.isPlaying && terzo<3){
				terzo++;
				//audio.pitch=Mathf.Clamp( p/3.0f , 0.02f, 1.0f);
				audio.Play();
			}
			else if(timer >= delta*7 && !audio.isPlaying && secondo<2){
				secondo++;
				//audio.pitch=Mathf.Clamp( p/2.0f , 0.02f, 1.0f);
				audio.Play();
			}
			else if(timer >= delta*2 && !audio.isPlaying && primo<1){
				primo ++;
				audio.Play();
			}
			
			
			
			
			
			
		}
	}
}
