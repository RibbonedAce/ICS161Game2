using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicVolume : MonoBehaviour {
    private AudioController controller; // The audio controller to get volume from
    private AudioSource _audioSource;   // The Audio Source component attached

    void Awake ()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {
        controller = GameObject.Find("AudioController").GetComponent<AudioController>();
        ChangeVolume(controller.musicVolume);
    }

    // Update is called once per frame
    void Update ()
    {

    }

    // Change the volume of the source
    public void ChangeVolume (float value)
    {
        _audioSource.volume = value;
    }
}
