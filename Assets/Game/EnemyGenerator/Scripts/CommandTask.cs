using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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

[CreateAssetMenu(menuName = "PositionTable/CreatePositionTable")]
public class PositionTable : ScriptableObject
{
    public enum Directions
    {
        Up, Down, Left, Right
    }

    [Serializable]
    public class PositionEntry
    {
        public Vector3 Position;
        public Directions Direction;
    }

    [SerializeField]
    PositionEntry[] entries;

    public PositionEntry this[int index]
    {
        get
        {
            return entries[index];
        }
    }

}

[CreateAssetMenu(menuName = "CommandTable/CreateCommandTable")]
public class CommandTable : ScriptableObject
{
    [Serializable]
    public class CommandEntry
    {
        public string CommandName;
        public CommandTask Task;
    }

    [SerializeField]
    CommandEntry[] Entries;

    public CommandEntry Find(string name)
    {
        return Entries.FirstOrDefault(obj => obj.CommandName == name);
    }
}

public class CommandTask : ScriptableObject
{
    public virtual IEnumerator DoCommand(string[] args)
    {
        yield break;
    }
}

[CreateAssetMenu(menuName = "CommandTask/CreateWaitTask")]
public class WaitTask : CommandTask
{
    [SerializeField] float smallWaitTime = 1.0f;
    [SerializeField] float mediumWaitTime = 3.0f;
    [SerializeField] float largeWaitTime = 5.0f;

    Dictionary<string, float> waitTimes;

    void OnEnable()
    {
        waitTimes = new Dictionary<string, float>()
        {
            { "s", smallWaitTime },
            { "m", mediumWaitTime },
            { "l", largeWaitTime }
        };
    }

    public override IEnumerator DoCommand(string[] args)
    {
        if (waitTimes.ContainsKey(args[0]))
        {
            yield return new WaitForSeconds(waitTimes[args[0]]);
        }
    }
}

[CreateAssetMenu(menuName = "CommandTask/CreateAttackTask")]
public class AttackTask : CommandTask
{
    [SerializeField] EnemyTable enemies;
    [SerializeField] PositionTable positions;
    [SerializeField] float waitTime = 1.0f;

    public override IEnumerator DoCommand(string[] args)
    {
        string enemyName = args[0];
        int positionIndex = Convert.ToInt32(args[1]) - 1;

        GameObject.Instantiate(enemies.Find(enemyName).Prefab, positions[positionIndex].Position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
    }
}