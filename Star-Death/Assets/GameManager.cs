using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // public int maxMessages = ??, max should be dialogue? determine later
    [SerializeField]
    List<Message> messageList = new List<Message>(); //list of messages 


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessageToChat("You requested past dialogue");
        }
        
    }

    public void SendMessageToChat(string text)
    {


        /*
         * 
         * if(messageList.Count >= maxMessages)
         *      messageList.Remove(messageList[0]);
         * 
         */
        Message newMessage = new Message(); 

        newMessage.text = text; //text inputted by user


        messageList.Add(newMessage); //adds new message to the list
    }



}

[System.Serializable]

public class Message
{
    public string text;

}
