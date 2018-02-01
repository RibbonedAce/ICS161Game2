using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MenuController {
    private bool paused = false;    // Whether the game is paused or not
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameController.instance.playing)
        {
            ChangePause();
        }
    }

    // Pauses or unpauses the game
    public void ChangePause ()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        ChangeMenu(paused ? 0 : -1);
    }
}
