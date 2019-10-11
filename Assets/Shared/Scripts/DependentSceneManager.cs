using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 依存するシーンを持っているシーンの管理をしやすくするための基底クラス
/// </summary>
public class DependentSceneManager : MonoBehaviour
{
    /// <summary>
    /// このシーンが依存しているシーン
    /// </summary>
    [SerializeField] string m_DependingSceneName;

    void Awake()
    {
        LoadDependingScenes();
    }

    /// <summary>
    /// 依存するシーンを読み込みます
    /// </summary>
    void LoadDependingScenes()
    {
        if (!SceneManager.GetSceneByName(m_DependingSceneName).IsValid())
        {
            SceneManager.LoadScene(m_DependingSceneName, LoadSceneMode.Additive);
        }
    }
}

