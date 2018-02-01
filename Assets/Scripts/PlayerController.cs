using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public static PlayerController instance;    // The instance to reference
    public Slider slider;                       // Health bar
    public int health;                          // The player's current health
    public int maxHealth;                       // The player's maximum health

    void Awake ()
    {
        instance = this;
        ChangeHealth(maxHealth);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeHealth (int value)
    {
        health = Mathf.Min(value, maxHealth);
        slider.value = (float)health / maxHealth;
        if (health <= 0)
        {
            GameController.instance.LoseGame();
        }
    }
}
