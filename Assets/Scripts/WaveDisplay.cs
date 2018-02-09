using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class WaveDisplay : MonoBehaviour {
    public string header;   // The header text to use before the wave
    private Text _text;     // The Text component attached

    void Awake ()
    {
        _text = GetComponent<Text>();
    }
	
    // Display text for a set time
    public IEnumerator DisplayText (string text, float time)
    {
        _text.text = header + text;
        yield return new WaitForSeconds(time);
        _text.text = "";
    }
}
