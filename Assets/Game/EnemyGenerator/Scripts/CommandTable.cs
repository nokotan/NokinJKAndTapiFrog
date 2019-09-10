using System;
using System.Linq;
using UnityEngine;

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
