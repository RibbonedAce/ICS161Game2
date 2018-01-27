using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour {
    public int maxHealth;
    private int health;

    void Awake ()
    {
        health = maxHealth;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // When the collider hits a trigger
    void OnTriggerEnter2D (Collider2D collision)
    {
        ++Laser.combo;
        GameController.AddScore(100);
        if (collision.CompareTag("Mouse"))
        {
            ChangeHealth(-1);
        }
    }

    // Have the enemy change its health
    public void ChangeHealth (int delta)
    {
        health += delta;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
