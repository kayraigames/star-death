using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Scene1");
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
