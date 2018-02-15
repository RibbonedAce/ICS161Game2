using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {
    public static ClickTrail trail;     // The clicktrail to use
    private static Camera cam;          // The camera to use for space conversion
    private static Transform canvas;    // The canvas to spawn the after-effect on
    public int maxHealth;               // The starting health of the enemy
    protected int health;               // The current health of the enemy
    public float speed;                 // The speed the enemy moves at
    private float maxSpeed;
    public GameObject postEffect;       // The post-death effect to use
    public GameObject textEffect;       // The UI-based effect to use
    protected Rigidbody2D _rigidbody2D; // The Rigidbody component attached

    protected virtual void Awake ()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        health = maxHealth;
        maxSpeed = 6.0f;
    }

    // Use this for initialization
    void Start ()
    {
        if (cam == null)
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas").transform;
        }
		if (trail == null)
        {
            trail = GameObject.Find("Trail").GetComponent<ClickTrail>();
        }
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        MoveDown();
        if (_rigidbody2D.position.y < -5)
        {
            PlayerController.instance.ChangeHealth(PlayerController.instance.health - 1);
            Destroy(gameObject);
        }
	}

    // When the collider hits a trigger
    protected void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        { 
            trail.UpdateTime(trail.drawTime + trail.maxDrawTime * 0.05f * (++Laser.combo - 1));
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
            Die();
        }
    }

    // Die and spawn a posteffect
    public void Die ()
    {
        AudioSource a = Instantiate(postEffect, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        a.pitch = 20f / (20 - Mathf.Max(Laser.combo, 10));
        Instantiate(textEffect, cam.WorldToScreenPoint(transform.position), Quaternion.identity, canvas);
        Destroy(gameObject);
    }

    private void MoveDown()
    {
        Vector2 velocity = new Vector2(0.0f, -1.0f);
        speed = Random.Range(speed, maxSpeed);
        _rigidbody2D.MovePosition(_rigidbody2D.position + velocity * speed * Time.deltaTime);
    }
}
