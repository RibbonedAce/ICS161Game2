using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;  // The instance to reference
    public int score;                       // The player's score
    public bool playing = true;             // Whether the player is playing or not

    void Awake ()
    {
        instance = this;
    }

    // Add score by an amount
    public void AddScore (int value)
    {
        score += value * Laser.combo;
    }

    // Reset the game
    public void Reset ()
    {
        score = 0;
        playing = true;
        PlayerController.instance.health = PlayerController.instance.maxHealth;
    }

    // Win the game
    public void WinGame ()
    {
        playing = false;
        Time.timeScale = 0;
        MenuController.instance.ChangeMenu(2);
    }

    // Lose the game
    public void LoseGame ()
    {
        playing = false;
        Time.timeScale = 0;
        MenuController.instance.ChangeMenu(3);
    }
}
