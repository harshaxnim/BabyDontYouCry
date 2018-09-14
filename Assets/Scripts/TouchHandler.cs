using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour {


    public Button m_mainStartButton;
    public Button m_pauseButton;
    public Button m_camerResetButton;

    public Camera m_characterCamera;

    public GameObject m_character;
    public GameObject m_animalSpawner;

    public GameObject m_menuCanvas;
    public GameObject m_inGameCanvas;

    public Animator cameraAnimator;
    public Animator starsAnimator;

    public StateMachineBehaviour m_stateMenu;


    public float slowDownOnPause = 0.1f;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        m_inGameCanvas.SetActive(false);

        m_mainStartButton = m_mainStartButton.GetComponent<Button>();
        m_pauseButton = m_pauseButton.GetComponent<Button>();
        m_camerResetButton = m_camerResetButton.GetComponent<Button>();


        m_mainStartButton.onClick.AddListener(onMainStartButtonClicked);
        m_camerResetButton.onClick.AddListener(onCameraResetButtonClicked);

        //m_stateMenu = cameraAnimator;

    }

    void onCameraResetButtonClicked(){
        
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

    public void onPauseButtonClicked(){

        if (MyGameState.in_game) {

            var allAudioSources = FindObjectsOfType<AudioSource>();

            paused = !paused;

            if (paused)
            {
                // slow animations
                Time.timeScale *= slowDownOnPause;
                // slow audio
                for (int i = 0; i < allAudioSources.Length; i++)
                {
                    allAudioSources[i].pitch *= slowDownOnPause;
                }
                // pause input
                m_character.GetComponent<Gyro>().enabled = false;

            }
            else
            {
                Time.timeScale = 1;
                for (int i = 0; i < allAudioSources.Length; i++)
                {
                    allAudioSources[i].pitch = 1;
                }
                m_character.GetComponent<Gyro>().enabled = true;
            }
        }

    }

    public void onPauseButtonLongClicked(){
        // Opposite of coming out of menu to game

        // enable Canvas

        // get the menu camera to the game camera

        cameraAnimator.SetBool("GoToMenu", true);
        starsAnimator.SetFloat("SpeedMultiplier", 1.0f);
        // start the script for gyro and mouse inp
        //m_characterCamera.GetComponent<control>().enabled = true;
        //m_characterCamera.GetComponent<Gyro>().enabled = true;
        m_character.GetComponent<Gyro>().enabled = false;

        // spawn animals
        m_animalSpawner.SetActive(false);

		m_inGameCanvas.SetActive(false);
		m_menuCanvas.SetActive(true);
    }

	void Update()
	{

	}
}
