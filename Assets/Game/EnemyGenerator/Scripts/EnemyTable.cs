using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyTable/CreateEnemyTable")]
public class EnemyTable : ScriptableObject
{
    [Serializable]
    public class EnemyEntry
    {
        public string EnemyName;
        public GameObject Prefab;
    }

    [SerializeField]
    EnemyEntry[] Entries;

    public EnemyEntry Find(string name)
    {
        return Entries.FirstOrDefault(obj => obj.EnemyName == name);
    }
}