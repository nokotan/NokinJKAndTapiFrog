using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    float elapsedTime;
    [SerializeField]
    float timeLimit = 60.0f;
    [SerializeField]
    UnityEvent OnTimeOver;

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
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= timeLimit && !onTimeOverInvoked)
        {
            OnTimeOver.Invoke();
            onTimeOverInvoked = true;
        }
    }
}
