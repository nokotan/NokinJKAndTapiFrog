using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CommandTask/PinAddTask")]
public class PinAddCommand : CommandTask
{
    [SerializeField] GameObject prefab;
    [SerializeField] PositionTable positions;

    public override IEnumerator DoCommand(string[] args)
    {
        int positionIndex = Convert.ToInt32(args[0]) - 1;

        GameObject.Instantiate(prefab, positions[positionIndex].Position, Quaternion.Euler(0, 0, (float)positions[positionIndex].Direction));
        yield break;
    }
}
