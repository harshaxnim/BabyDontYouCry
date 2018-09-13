using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Focus : MonoBehaviour 
                   , IPointerUpHandler
                   , IPointerDownHandler {


    public Animator Camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerUp(PointerEventData eventData) {

        // set trigger for the camera to transition to focus mode from inGame mode
        Camera.SetBool("startFocus", true);

        print("im up!!!");
    }

    public void OnPointerDown(PointerEventData eventData) {
  
        // set trigger for the camera to transition from focus mode to inGame mode
		Camera.SetBool("stopFocus", true);

        print("im down!!!");
    }
}
