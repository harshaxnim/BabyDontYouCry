using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class MyGameState
{
    public static bool in_menu = false;
    public static bool in_game = false;

    public static bool camera_reset = false;

    public static bool paused = false;

    public static float slowDownOnPause = 0.1f;
}

public class GameInitiator : MonoBehaviour {

	public GameObject sun;

	// Use this for initialization
	void Start () {
		
		sun = GameObject.Find ("Sun");
		sun.SetActive (false);

		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}