using UnityEngine;
using System.Collections;

public class RoomTimer : MonoBehaviour {
	
	
	public float seconds = 10.0f;
	
	
	private float timer = 0.0f;
	private float delta = 0.0f;
	//private float p=0.0f;
	private bool started;
	private bool primo = false;
	private bool secondo = false;
	private bool terzo = false;
	
	public AudioClip tok;
	public AudioClip toktok;
	public AudioClip toktoktok;
	
	
	public void StartTimer () {
	//void Start () {
		
		
		delta = seconds/24.0f;		
		
		//p = delta / audio.pitch;
		
		//Debug.Log(p);
		//audio.pitch = Mathf.Clamp( p, 0.02f, 1.0f);
		started=true;
		//Debug.Log ("parte...");
		
		timer=0.0f;
		primo = false;
		secondo = false;
		terzo = false;
		
	}
	
	public void StopTimer () {
		
		started=false;
		
	}
	
	
	void Update () {
		
		//Debug.Log("fuori");
		if(started){
			//Debug.Log("dentro");	
			timer+=Time.deltaTime;
			
			if(timer > seconds && !audio.isPlaying){
				
				StopTimer();
				audio.volume=1.0f;
				audio.Play();
				started=false;
				
				//MORTE
				
			}else if(timer >= delta*18 && !audio.isPlaying && !terzo){
				audio.volume=0.9f;
				terzo=true;
				//audio.pitch=Mathf.Clamp( p/3.0f , 0.02f, 1.0f);
				audio.PlayOneShot(toktoktok);
			}
			else if(timer >= delta*7 && !audio.isPlaying && !secondo){
				audio.volume=0.7f;
				secondo=true;
				//audio.pitch=Mathf.Clamp( p/2.0f , 0.02f, 1.0f);
				audio.PlayOneShot(toktok);
			}
			else if(timer >= delta*1 && !audio.isPlaying && !primo){
				audio.volume=0.5f;
				primo=true;
				audio.PlayOneShot(tok);
			}
			

		}
	}
}