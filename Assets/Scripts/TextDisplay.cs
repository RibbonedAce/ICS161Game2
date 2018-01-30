using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour {
    public string identifier;   // The text preceeding the value
    protected Text _text;       // The Text component on gameObject

    // Use this for initialization
    void Awake ()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    protected virtual void Update ()
    {
        _text.text = identifier;
    }
}
