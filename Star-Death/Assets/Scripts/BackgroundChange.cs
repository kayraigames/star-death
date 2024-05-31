using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class BackgroundChange : MonoBehaviour
{
    public SpriteRenderer backgroundSpriteRenderer;
    public DialogueRunner dialogueRunner;
    //0 = hallway, 1 = hylla's, 2 = throne room, 3 = stars
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    /*
    void Start()
    {
        background = gameObject.GetComponent<SpriteRenderer>();
    }
    */
    /*
    public void Awake()
    {

        // Create a new command called 'camera_look', which looks at a target. 
        // Note how we're listing 'GameObject' as the parameter type.
        dialogueRunner.AddCommandHandler<string>(
            "ChangeScene",     // the name of the command
            ChangeScene // the method to run
        );
    }

    */


    [YarnCommand("ChangeScene")]
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
            case "Throne Room":
                index = 2;
                break;
            case "Ballroom":
                index = 2;
                break;
            case "Court Room":
                index = 2;
                break;
            case "Stars":
                index = 3;
                break;
        }

        backgroundSpriteRenderer.sprite = spriteArray[index];
        

        

}
}