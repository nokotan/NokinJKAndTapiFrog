using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリア状況を管理するクラス
/// </summary>
public class ClearCountManager : SingletonMonoBehaviour<ClearCountManager>
{
    /// <summary>
    /// ステージごとのクリア状況
    /// </summary>
    [System.Serializable]
    public class StageClearCount
    {
        public int StageIndex;
        public int TotalTrialCount;
        public int TotalClearCount;
    }

    /// <summary>
    /// ファイルに保存するときのクリア状況
    /// </summary>
    [System.Serializable]
    class DatabaseEntry
    {
        public List<StageClearCount> StoredData = new List<StageClearCount>();
    }

    DatabaseEntry databaseEntry;

    /// <summary>
    /// 保存すべきファイルへのパス
    /// </summary>
    string filePath
    {
        get
        {
            return $"{Application.streamingAssetsPath}/{ConfigSystem.Instance.ClearCountDatabase.FilePath}";
        }
    }

    protected override void OnAwake()
    {
        Load();
    }

    protected override void Destroyed()
    {
        Save();
    }

    /// <summary>
    /// ファイルからクリア状況を読み出します
    /// </summary>
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

    /// <summary>
    /// ファイルにクリア状況を保存します
    /// </summary>
    public void Save()
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(databaseEntry, prettyPrint: true));
    }

    /// <summary>
    /// 指定したステージの挑戦数とクリア数を増やします
    /// ステージクリア時に ResultSceneManager から呼ばれます
    /// </summary>
    /// <param name="StageIndex"></param>
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

    /// <summary>
    /// 指定したステージの挑戦数を増やします
    /// ステージクリア時に GameOverSceneManager から呼ばれます
    /// </summary>
    /// <param name="StageIndex"></param>
    public void IncrementTrialCount(int StageIndex)
    {
        var storedData = databaseEntry.StoredData.Find(item => item.StageIndex == StageIndex);

        if (storedData != null)
        {
            storedData.TotalTrialCount++;
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

    /// <summary>
    /// 指定したステージのクリア状況を取得します
    /// </summary>
    /// <param name="StageIndex"></param>
    /// <returns></returns>
    public StageClearCount GetStageClearCount(int StageIndex)
    {
        // もし登録があれば取り出し、登録がなければ null を返す
        return databaseEntry.StoredData.FirstOrDefault(item => item.StageIndex == StageIndex);
    }
}
