using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class JumpEnemy : Enemy {
    public float JumpDelay;             // The time it takes before starting to jump
    private int canJump;                
    //public Vector2 Force;               // how far and high jumper can jump.

    protected override void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        health = maxHealth;
        canJump = 0;
        StartCoroutine(Jump());
    }
    // Update is called once per frame
    protected override void Update()
    {
        if (canJump == 0)
        {
            MoveForward();
        }
        else if(canJump == 1)
        {
            float xDir = 0.2f;
            float yDir = Random.Range(0.3f, 0.5f);
            Vector2 Force = new Vector2(xDir, yDir);
            _rigidbody2D.AddForce(Force,ForceMode2D.Impulse);
        }
        if (_rigidbody2D.position.y < -5)
        {
            PlayerController.instance.ChangeHealth(PlayerController.instance.health - 1);
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
