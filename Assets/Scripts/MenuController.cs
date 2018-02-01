using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public static MenuController instance;  // The instance to reference
    public List<GameObject> menuItems;      // The list of menu items to track
    public int startState;                  // The starting state of the menu

    void Awake ()
    {
        instance = this;
        ChangeMenu(startState);
    }

    // Update is called once per frame
    void Update ()
    {
        
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

    // Change the menu UI in-game
    public void ChangeMenu (int newState)
    {
        for (int i = 0; i < menuItems.Count; ++i)
        {
            menuItems[i].SetActive(i == newState);
        }
    }
}