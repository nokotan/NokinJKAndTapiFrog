using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [Serializable]
    public class OnTickHandler : UnityEvent<string>
    {

    }

    [SerializeField]
    float elapsedTime;
    [SerializeField]
    float timeLimit = 60.0f;
    [SerializeField]
    UnityEvent OnTimeOver;
    [SerializeField]
    OnTickHandler OnTick;

    bool onTimeOverInvoked;

    public float LeftTime
    {
        get
        {
            return Mathf.Max(timeLimit - elapsedTime, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousLeftTime = (int)LeftTime;

        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= timeLimit && !onTimeOverInvoked)
        {
            OnTimeOver.Invoke();
            onTimeOverInvoked = true;
        }

        int currentLeftTime = (int)LeftTime;

        if (previousLeftTime != currentLeftTime)
        {
            OnTick.Invoke(currentLeftTime.ToString());
        }
    }
}
