using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectControl : MonoBehaviour
{ 
    static public int selectedStage { get; private set; } = 1;

    [SerializeField] AudioClip SystemSE;

    int selectedStageMax;
    StageSelectAnimationControl animator;

    // Start is called before the first frame update
    void Start()
    {     
        animator = GetComponentInChildren<StageSelectAnimationControl>();
        selectedStageMax = animator.selectedStageMax;

        selectedStage = 1;
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

                CrossSceneAudioPlayer.PlaySE(SystemSE);
            }
        }   
    }
}
