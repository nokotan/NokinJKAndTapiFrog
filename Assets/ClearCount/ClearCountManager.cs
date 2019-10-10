using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCountManager : MonoBehaviour
{
    [System.Serializable]
    public class StageClearCount
    {
        public int StageIndex;
        public int TotalTrialCount;
        public int TotalClearCount;
    }

    [System.Serializable]
    class DatabaseEntry
    {
        public List<StageClearCount> StoredData = new List<StageClearCount>();
    }

    DatabaseEntry databaseEntry;

    string filePath
    {
        get
        {
            return $"{Application.streamingAssetsPath}/{ConfigSystem.Instance.ClearCountDatabase.FilePath}";
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

    public void IncrementClearAndTrialCount(int StageIndex)
    {
        var storedData = databaseEntry.StoredData.Find(item => item.StageIndex == StageIndex);

        if (storedData != null)
        {
            storedData.TotalClearCount++;
            storedData.TotalTrialCount++;
        }
        else
        {
            storedData = new StageClearCount()
            {
                StageIndex = StageIndex,
                TotalClearCount = 1,
                TotalTrialCount = 1
            };

            databaseEntry.StoredData.Add(storedData);
        }
    }

    public void IncrementTrialCount(int StageIndex)
    {
        var storedData = databaseEntry.StoredData.Find(item => item.StageIndex == StageIndex);

        if (storedData != null)
        {
            storedData.TotalClearCount++;
        }
        else
        {
            storedData = new StageClearCount()
            {
                StageIndex = StageIndex,
                TotalTrialCount = 1
            };

            databaseEntry.StoredData.Add(storedData);
        }
    }

    public StageClearCount GetStageClearCount(int StageIndex)
    {
        // もし登録があれば取り出し、登録がなければ null を返す
        return databaseEntry.StoredData.FirstOrDefault(item => item.StageIndex == StageIndex);
    }

    public static ClearCountManager CreateInstance()
    {
        var gameObject = new GameObject();
        return gameObject.AddComponent<ClearCountManager>();
    }
}
