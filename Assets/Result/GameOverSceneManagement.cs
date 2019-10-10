using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 108

public class GameOverSceneManagement : DependentSceneManager
{
    void Start()
    {
        ClearCountManager.CreateInstance().IncrementTrialCount(StageSelectManager.Instance.selectedStageIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Title");
            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
        }
    }
}
