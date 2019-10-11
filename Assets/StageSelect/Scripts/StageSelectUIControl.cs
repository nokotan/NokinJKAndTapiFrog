using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージセレクト画面のユーザーの入力をハンドリングし、各サブコンポーネントに伝令します
/// </summary>
public class StageSelectUIControl : SingletonMonoBehaviour<StageSelectUIControl>
{ 
    [SerializeField] int selectedStage = 1;
    [SerializeField] int selectedStageMax;
    StageSelectAnimationControl animator;

    public int SelectedStage => selectedStage;

    [SerializeField] Text InfoWindow;

    // Start is called before the first frame update
    void Start()
    {     
        animator = GetComponentInChildren<StageSelectAnimationControl>();
        selectedStageMax = animator.selectedStageMax;

        UpdateInfoWindow();
    }

    /// <summary>
    /// ステージごとのクリア率を更新します
    /// </summary>
    void UpdateInfoWindow()
    {
        var stageClearData = ClearCountManager.Instance.GetStageClearCount(selectedStage);

        if (stageClearData == null || stageClearData.TotalTrialCount == 0)
        {
            InfoWindow.text = "Clear Rate: -% (0/0)";
        }
        else
        {
            var ratio = stageClearData.TotalClearCount * 100.0f / stageClearData.TotalTrialCount;
            InfoWindow.text = $"Clear Rate: {ratio.ToString("F2")}% ({stageClearData.TotalClearCount}/{stageClearData.TotalTrialCount})";
        }
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
                UpdateInfoWindow();
            }
            else if (Input.GetAxisRaw("Horizontal") > 0.9f && selectedStage < selectedStageMax)
            {
                animator.SetFocus(selectedStage + 1);
                selectedStage++;
                UpdateInfoWindow();
            }
        }   
    }
}
