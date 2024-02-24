using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTest : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int count;
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        count = 0;
    }
    private void Update()
    {
        text.text = count.ToString();
    }

    public void OnClick()
    {
        Debug.Log($"Current number of clicks: {count}.\n");
        count++;
        Debug.Log($"New number of clicks: {count}.\n");
    }

    public void LoadData(GameData data)
    {
        count = data.clickCount;
        Debug.Log($"Loaded {data.clickCount} clicks.\n");
    }

    public void SaveData(GameData data)
    {
        data.clickCount = count;
        Debug.Log($"Saved {data.clickCount} clicks.\n");
    }
}
