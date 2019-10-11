using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面の管理とシーン制御を行います
/// </summary>
public class GameSceneManager : DependentSceneManager
{
    [Header("Scene Specific")]
    [SerializeField] AudioClip mainBGM;

    /// <summary>
    /// シーンの読み込みが終わったときに呼び出されます。
    /// </summary>
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(mainBGM);

        if (!SceneManager.GetSceneByName("SubGame").isLoaded)
        {
            // SubGame.scene が読み込まれていなければ読み込む
            SceneManager.LoadSceneAsync("SubGame", LoadSceneMode.Additive).completed += op =>
            {
                CSVParser.Instance.RestartEnemyGenerating();
            };
        }
        else
        {
            CSVParser.Instance.RestartEnemyGenerating();
        }
    }

    /// <summary>
    /// シーンが破棄されるときに呼び出されます。
    /// </summary>
    void OnDestroy()
    {
        CrossSceneAudioPlayer.StopBGM();
        SceneManager.UnloadSceneAsync("SubGame");
    }

    public void SwitchScene(string sceneName)
    {
        StageSelectManager.Instance.SwitchSubScene(sceneName);
    }

    /// <summary>
    /// サブシーンを読み込みなおします。
    /// </summary>
    public void ReloadScene()
    {     
        SceneManager.UnloadSceneAsync("SubGame").completed += op1 =>
        {
            SceneManager.LoadSceneAsync("SubGame", LoadSceneMode.Additive).completed += op2 =>
            {
                CSVParser.Instance.RestartEnemyGenerating();
            };
        };
    }

    /// <summary>
    /// シーン中にある GameSceneManager を探してきます
    /// </summary>
    public static GameSceneManager Instance
    {
        get
        {
            return GameObject.FindObjectOfType<GameSceneManager>();
        }
    }
}
