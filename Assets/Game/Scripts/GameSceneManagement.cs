using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagement : SceneManagement
{
    [SerializeField] AudioClip mainBGM;

    // Start is called before the first frame update
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(mainBGM);
    }

    public override void ChangeScene(string sceneName)
    {
        base.ChangeScene(sceneName);
        CrossSceneAudioPlayer.StopBGM();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
