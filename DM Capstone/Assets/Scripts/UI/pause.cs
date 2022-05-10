using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    PlayerController controllerInput;
    PlayerController keyboardInput;
    PlayerController menuInput;

    public Image StartSelector;
    public Image QuitSelector;

    public bool gamePaused = false;
    int state = 0;
    int pointer = 0;

    GameObject scripts;
    //public Image pauseUI;
    public GameObject[] pauseUI;
    public AudioSource levelMusic;

    // Start is called before the first frame update
    void Start()
    {
        scripts = GameObject.Find("Player");
        pauseUI = GameObject.FindGameObjectsWithTag("PauseMenuUI");
        
        for(int i = 0; i < pauseUI.Length; i++)
        {
            pauseUI[i].SetActive(false);
        }

        controllerInput = new PlayerController();
        controllerInput.Gameplay.Enable();

        keyboardInput = new PlayerController();
        keyboardInput.Keyboard.Enable();

        menuInput = new PlayerController();
        StartSelector.enabled = false;
        QuitSelector.enabled = false;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        ResumeGame();
        controls();
    }

    void LateUpdate()
    {
        checkGameState();
    }

    void PauseGame()
    {
        if(controllerInput.Gameplay.Pause.WasPressedThisFrame() && gamePaused == false)
        {
            pauseStuff();
        }

        if(keyboardInput.Keyboard.Pause.WasPressedThisFrame() && gamePaused == false)
        {
            pauseStuff();
        }
    }

    void ResumeGame()
    {
        if(controllerInput.Gameplay.Pause.WasPressedThisFrame() && gamePaused == true)
        {
            resumeStuff();
        }

        if(keyboardInput.Keyboard.Pause.WasPressedThisFrame() && gamePaused == true)
        {
            resumeStuff();
        }
    }

    void checkGameState()
    {
        if (state == 1)
            gamePaused = true;
        else if(state == 0)
            gamePaused = false;
    }

    public void controls()
    {
        if(menuInput.Menu.MenuRight.WasPressedThisFrame() && pointer == 0)
        {
            //print("DPAD Right");
            StartSelector.enabled = false;
            QuitSelector.enabled = true;
            pointer = 1;
        }

        if(menuInput.Menu.MenuLeft.WasPressedThisFrame() && pointer == 1)
        {
            //print("DPAD Left");
            StartSelector.enabled = true;
            QuitSelector.enabled = false;
            pointer = 0;
        }

        if(menuInput.Menu.Action.WasPressedThisFrame() && pointer == 0)
        {
            resumeStuff();
        }

        if(menuInput.Menu.Action.WasPressedThisFrame() && pointer == 1)
            SceneManager.LoadScene("Main Menu");
    }

    public void pauseStuff()
    {
        //print("Pause Button recongnized - PAUSED");
        Time.timeScale = 0;
        state = 1;

        scripts.GetComponent<controllerControls>().enabled = false;
        scripts.GetComponent<keyboardControls>().enabled = false;

        menuInput.Menu.Enable();
        StartSelector.enabled = true;
        QuitSelector.enabled = false;

        for(int i = 0; i < pauseUI.Length; i++)
        {
            pauseUI[i].SetActive(true);
        }

        levelMusic.Pause();
    }

    public void resumeStuff()
    {
        //print("DPAD Menu Button recongnized - ENABLED");
        Time.timeScale = 1;
        state = 0;

        scripts.GetComponent<controllerControls>().enabled = true;
        scripts.GetComponent<keyboardControls>().enabled = true;

        menuInput.Menu.Disable();
            
        for(int i = 0; i < pauseUI.Length; i++)
        {
            pauseUI[i].SetActive(false);
        }

        levelMusic.Play();
    }
}