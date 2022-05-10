using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Forest;
    int pointer;

    public Image StartSelector;
    public Image QuitSelector;

    PlayerController controllerInput;

    // Start is called before the first frame update
    void Start()
    {
        controllerInput = new PlayerController();
        controllerInput.Menu.Enable();

        StartSelector.enabled = true;
        QuitSelector.enabled = false;
        pointer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        controls();
    }

    public void controls()
    {
        if(controllerInput.Menu.MenuDown.WasPressedThisFrame() && pointer == 0)
        {
            //print("DPAD Down");
            StartSelector.enabled = false;
            QuitSelector.enabled = true;
            pointer = 1;
        }

        if(controllerInput.Menu.MenuUp.WasPressedThisFrame() && pointer == 1)
        {
            //print("DPAD Up");
            StartSelector.enabled = true;
            QuitSelector.enabled = false;
            pointer = 0;
        }

        if(controllerInput.Menu.Action.WasPressedThisFrame() && pointer == 0)
            SceneManager.LoadScene(Forest);

        if(controllerInput.Menu.Action.WasPressedThisFrame() && pointer == 1)
            Application.Quit();
    }
}
