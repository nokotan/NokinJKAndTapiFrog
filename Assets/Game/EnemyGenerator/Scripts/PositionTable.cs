using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PositionTable/CreatePositionTable")]
public class PositionTable : ScriptableObject
{
    public enum Directions
    {
        Up = 0, Down = 180, Left = 270, Right = 90
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