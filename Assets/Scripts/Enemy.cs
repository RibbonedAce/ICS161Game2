using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {
    public int maxHealth;               // The starting health of the enemy
    private int health;                 // The current health of the enemy
    public float speed;                 // The speed the enemy moves at
    private Rigidbody2D _rigidbody2D;   // The Rigidbody component attached

    void Awake ()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveDown();
        if (_rigidbody2D.position.y < -5)
        {
            PlayerController.instance.ChangeHealth(PlayerController.instance.health - 1);
            Destroy(gameObject);
        }
	}

    // When the collider hits a trigger
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            ++Laser.combo;
            GameController.instance.AddScore(100);
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

    private void MoveDown()
    {
        Vector2 velocity = new Vector2(0.0f, -1.0f);
        _rigidbody2D.MovePosition(_rigidbody2D.position + velocity * speed * Time.deltaTime);
    }
}
