using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTask : MonoBehaviour
{
    [SerializeField] TapiBallAddTask tapiBallAddTask;
    [SerializeField] PinsetMoveTask pinsetMoveTask;

    public IEnumerator DoCommand(string[] args)
    {
        var enemyName = args[0];
        var leftArgs = args.Skip(1).ToArray();

        if (enemyName == "tap")
        {
            return tapiBallAddTask.DoCommand(leftArgs);
        }
        else if (enemyName == "pin")
        {
            return pinsetMoveTask.DoCommand(leftArgs);
        }
        else
        {
            return null;
        }
    }
}
