using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム画面でのシーン制御を行います
/// </summary>
public class GameSceneManager : DependentSceneManager
{
    [Header("Scene Specific")]
    [SerializeField] string SubSceneName;
    [SerializeField] AudioClip mainBGM;

    /// <summary>
    /// シーンの読み込みが終わったときに呼び出されます。
    /// </summary>
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(mainBGM);

        if (!SceneManager.GetSceneByName(SubSceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(SubSceneName, LoadSceneMode.Additive).completed += op =>
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
        SceneManager.UnloadSceneAsync(SubSceneName);
    }

    public override void SwitchScene(string sceneName)
    {
        StageSelectManager.Instance.SwitchSubScene(sceneName);
    }

    /// <summary>
    /// サブシーンを読み込みなおします。
    /// </summary>
    public void ReloadScene()
    {     
        SceneManager.UnloadSceneAsync(SubSceneName).completed += op1 =>
        {
            SceneManager.LoadSceneAsync(SubSceneName, LoadSceneMode.Additive).completed += op2 =>
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
