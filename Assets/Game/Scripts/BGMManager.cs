using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] AudioClip bgm;

    // Start is called before the first frame update
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(bgm);
    }

    public void StopBGM()
    {
        CrossSceneAudioPlayer.StopBGM();
    }
}
