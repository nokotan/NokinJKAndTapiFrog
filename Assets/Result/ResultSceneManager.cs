using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームクリア画面の管理とシーン切り替えを行うクラス
/// </summary>
public class ResultSceneManager : DependentSceneManager
{
    /// <summary>
    /// すべてのステージをクリアしたかどうか
    /// </summary>
    /// <returns></returns>
    bool HasAllCleared()
    {
        return StageSelectManager.Instance.clearedStageProgress.All(b => b);
    }

    void Start()
    {
        ClearCountManager.Instance.IncrementClearAndTrialCount(StageSelectManager.Instance.selectedStageIndex);
        StageSelectManager.Instance.clearedStageProgress[StageSelectManager.Instance.selectedStageIndex - 1] = true;
        StageSelectManager.Instance.previousClearedStageIndex = StageSelectManager.Instance.selectedStageIndex;

        if (HasAllCleared())
        {
            // もし全ステージ制覇していたらもう一度遊べる画像を表示しない
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (HasAllCleared())
            {
                SceneManager.LoadScene("Title");
            }
            else
            {
                StageSelectManager.Instance.SwitchSubScene("StageSelect");
            }

            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
        }
    }
}
