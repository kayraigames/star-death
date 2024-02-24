using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Instructions for use:

All classes with data that needs to be saved must implement the IDataPersistence interface.
All data that needs to be saved must have a corresponding field in the GameData class.

Call Savegame before you transition scenes.

*/

// Need to separate updating the GameData state and writing to disk

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private FileDataHandler dataHandler;
    private List<IDataPersistence> dataPersistenceObjects;
    private string selectedProfileID = "";

    public static DataPersistenceManager instance {get; private set;}

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded.\n");
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void ChangeSelectedProfileID(string newProfileID)
    {
        selectedProfileID = newProfileID;

        LoadGame();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(gameObject);

        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        selectedProfileID = dataHandler.GetMostRecentlyUpdatedProfileID();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    
    public void NewGame()
    {
        gameData = new GameData(fileName);
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load(selectedProfileID);

        if (gameData == null)
        {
            Debug.Log("Did not find save.\n");
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

        if (gameData == null)
        {
            return;
        }

        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        dataHandler.Save(gameData, selectedProfileID);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    public List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        if (gameData == null)
        {
            Debug.Log("No game found.\n");
        }
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}
