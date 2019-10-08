using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDeathFileDatabase : FrogDeathDatabase
{
    [System.Serializable]
    class DatabaseEntry
    {
        public List<string> StoredData = new List<string>();
    }

    DatabaseEntry databaseEntry;

    string filePath
    {
        get
        {
            return $"{Application.streamingAssetsPath}/{ConfigSystem.Instance.FrogDeathDatabase.FilePath}";
        }
    }

    void Awake()
    {
        Load();
    }

    void OnDestroy()
    {
        Save();
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            databaseEntry = JsonUtility.FromJson<DatabaseEntry>(File.ReadAllText(filePath));
        }
        
        if (databaseEntry == null)
        {
            databaseEntry = new DatabaseEntry();
        }
    }

    public void Save()
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(databaseEntry, prettyPrint: true));
    }

    public override void AppendEntry(string entry)
    {
        databaseEntry.StoredData.Add(entry);
    }

    public override void ClearAllEntries()
    {
        databaseEntry.StoredData.Clear();
    }

    public override int GetEntriesCount()
    {
        return databaseEntry.StoredData.Count;
    }

    public override string GetEntry(int index)
    {
        return databaseEntry.StoredData[index];
    }
}
