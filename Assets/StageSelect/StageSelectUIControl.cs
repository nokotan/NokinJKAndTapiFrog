using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージセレクト画面のユーザーの入力をハンドリングし、各サブコンポーネントに伝令します
/// </summary>
public class StageSelectUIControl : SingletonMonoBehaviour<StageSelectUIControl>
{ 
    [SerializeField] int selectedStage = 1;
    [SerializeField] int selectedStageMax;
    StageSelectAnimationControl animator;

    public int SelectedStage => selectedStage;

    // Start is called before the first frame update
    void Start()
    {     
        animator = GetComponentInChildren<StageSelectAnimationControl>();
        selectedStageMax = animator.selectedStageMax;
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
        }   
    }
}
