using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ選択画面でのシーンを管理します。
/// </summary>
public class StageSelectSceneManager : DependentSceneManager
{
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioClip SystemSE;

    /// <summary>
    /// StageSelectManager に選択したステージを登録して、Game シーンで読み取れるようにします。
    /// </summary>
    void SetStageIndexAndPath()
    {
        var config = ConfigSystem.Instance;
        var stageList = config.EnemyGenerating.Stages;
        var selectedStage = StageSelectUIControl.Instance.SelectedStage;

        StageSelectManager.Instance.selectedStageIndex = selectedStage;
        StageSelectManager.Instance.selectedStagePath = stageList[selectedStage - 1];
    }

    // Start is called before the first frame update
    void Start()
    {
        // 確実に BGM が流れるようにする
        CrossSceneAudioPlayer.ChangeBGM(BGM);
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (!StageSelectManager.Instance.clearedStageProgress[StageSelectUIControl.Instance.SelectedStage - 1])
            {
                SetStageIndexAndPath();
                StageSelectManager.Instance.SwitchSubScene("Game");
            }
            
            CrossSceneAudioPlayer.PlaySE(SystemSE);
        }
    }
}
