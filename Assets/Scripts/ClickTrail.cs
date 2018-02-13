using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TrailRenderer))]
//[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(Rigidbody2D))]
public class ClickTrail : MonoBehaviour {
    public static Camera cam;                               // Cam to reference for mouse pos
    public List<Vector2> path;                              // The path the trail takes
    public float maxDrawTime;                               // The max amount of time to draw
    public AudioSource audioSource;                         // The Audio Source to use for charging
    public AudioClip chargeClip;                            // The Audio Clip to use for charging
    public AudioClip targetClip;                            // The Audio Clip to use for targeting
    public Slider drawSlider;                               // The slider for the amount of draw left
    private Laser laser;                                    // The laser to use for hitting enemies
    private Beam beam;                                      // The beam to use for effects
    private float drawTime;                                 // The amount of time to draw left
    private float lastDrawTime;                             // The last recorded amount of draw time
    private TrailRenderer _trailRenderer;                   // The Trail Renderer component attached
    //private ParticleSystem.EmissionModule _emissionModule;  // The Emission Module attached to the Particle System
    private Rigidbody2D _rigidbody2D;                       // The Rigidbody 2D component attached
    private bool drawing;                                   // True if mouse pressed while drawTime > 0

    void Awake()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        laser = GameObject.Find("Laser").GetComponent<Laser>();
        beam = GameObject.Find("Beam").GetComponent<Beam>();
        _trailRenderer = GetComponent<TrailRenderer>();
        //_emissionModule = GetComponent<ParticleSystem>().emission;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CanDraw() && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ResetTrail());
            drawing = true;
        }
        else if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0) || drawTime <= 0)
        {
            drawing = false;
        }
        if (drawing)
        {
            UpdateTime(Mathf.Max(drawTime - Time.deltaTime, 0));
        }
        else if (!laser.isRunning)
        {
            UpdateTime(Mathf.Min(drawTime + maxDrawTime * Time.deltaTime / 6, maxDrawTime));
        }
        _trailRenderer.enabled = drawing;
        //_emissionModule.enabled = drawing;
        if (lastDrawTime != drawTime)
        {
            if (lastDrawTime < drawTime)
            {
                audioSource.clip = chargeClip;
            }
            else if (lastDrawTime > drawTime)
            {
                audioSource.clip = targetClip;
            }
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        lastDrawTime = drawTime;
    }

    void FixedUpdate ()
    {
        _rigidbody2D.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));
        if (drawing)
        {
            path.Add(_rigidbody2D.position);
        }
        else if (path.Count > 0 && !drawing)
        {
            StartCoroutine(laser.TravelOnScreen(new List<Vector2>(path)));
            StartCoroutine(beam.TravelBeam(new List<Vector2>(path)));
            path.Clear();
        }
    }

    // Update the draw time and the slider
    private void UpdateTime (float newTime)
    {
        drawTime = newTime;
        drawSlider.value = drawTime / maxDrawTime;
        audioSource.pitch = 3 * drawTime / maxDrawTime;
    }

    // Returns true if the player is able to draw
    private bool CanDraw ()
    {
        return drawTime > 0 && !laser.isRunning;
    }

    // Reset the trail
    private IEnumerator ResetTrail ()
    {
        float temp = _trailRenderer.time;
        _trailRenderer.time = 0;
        yield return new WaitForEndOfFrame();
        _trailRenderer.time = temp;
    }
}
