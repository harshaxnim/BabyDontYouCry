using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CameraAnimator : MonoBehaviour {

    private bool focus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (focus) {
            Debug.Log("focussing");
        }
	}

    public void setFocus(bool status) {
        focus = status;
    }

}
