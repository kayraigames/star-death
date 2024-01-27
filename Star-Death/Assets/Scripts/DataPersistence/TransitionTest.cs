using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTest : MonoBehaviour
{
    public void OnClickNewGame()
    {
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync("DataPersistenceTest");
    }

    public void OnClickLoadGame()
    {
        DataPersistenceManager.instance.LoadGame();

        SceneManager.LoadSceneAsync("DataPersistenceTest");
    }
}
