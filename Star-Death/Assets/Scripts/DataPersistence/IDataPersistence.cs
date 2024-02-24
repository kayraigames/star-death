public interface IDataPersistence
{
    // Reads data from the GameData and updates your own values accordingly
    public void LoadData(GameData data);
    // Takes in the GameData and updates its values to your values.
    public void SaveData(GameData data);
}
