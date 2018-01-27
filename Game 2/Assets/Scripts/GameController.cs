using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController {
    public static int score;   // The player's score
    
    // Add score by an amount
    public static void AddScore (int value)
    {
        score += value * Laser.combo;
    }

    // Reset the game
    public static void Reset ()
    {
        score = 0;
    }
}
