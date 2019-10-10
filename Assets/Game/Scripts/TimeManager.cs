using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    public Text timer;
    public AudioSource clear;

    [SerializeField]
    float elapsedTime;
    float timeLimit;

    bool onTimeOverInvoked;
    
    public float LeftTime
    {
        get
        {
            return Mathf.Max(timeLimit - elapsedTime, 0.0f);
        }
    }

    public float ElapsedTime
    {
        get
        {
            return elapsedTime;
        }
    }

    public void ResetTimer()
    {
        elapsedTime = 0.0f;
    }

    public void StartTimer()
    {
        enabled = true;
    }

    public void StopTimer()
    {
        enabled = false;
    }

    void Start()
    {
        timeLimit = ConfigSystem.Instance.GameSetting.TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        int previousLeftTime = (int)LeftTime;

        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= timeLimit && !onTimeOverInvoked)
        {
            onTimeOverInvoked = true;
            CrossSceneAudioPlayer.StopBGM();
            clear.Play();

            CSVParser.Instance.StopEnemyGenerating();
            GameSceneManager.Instance.SwitchScene("Result");
        }

        int currentLeftTime = (int)LeftTime;
        timer.text = currentLeftTime.ToString();
    }
}
