using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject main;
    public GameObject instructions;
    public GameObject settings;
    public GameObject credits;

    void Awake ()
    {
        ChangeMenu((int)MenuState.Main);
    }

    // Start the game
    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }

    // Quit the game
    public void QuitGame ()
    {
        Application.Quit();
    }

    // Change the menu UI in-game
    public void ChangeMenu (int newState)
    {
        main.SetActive((MenuState)newState == MenuState.Main);
        instructions.SetActive((MenuState)newState == MenuState.Instructions);
        settings.SetActive((MenuState)newState == MenuState.Settings);
        credits.SetActive((MenuState)newState == MenuState.Credits);
    }
}

public enum MenuState
{
    Main,
    Instructions,
    Settings,
    Credits
}