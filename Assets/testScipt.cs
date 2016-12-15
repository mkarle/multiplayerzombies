using UnityEngine;
using System.Collections;

public class testScipt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Xbox360_A")) {
			Debug.Log ("XBOX 360 A BUTTON PRESSED");
		}
	}
}
