using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : TextDisplay {

	// Update is called once per frame
	protected override void Update ()
    {
        _text.text = string.Format("{0}{1:00000}", identifier, GameController.instance.score);
	}
}
