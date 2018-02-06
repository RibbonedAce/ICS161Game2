using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {
    public static PlayerController instance;    // The instance to reference
    public Slider slider;                       // Health bar
    public int health;                          // The player's current health
    public int maxHealth;                       // The player's maximum health
    private AudioSource _audioSource;           // The Audio Source component attached

    void Awake ()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
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
        if (value < health)
        {
            _audioSource.Play();
        }
        health = Mathf.Min(value, maxHealth);
        slider.value = (float)health / maxHealth;
        if (health <= 0)
        {
            GameController.instance.LoseGame();
        }
    }
}
