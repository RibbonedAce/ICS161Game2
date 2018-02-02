﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class JumpEnemy : MonoBehaviour {
    public int maxHealth;               // The starting health of the enemy
    private int health;                 // The current health of the enemy
    public float speed;                 // The speed the enemy moves at
    private Rigidbody2D _rigidbody2D;   // The Rigidbody component attached
    public float JumpDelay;
    private int canJump;
    public Vector2 Force;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        health = maxHealth;
        canJump = 0;
        StartCoroutine(Jump());
    }
    // Update is called once per frame
    void Update()
    {
        print(canJump);
        if (canJump == 0)
        {
            MoveForward();
        }
        else if(canJump == 1)
        {
            _rigidbody2D.AddForce(Force,ForceMode2D.Impulse);
        }
        if (_rigidbody2D.position.y < -5)
        {
            PlayerController.instance.ChangeHealth(PlayerController.instance.health - 1);
            Destroy(gameObject);
        }
    }

    // When the collider hits a trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            ++Laser.combo;
            GameController.instance.AddScore(100);
            ChangeHealth(-1);
        }
    }

    // Have the enemy change its health
    public void ChangeHealth(int delta)
    {
        health += delta;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void MoveForward()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + new Vector2(1.0f,0.2f) * speed * Time.deltaTime);
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(JumpDelay);
        canJump = 1;
        yield return new WaitForSeconds(0.5f);
        canJump = 2;
    }
    
}
