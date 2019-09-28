using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTask : MonoBehaviour
{
    [SerializeField] float smallWaitTime = 2.0f;
    [SerializeField] float mediumWaitTime = 3.0f;
    [SerializeField] float largeWaitTime = 5.0f;

    Dictionary<string, float> waitTimes;

    void Awake()
    {
        waitTimes = new Dictionary<string, float>()
        {
            { "s", smallWaitTime },
            { "m", mediumWaitTime },
            { "l", largeWaitTime },
            { "S", smallWaitTime },
            { "M", mediumWaitTime },
            { "L", largeWaitTime },
        };
    }

    public IEnumerator DoCommand(string[] args)
    {
        if (waitTimes.ContainsKey(args[0]))
        {
            yield return new WaitForSeconds(waitTimes[args[0]]);
        }
    }
}