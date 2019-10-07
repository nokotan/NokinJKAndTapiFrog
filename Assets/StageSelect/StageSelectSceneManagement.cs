using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectSceneManagement : SceneManagement
{
    [SerializeField] AudioClip BGM;

    // Start is called before the first frame update
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(BGM);
    }
}
