using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 108

public class GameOverSceneManagement : SceneManagement
{
    void Start()
    {
        ClearCountManager.CreateInstance().IncrementTrialCount(StageSelectManager.Instance.selectedStageIndex);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Submit"))
        {
            ChangeScene();
            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
        }
    }
}
