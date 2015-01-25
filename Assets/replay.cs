using UnityEngine;
using System.Collections;

public class replay : MonoBehaviour {

	
	void Update () {
		if(Input.GetButton("A"))
			Application.LoadLevel("Rooms");
	}
}
