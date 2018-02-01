using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverCamera : MonoBehaviour {
    public Camera toCover;                  // The camera view to cover
    public float depth;                     // The depth to set the GameObject at
    private SpriteRenderer _spriteRenderer; // The Sprite Renderer component attached

    void Awake ()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Use this for initialization
    void Start ()
    {
        transform.position = toCover.transform.position + new Vector3(0, 0, depth);
        float yScale = toCover.orthographicSize / _spriteRenderer.bounds.extents.y;
        float xScale = toCover.orthographicSize * 16 / 9 / _spriteRenderer.bounds.extents.x;
        transform.localScale = new Vector3(xScale * transform.localScale.x, yScale * transform.localScale.y, 1);
    }

    // Update is called once per frame
    void Update ()
    {
        
	}
}
