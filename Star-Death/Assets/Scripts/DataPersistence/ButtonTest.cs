using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTest : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int count;
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        this.count = 0;
    }
    private void Update()
    {
        this.text.text = this.count.ToString();
    }

    public void OnClick()
    {
        this.count++;
    }

    public void LoadData(GameData data)
    {
        this.count = data.clickCount;
    }

    public void SaveData(GameData data)
    {
        data.clickCount = this.count;
    }
}
