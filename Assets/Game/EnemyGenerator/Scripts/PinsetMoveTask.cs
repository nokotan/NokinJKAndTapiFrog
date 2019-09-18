using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsetMoveTask : MonoBehaviour
{
    [SerializeField] PinsetController[] pinsets;

    public IEnumerator DoCommand(string[] args)
    {
        int positionIndex = Convert.ToInt32(args[0]) - 1;

        StartCoroutine(pinsets[positionIndex].Move());
        yield break;
    }
}
