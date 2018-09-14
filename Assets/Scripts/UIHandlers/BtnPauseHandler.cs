using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnPauseHandler : MonoBehaviour
                             , IPointerDownHandler
                             , IPointerUpHandler
{

    private bool pause_down = false;
    private float pause_down_timer = 0.0f;


    public GameObject gameManager;
    public float pause_long_time  = 2.0f;
    public float pause_short_time = 0.5f;


    public void OnPointerDown(PointerEventData eventData)
    {
        pause_down = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (pause_down_timer < pause_short_time){
            ShortClicked();
        }
            
        Reset();
    }

	private void Reset()
	{
        pause_down = false;
        pause_down_timer = 0.0f;
        AudioListener.volume = 1.0f;
	}

    private void LongClicked() {
        gameManager.GetComponent<TouchHandler>().onPauseButtonLongClicked();
    }

    private void ShortClicked()
    {
        gameManager.GetComponent<TouchHandler>().onPauseButtonClicked();
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (pause_down) {

            pause_down_timer += Time.deltaTime;

            AudioListener.volume = 1.0f - (pause_down_timer / pause_long_time);

            if (pause_down_timer > pause_long_time) {
                LongClicked();
                Reset();
            }
        }
	}
}
