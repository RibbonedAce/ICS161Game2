using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Beam : MonoBehaviour {
    public Vector2 anchorPos;               // The set position for the base of the laser
    //private ParticleSystem _particleSystem;
    private SpriteRenderer _spriteRenderer; // The Sprite Renderer component attached

    void Awake ()
    {
        //_particleSystem = GetComponent<ParticleSystem>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Aims and fires the beams at these locations
    public IEnumerator TravelBeam (List<Vector2> path)
    {
        _spriteRenderer.enabled = true;
        for (int i = 0; i < path.Count; i += 2)
        {
            transform.position = Vector2.Lerp(anchorPos, path[i], 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.up, path[i] - anchorPos));
            _spriteRenderer.size = new Vector2(1, (anchorPos - path[i]).magnitude);
            yield return new WaitForFixedUpdate();
        }
        _spriteRenderer.enabled = false;
    }
}
