using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンにまたがって選択したステージの情報を伝搬する仲立ちクラス
/// </summary>
public class StageSelectManager : SingletonMonoBehaviour<StageSelectManager>
{
    [SerializeField] string m_SelectedStagePath;

    /// <summary>
    /// 現在選択されているステージが保存されているパス
    /// 書き込みシーン: StageSelect
    /// 読み込みシーン: Game
    /// </summary>
    public string selectedStagePath
    {
        get
        {
            return m_SelectedStagePath;
        }
        set
        {
            m_SelectedStagePath = value;
        }
    }

    [SerializeField] int m_SelectedStageIndex;

    /// <summary>
    /// 現在選択されているステージの番号
    /// 書き込みシーン: StageSelect
    /// 読み込みシーン: Game
    /// </summary>
    public int selectedStageIndex
    {
        get
        {
            return m_SelectedStageIndex;
        }
        set
        {
            m_SelectedStageIndex = value;
        }
    }

    [SerializeField] bool[] m_ClearedStageProgress = new bool[5];

    /// <summary>
    /// ほかにシーンが開かれていなかったときに代わりに開くシーン
    /// </summary>
    [SerializeField] string m_DefaultScene;

    /// <summary>
    /// ステージのクリア状況
    /// 書き込みシーン: Clear
    /// 読み込みシーン: StageSelect
    /// </summary>
    public bool[] clearedStageProgress => m_ClearedStageProgress;

    /// <summary>
    /// このコンポーネントによって管理されるサブシーン
    /// シーン切り替えのために使います
    /// </summary>
    Scene subScene;

    void Start()
    {
        TakeOwnershipOfScene();
    }

    /// <summary>
    /// アクティブなシーンをこのコンポーネントが含まれているシーンに切り替えます。
    /// </summary>
    void TakeOwnershipOfScene()
    {
        var currentScene = gameObject.scene;
        var currentActiveScene = SceneManager.GetActiveScene();

        // このゲームオブジェクトが属するシーンがアクティブでないならば
        if (currentScene != currentActiveScene)
        {
            SceneManager.SetActiveScene(currentScene);
            subScene = currentActiveScene;
        }
        // このゲームオブジェクトが属するシーンがアクティブであり、かつほかに読み込まれているシーンがあれば
        else if (SceneManager.sceneCount >= 2)
        {
            // このゲームオブジェクトが属するシーンでないほうのシーンをサブシーンに登録する
            for (var i = 0; i < 2; i++)
            {
                var scene = SceneManager.GetSceneAt(i);

                if (scene != currentScene)
                {
                    subScene = scene;
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning($"{currentScene.name} シーンを単独で開かないでください。");

            SwitchSubScene(m_DefaultScene);
        }
    }

    /// <summary>
    /// GameCore シーンを削除しないでシーンを切り替えます。
    /// </summary>
    /// <param name="newSceneName">切り替える先のシーン</param>
    public void SwitchSubScene(string newSceneName)
    {
        if (subScene.IsValid())
        {
            SceneManager.UnloadSceneAsync(subScene);
        }

        SceneManager.LoadScene(newSceneName, LoadSceneMode.Additive);

        subScene = SceneManager.GetSceneByName(newSceneName);
    }

    /// <summary>
    /// GameCore シーンを削除してシーンを切り替えます。
    /// </summary>
    /// <param name="newSceneName">切り替える先のシーン</param>
    public void SwitchScene(string newSceneName)
    {
        SceneManager.LoadScene(newSceneName);
    }
}
