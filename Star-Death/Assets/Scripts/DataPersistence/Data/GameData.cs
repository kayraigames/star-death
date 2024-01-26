using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Add fields that need to be saved
    public int clickCount;

    // Field initial values on new save game creation.
    public GameData()
    {
        clickCount = 0;
    }
}
