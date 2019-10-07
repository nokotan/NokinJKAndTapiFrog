using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrossSceneAudioPlayer : SingletonMonoBehaviour<CrossSceneAudioPlayer>
{
    [SerializeField] AudioSource bgmAudioPlayer;
    [SerializeField] AudioSource seAudioPlayer;

    protected override void OnAwake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void ChangeBGM(AudioClip clip)
    {
        var audioPlayer = Instance.bgmAudioPlayer;

        if (audioPlayer.clip == clip)
        {
            return;
        }

        audioPlayer.clip = clip;

        if (clip != null)
        {
            audioPlayer.Play();
        }
    }

    public static void PlayBGM(AudioClip clip)
    {
        var audioPlayer = Instance.bgmAudioPlayer;

        audioPlayer.clip = clip;
        audioPlayer.Play();
    }

    public static void StopBGM()
    {
        var audioPlayer = Instance.bgmAudioPlayer;

        audioPlayer.Stop();
        audioPlayer.clip = null;
    }

    public static void PlaySE(AudioClip clip)
    {
        var audioPlayer = Instance.seAudioPlayer;

        audioPlayer.clip = clip;
        audioPlayer.Play();
    }
}
