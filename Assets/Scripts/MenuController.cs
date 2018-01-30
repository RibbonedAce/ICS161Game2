using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public List<GameObject> menuItems;
    public int startState;
    private bool paused = false;

    void Awake ()
    {
        ChangeMenu(startState);
    }

    // Update is called once per frame
    void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    // Start the game
    public void StartGame ()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    // Returns to the main menu
    public void EndGame ()
    {
        SceneManager.LoadScene(0);
    }

    // Quit the game
    public void QuitGame ()
    {
        Application.Quit();
    }

    // Pauses the game
    public void PauseGame ()
    {
        paused = true;
        Time.timeScale = 0;
        ChangeMenu(0);
    }

    // Unpauses the game
    public void ResumeGame ()
    {
        paused = false;
        Time.timeScale = 1;
        ChangeMenu(-1);
    }

    // Change the menu UI in-game
    public void ChangeMenu (int newState)
    {
        for (int i = 0; i < menuItems.Count; ++i)
        {
            menuItems[i].SetActive(i == newState);
        }
    }
}