using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagement : SceneManagement
{
    [SerializeField] string SubSceneName;
    [SerializeField] AudioClip mainBGM;

    // Start is called before the first frame update
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(mainBGM);

        if (!SceneManager.GetSceneByName(SubSceneName).isLoaded)
        {
            SceneManager.LoadScene(SubSceneName, LoadSceneMode.Additive);
        }
    }

    public override void ChangeScene(string sceneName)
    {
        CrossSceneAudioPlayer.StopBGM();
        base.ChangeScene(sceneName);
    }

    public void ReloadScene()
    {
        var op = SceneManager.UnloadSceneAsync(SubSceneName);

        op.completed += opr =>
        {
            SceneManager.LoadScene(SubSceneName, LoadSceneMode.Additive);
        };
    }
}
