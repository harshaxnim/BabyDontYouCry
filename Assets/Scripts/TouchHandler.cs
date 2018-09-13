using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour {


    public Button m_mainStartButton;
    public Button m_pauseButton;
    public Camera m_characterCamera;
    public GameObject m_character;
    public GameObject m_animalSpawner;

    public GameObject m_menuCanvas;
    public GameObject m_inGameCanvas;

    public Animator cameraAnimator;
    public Animator starsAnimator;

    //private bool inGame;


    public float slowDownOnPause = 0.1f;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        m_inGameCanvas.SetActive(false);

        m_mainStartButton = m_mainStartButton.GetComponent<Button>();
        m_pauseButton = m_pauseButton.GetComponent<Button>();

        m_mainStartButton.onClick.AddListener(onMainStartButtonClicked);
        m_pauseButton.onClick.AddListener(onPauseButtonClicked);

    }
    
    void onMainStartButtonClicked(){
        // Disable Canvas
        m_menuCanvas.SetActive(false);
		m_inGameCanvas.SetActive(true);

        // get the menu camera to the game camera

        cameraAnimator.SetBool("GoToGame", true);
        starsAnimator.SetFloat("SpeedMultiplier", 0.05f);
        // start the script for gyro and mouse inp
        //m_characterCamera.GetComponent<control>().enabled = true;
        //m_characterCamera.GetComponent<Gyro>().enabled = true;
        m_character.GetComponent<Gyro>().enabled = true;

        // spawn animals
        m_animalSpawner.SetActive(true);

        //inGame = true;
    }

    void onPauseButtonClicked(){

        var allAudioSources = FindObjectsOfType<AudioSource>();

        paused = !paused;

        if (paused)
        {
            Time.timeScale *= slowDownOnPause;
            for (int i = 0; i < allAudioSources.Length; i++)
            {
                allAudioSources[i].pitch *= slowDownOnPause;
            }
        }
        else
        {
            Time.timeScale = 1;
            for (int i = 0; i < allAudioSources.Length; i++)
            {
                allAudioSources[i].pitch = 1;
            }
        }
    }

	void Update()
	{

	}
}
