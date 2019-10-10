using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSceneManagement : SceneManagement
{
    [Header("Scene Specific")]
    [SerializeField] string SubSceneName;
    [SerializeField] AudioClip mainBGM;

    /// <summary>
    /// シーンの読み込みが完了したときに呼ばれる関数
    /// </summary>
    [SerializeField] UnityEvent OnSubSceneLoaded;

    /// <summary>
    /// シーンの読み込みが終わったときに読み込まれます。
    /// </summary>
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(mainBGM);

        if (!SceneManager.GetSceneByName(SubSceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(SubSceneName, LoadSceneMode.Additive).completed += op =>
            {
                OnSubSceneLoaded.Invoke();
            };
        }
        else
        {
            OnSubSceneLoaded.Invoke();
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

    /// <summary>
    /// サブシーンを読み込みなおします。
    /// </summary>
    public void ReloadScene()
    {     
        SceneManager.UnloadSceneAsync(SubSceneName).completed += op1 =>
        {
            SceneManager.LoadSceneAsync(SubSceneName, LoadSceneMode.Additive).completed += op2 =>
            {
                OnSubSceneLoaded.Invoke();
            };
        };
    }
}
