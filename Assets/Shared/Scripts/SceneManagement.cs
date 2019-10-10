using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    /// <summary>
    /// 遷移する先のシーン名
    /// </summary>
    [SerializeField] string m_NextSceneName;

    /// <summary>
    /// このシーンが依存しているシーン
    /// </summary>
    [SerializeField] string[] m_DependingScenes;

    void Awake()
    {
        LoadDependingScenes();
    }

    /// <summary>
    /// 依存するシーンを読み込みます
    /// </summary>
    void LoadDependingScenes()
    {
        foreach (var sceneName in m_DependingScenes)
        {
            if (!SceneManager.GetSceneByName(sceneName).IsValid())
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
        }
    }

    /// <summary>
    /// NextSceneNameで指定したシーンを切り替えます。
    /// </summary>
    public void ChangeScene()
    {
        ChangeScene(m_NextSceneName);
    }

    /// <summary>
    /// 指定したシーンへ切り替えます。
    /// </summary>
    /// <param name="sceneName"></param>
    public virtual void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    protected void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.D))
        {
            ChangeScene("Title");
        }
    }
}

