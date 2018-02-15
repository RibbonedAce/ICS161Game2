using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ComboDisplay : MonoBehaviour {
    private Text _text; // The Text component attached

    void Awake ()
    {
        Destroy(gameObject, 1);
        _text = GetComponent<Text>();
        if (Laser.combo > 1)
        {
            _text.text = string.Format("{0} combo", Laser.combo);
            _text.fontSize = 14 + 2 * Laser.combo;
        }
    }
}
