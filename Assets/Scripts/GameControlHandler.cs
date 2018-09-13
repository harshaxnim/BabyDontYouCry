using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControlHandler : MonoBehaviour
                                , IPointerClickHandler {

	// Use this for initialization
	void Start () {
        //var b = GetComponent<Button>();
        //Debug.Log(b);
        //b.onClick.AddListener(onGameControllerClicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onGameControllerClicked() {
        Debug.Log("LOL, at last! >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
    }

    public void OnPointerClick(PointerEventData data) {
        print("I was clicked");
        //target = Color.blue;
    }


}
