using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private SpriteRenderer backgroundSR;
    //0 = hallway, 1 = hylla's, 2 = throne room, 3 = stars, 4 = nuon's, 5 = library
    public Sprite[] spriteArray;

    public Camera mainCamera;
    


    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();

        backgroundSR = gameObject.GetComponent<SpriteRenderer>(); //sprite renderer 

        // <<ChangeScene background>>
        dialogueRunner.AddCommandHandler<string>("ChangeScene", ChangeScene);


        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

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
        ScaleImage();

    }

    void ScaleImage()
    {
        // Get the dimensions of the camera's viewport in world units
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Get the dimensions of the sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;

        // Calculate the scale factor
        float scaleFactor = Mathf.Max(screenWidth / spriteWidth, screenHeight / spriteHeight);

        // Apply the scale factor
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

        // Position the sprite to the camera's view center
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
    }
}