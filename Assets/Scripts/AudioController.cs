using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public float musicVolume;   // The volume of music in the game
    public float sfxVolume;     // The volume of sound effects in the game

    void Awake ()
    {
        musicVolume = 1;
        sfxVolume = 1;
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    // Change the music volume
    public void changeMusic (float value)
    {
        musicVolume = value;
        foreach (MusicVolume mv in FindObjectsOfType<MusicVolume>())
        {
            mv.ChangeVolume(musicVolume);
        }
    }

    // Change the sfx volume
    public void changeSfx(float value)
    {
        sfxVolume = value;
        foreach (SFXVolume sv in FindObjectsOfType<SFXVolume>())
        {
            sv.ChangeVolume(sfxVolume);
        }
    }
}
