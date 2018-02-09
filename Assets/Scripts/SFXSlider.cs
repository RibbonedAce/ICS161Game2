using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SFXSlider : MonoBehaviour {
    private AudioController controller; // The audio controller to change
    private Slider _slider;             // The Slider component attached

    void Awake ()
    {
        _slider = GetComponent<Slider>();
    }

    // Use this for initialization
    void Start ()
    {
        controller = GameObject.Find("AudioController").GetComponent<AudioController>();
        _slider.onValueChanged.AddListener(delegate { controller.changeSfx(_slider.value); });
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
