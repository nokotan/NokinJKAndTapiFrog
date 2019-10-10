using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージセレクト画面のユーザーの入力をハンドリングし、各サブコンポーネントに伝令します
/// </summary>
public class StageSelectUIControl : MonoBehaviour
{ 
    [SerializeField] AudioClip SystemSE;

    int selectedStage = 1;
    int selectedStageMax;
    StageSelectAnimationControl animator;

    // Start is called before the first frame update
    void Start()
    {     
        animator = GetComponentInChildren<StageSelectAnimationControl>();
        selectedStageMax = animator.selectedStageMax;
    }

    /// <summary>
    /// StageSelectManager に選択したステージを登録して、Game シーンで読み取れるようにします。
    /// </summary>
    void SetStageIndexAndPath(int selectedStage)
    {
        var config = ConfigSystem.Instance;
        var stageList = config.EnemyGenerating.Stages;

        StageSelectManager.Instance.selectedStageIndex = selectedStage;
        StageSelectManager.Instance.selectedStagePath = stageList[selectedStage];
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.isInAnimation)
        {
            if (Input.GetAxisRaw("Horizontal") < -0.9f && selectedStage > 1)
            {
                animator.SetFocus(selectedStage - 1);
                selectedStage--;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0.9f && selectedStage < selectedStageMax)
            {
                animator.SetFocus(selectedStage + 1);
                selectedStage++;
            }

            if (Input.GetButtonDown("Submit"))
            {
                SetStageIndexAndPath(selectedStage);
                StageSelectManager.Instance.SwitchSubScene("Game");

                CrossSceneAudioPlayer.PlaySE(SystemSE);
            }
        }   
    }
}
