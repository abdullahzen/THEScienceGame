using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
	#region Fields

    [Header("Buttons")]
    public Button startGame;
    public Button quit;
    public Button options;

    [SerializeField]
    public GameObject mainMenuCanvas;

    [SerializeField]
    public GameObject menuPanel;

    [SerializeField]
    public GameObject optionsPanel;

    // statics
    static GameManager gm;
    public static int state = 0; // 0 = main menu, 1 = in game, 2 = game over

	#endregion

	#region Engine Events

    private void Awake()
    {
        // if (resumeGame != null) { resumeGame.gameObject.SetActive(false); }   --> No Pause button for now

        gm = this;
        Time.timeScale = 1;

        if (startGame == null)
        {
            StartGame();
        }
    }

    private void Update()
    {
        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //if (resumeGame != null && !mainMenuCanvas.activeSelf)   --> No Pause button for now
                if (!mainMenuCanvas.activeSelf)
                {
                    // resumeGame.gameObject.SetActive(true);       --> No Pause button for now
                    mainMenuCanvas.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }

                if (quit != null)
                {
                    quit.gameObject.SetActive(true);
                }
            }
        }
    }

	#endregion

	// #region Methods
	// #endregion

	#region UI Callbacks

    // TODO: Start the game and connect to the Lobby scene
    public void StartGame()
    {
        state = 1;
        if (startGame != null)
        {
            startGame.gameObject.SetActive(false);
            options.gameObject.SetActive(false);
            mainMenuCanvas.gameObject.SetActive(false);
        }            
    }

    // public void ResumeGame()
    // {
    //     if (resumeGame != null)
    //     {
    //         resumeGame.gameObject.SetActive(false);
    //         mainMenuCanvas.gameObject.SetActive(false);
    //     }

    //     Time.timeScale = 1;
    // }

    // Goes to the options panel 
    public void Options(){
        optionsPanel.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
    }

    // Goes back to main menu
    public void OptionsBack(){
        optionsPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	#endregion
}