using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StageSelectAnimationControl))]
public class StageSelectControl : MonoBehaviour
{ 
    static public int selectedStage { get; private set; } = 1;

    int selectedStageMax;
    StageSelectAnimationControl animator;

    // Start is called before the first frame update
    void Start()
    {
        selectedStageMax = transform.childCount;
        animator = GetComponent<StageSelectAnimationControl>();
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
                var manager = GameObject.Find("SceneManager");
                manager?.GetComponent<SceneManagement>()?.ChangeScene();
            }
        }   
    }
}
