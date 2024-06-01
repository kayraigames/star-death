using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class VisualNovel : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    // private FadeOverlay fadeOverlay;

    private void Awake()
    {
        // get handles of utility objects in the scene that we need
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        // fadeOverlay = FindObjectOfType<FadeOverlay>();
        // <<loadCharacterSprite NAME_OF_SPRITE>>
        dialogueRunner.AddCommandHandler<string>("loadCharacterSprite", LoadCharacterSprite);

        // <<destroyCharacterSprite NAME_OF_SPRITE>>
        dialogueRunner.AddCommandHandler<string>("destroyCharacterSprite", DestroyCharacterSprite);

        // <<fadeIn DURATION>>

        // <<fadeOut DURATION>>
    }

    public void LoadCharacterSprite(string spriteName)
    {
        // Load the sprite from the Resources/Final_Sprites folder
        Sprite sprite = Resources.Load<Sprite>("Final_Sprites/" + spriteName);
        
        if (sprite == null)
        {
            Debug.LogError("Sprite not found: " + spriteName);
            return;
        }

        // Create a new GameObject to hold the sprite
        GameObject spriteObject = new GameObject(spriteName);
        
        // Add a SpriteRenderer component to the GameObject
        SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        
        // Assign the loaded sprite to the SpriteRenderer
        spriteRenderer.sprite = sprite;

        // Assign sorting layer of character sprite to foreground
        spriteRenderer.sortingLayerName = "Foreground";
        
        // Optionally, set the position of the new GameObject
        spriteObject.transform.position = Vector2.zero;
    }

    public void DestroyCharacterSprite(string spriteName)
    {
        // Find the GameObject by its name
        GameObject spriteObject = GameObject.Find(spriteName);
        if (spriteObject != null)
        {
            // Destroy the GameObject
            Destroy(spriteObject);
        }
        else
        {
            Debug.LogError("GameObject not found: " + spriteName);
        }
    }
}
