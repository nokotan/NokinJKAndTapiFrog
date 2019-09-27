using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSceneManagement : SceneManagement
{
    [SerializeField] string SubSceneName;
    [SerializeField] AudioClip mainBGM;

    [SerializeField] UnityEvent OnSubSceneLoaded;

    // Start is called before the first frame update
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

    public override void ChangeScene(string sceneName)
    {
        CrossSceneAudioPlayer.StopBGM();
        base.ChangeScene(sceneName);
    }

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
