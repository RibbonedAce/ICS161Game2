using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Laser : MonoBehaviour {
    public static int combo;                                // The combo counter
    public bool isRunning;                                  // Whether the coroutine is running
    private Rigidbody2D _rigidbody2D;                       // The Rigidbody component attached
    private ParticleSystem.EmissionModule _emissionModule;  // The Emission module of the Particle System
    private CapsuleCollider2D _collider;                    // The Capsule Collider component attached
    private AudioSource audio;

    void Awake ()
    {
        audio = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _emissionModule = GetComponent<ParticleSystem>().emission;
        _collider = GetComponent<CapsuleCollider2D>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    // Go around the screen using every other coordinate
    public IEnumerator TravelOnScreen (List<Vector2> path)
    {
        isRunning = true;
        combo = 0;
        Vector2 lastPos = new Vector2(0, 0);
        Vector2 lastPos2 = new Vector2(0, 0);
        audio.Play();
        for (int i = 0; i < path.Count; i += 2)
        {
            _rigidbody2D.MovePosition(path[i]);
            if (i > 2)
            {
                Vector2 dif = lastPos - lastPos2;
                _collider.offset = new Vector2(dif.magnitude / -2, 0);
                _collider.size = new Vector2(dif.magnitude + 1, 1);
                _rigidbody2D.MoveRotation(Utilities.FindAngle(path[i] - lastPos));
            }
            if (i > 0)
            {
                yield return new WaitForFixedUpdate();
                _emissionModule.enabled = true;
            }
            lastPos2 = lastPos;
            lastPos = path[i];
        }
        _emissionModule.enabled = false;
        _rigidbody2D.MovePosition(new Vector2(10, 6));
        _collider.size = Vector2.one;
        isRunning = false;
    }
}
