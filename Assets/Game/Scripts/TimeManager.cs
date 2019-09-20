using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timer;
    public AudioSource clear;
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
            CrossSceneAudioPlayer.StopBGM();
            clear.Play();
        }

        int currentLeftTime = (int)LeftTime;

        if (previousLeftTime != currentLeftTime)
        {
            OnTick.Invoke(currentLeftTime.ToString());
            
        }
        timer.text = currentLeftTime.ToString();
    }
}
