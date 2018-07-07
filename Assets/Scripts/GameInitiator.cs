using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitiator : MonoBehaviour {

	public GameObject sun;

	// Use this for initialization
	void Start () {
		
		sun = GameObject.Find ("Sun");
		sun.SetActive (false);

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
