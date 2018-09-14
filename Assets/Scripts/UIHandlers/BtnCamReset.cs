using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnCamReset : MonoBehaviour 
                         , IPointerDownHandler
                         , IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MyGameState.camera_reset = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
		MyGameState.camera_reset = false;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
