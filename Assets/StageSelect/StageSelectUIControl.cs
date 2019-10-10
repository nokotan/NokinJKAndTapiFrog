﻿using System.Collections;
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

    ClearCountManager clearData;

    // Start is called before the first frame update
    void Start()
    {     
        animator = GetComponentInChildren<StageSelectAnimationControl>();
        selectedStageMax = animator.selectedStageMax;

        clearData = ClearCountManager.CreateInstance();
        clearData.Load();

        UpdateInfoWindow();
    }

    void UpdateInfoWindow()
    {
        var stageClearData = clearData.GetStageClearCount(selectedStage);

        if (stageClearData == null || stageClearData.TotalTrialCount == 0)
        {
            InfoWindow.text = "Clear Rate: -% (0/0)";
        }
        else
        {
            var ratio = stageClearData.TotalClearCount / stageClearData.TotalTrialCount * 100.0f;
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
