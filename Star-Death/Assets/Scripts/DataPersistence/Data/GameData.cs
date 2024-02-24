using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Add fields that need to be saved
    public long lastUpdated;
    public int clickCount;
    public string profileID;

    // Field initial values on new save game creation.
    public GameData(string profileID)
    {
        clickCount = 0;
        this.profileID = profileID;
    }
}
