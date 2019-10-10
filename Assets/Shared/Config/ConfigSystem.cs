using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConfigSystem
{
    [System.Serializable]
    public class EnemyGeneratingConfig
    {
        public string FilePath;
        public string[] Stages;
    }

    [System.Serializable]
    public class GameConfig
    {
        public int TimeLimit;
        public int InitialZanki;
    }

    [System.Serializable]
    public class FrogDeathDatabaseConfig
    {
        public string FilePath;
    }

    [System.Serializable]
    public class ClearCountDatabaseConfig
    {
        public string FilePath;
    }

    public EnemyGeneratingConfig EnemyGenerating;
    public GameConfig GameSetting;
    public FrogDeathDatabaseConfig FrogDeathDatabase;
    public ClearCountDatabaseConfig ClearCountDatabase;

    static ConfigSystem m_Instance;

    public static ConfigSystem Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = JsonUtility.FromJson<ConfigSystem>(File.ReadAllText($"{Application.streamingAssetsPath}/Config.json", Encoding.UTF8));
            }

            return m_Instance;
        }
    }
}
