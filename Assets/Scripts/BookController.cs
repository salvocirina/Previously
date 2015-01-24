using UnityEngine;
using System.Collections;

public class BookController : MonoBehaviour {

	private int correctIndex;
	public int MaxIndex = 4;
	public GameObject winLabel;
	public bool[] step;
	private int i;
	// Use this for initialization
	void Start () {
		correctIndex = 0;
		i = 0;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (correctIndex);
		if (Input.GetButtonDown ("A") && !step [0]) {
			step [1] = true;
			i++;
		} else if (Input.GetButtonDown ("Y") &&  step [1]) {
			step [2] = true;
			i++;
		} else if (Input.GetButtonDown ("B") && step [2]) {
			step [3] = true;
			i++;
		} else  if (Input.GetButtonDown ("X") && step [3]) {
			step [4] = true;
			i++;
		} else if (step [4])
			winLabel.SetActive (true);
	}
}
