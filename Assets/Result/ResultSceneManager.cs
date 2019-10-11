using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 108

/// <summary>
/// ゲームクリア画面の管理とシーン切り替えを行うクラス
/// </summary>
public class ResultSceneManager : DependentSceneManager
{
    void Start()
    {
        ClearCountManager.Instance.IncrementClearAndTrialCount(StageSelectManager.Instance.selectedStageIndex);
        StageSelectManager.Instance.clearedStageProgress[StageSelectManager.Instance.selectedStageIndex - 1] = true;
        StageSelectManager.Instance.previousClearedStageIndex = StageSelectManager.Instance.selectedStageIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            StageSelectManager.Instance.SwitchSubScene("StageSelect");
            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
        }
    }
}
