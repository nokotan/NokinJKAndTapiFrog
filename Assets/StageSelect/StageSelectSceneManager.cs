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
            StageSelectManager.Instance.SwitchSubScene("Game");
            CrossSceneAudioPlayer.PlaySE(SystemSE);
        }
    }
}
