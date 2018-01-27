using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities {

	// Finds the angle of a vector2 relative to positive x in degrees
    public static float FindAngle (Vector2 vec)
    {
        if (vec.x == 0 && vec.y == 0)
        {
            return 0;
        }
        else
        {
            if (vec.x >= 0)
            {
                return Mathf.Rad2Deg * Mathf.Asin(vec.y / vec.magnitude);
            }
            else if (vec.y >= 0)
            {
                return Mathf.Rad2Deg * Mathf.Acos(vec.x / vec.magnitude);
            }
            else
            {
                return 180 - Mathf.Rad2Deg * Mathf.Asin(vec.y / vec.magnitude);
            }
        }
    }
}
