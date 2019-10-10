using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 108

public class ResultSceneManagement : SceneManagement
{
    void Start()
    {
        ClearCountManager.CreateInstance().IncrementClearAndTrialCount(StageSelectManager.Instance.selectedStageIndex); 
    }

    public override void ChangeScene(string sceneName)
    {
        StageSelectManager.Instance.SwitchSubScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            ChangeScene();
            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
        }
    }
}
