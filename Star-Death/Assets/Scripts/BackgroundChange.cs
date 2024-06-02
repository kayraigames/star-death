using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class BackgroundChange : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private SpriteRenderer backgroundSR;
    //0 = hallway, 1 = hylla's, 2 = throne room, 3 = stars, 4 = nuon's, 5 = library
    public Sprite[] spriteArray;
    
    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();

        backgroundSR = gameObject.GetComponent<SpriteRenderer>(); //sprite renderer 

        // <<ChangeScene background>>
        dialogueRunner.AddCommandHandler<string>("ChangeScene", ChangeScene);
    }
    
    //[YarnCommand("ChangeScene")]
    public void ChangeScene(string location)
    {
        int index = 0; //default = hallway
        switch (location)
        {
            case "Hallway":
                index = 0;
                break;
            case "Hylla's_Bedroom":
                index = 1;
                break;
            case "Throne_Room":
            case "Ballroom":
            case "Court_Room":
                index = 2;
                break;
            case "Stars":
                index = 3;
                break;
            case "Nuon's_Bedroom":
                index = 4;
                break;
            case "Library":
                index = 5;
                break;
        }
       
        backgroundSR.sprite = spriteArray[index];

    }
}