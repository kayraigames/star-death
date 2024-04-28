using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [YarnCommand("ChangeScene")]
    public void ChangeScene(string newSceneName){
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != newSceneName)
        {
            SceneManager.LoadScene(sceneName: newSceneName);
        }
    }
}

