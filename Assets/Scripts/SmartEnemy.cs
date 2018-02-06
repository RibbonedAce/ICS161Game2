using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SmartEnemy : Enemy {
    public float range;         // How close to be before avoiding
    private Transform toAvoid;   // The laser to avoid

    protected override void Awake ()
    {
        base.Awake();
        toAvoid = GameObject.Find("Laser").transform;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
        Vector2 dif = toAvoid.position - transform.position;
        if (dif.magnitude <= range)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position - dif * speed * Time.deltaTime);
        }
	}
}
