using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MenuController {
    private bool paused = false;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
}
