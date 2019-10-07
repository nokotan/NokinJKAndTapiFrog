using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsetMoveTask : MonoBehaviour
{
    [SerializeField] PinsetController[] pinsets;
    public static bool shake = false;

    public IEnumerator DoCommand(string[] args)
    {
        shake = false;
        int positionIndex = Convert.ToInt32(args[0]) - 1;
        return pinsets[positionIndex].Move();
    }
}
