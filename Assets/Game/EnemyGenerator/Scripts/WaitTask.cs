using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            { "l", largeWaitTime },
            { "S", smallWaitTime },
            { "M", mediumWaitTime },
            { "L", largeWaitTime },
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