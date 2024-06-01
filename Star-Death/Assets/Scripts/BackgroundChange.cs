using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class BackgroundChange : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private SpriteRenderer backgroundSR;
    //0 = hallway, 1 = hylla's, 2 = throne room, 3 = stars
    public Sprite[] spriteArray;
    
    private void Awake()
    {
        // get handles of utility objects in the scene that we need
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();

        backgroundSR = gameObject.GetComponent<SpriteRenderer>();

        // <<ChangeScene background>>
        dialogueRunner.AddCommandHandler<string>("ChangeScene", ChangeScene);
    }
    
    //[YarnCommand("ChangeScene")]
    public void ChangeScene(string location)
    {
        


        Debug.Log("called");
        //Sprite sprite = Resources.Load<Sprite>("Final_Sprites/" + location);
        
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
                index = 2;
                break;
            case "Ballroom":
                index = 2;
                break;
            case "Court_Room":
                index = 2;
                break;
            case "Stars":
                index = 3;
                break;
        }
       
        backgroundSR.sprite = spriteArray[index];

    }
}