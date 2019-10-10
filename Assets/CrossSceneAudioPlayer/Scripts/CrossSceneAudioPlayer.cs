using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンをまたいでも音声が切れないようにするための音声再生システムを提供します
/// </summary>
public class CrossSceneAudioPlayer : SingletonMonoBehaviour<CrossSceneAudioPlayer>
{
    [SerializeField] AudioSource bgmAudioPlayer;
    [SerializeField] AudioSource seAudioPlayer;

    /// <summary>
    /// 起動時に呼ばれる関数
    ///  SingletonMonoBehaviour で Awake 関数を定義していて上書きしないために
    /// わざと別の関数を用意している。
    /// </summary>
    protected override void OnAwake()
    {
        // 起動時にこれを呼ぶことでシーンが切り替わってもゲームオブジェクトが消えなくなる
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// BGMを切り替えます
    /// もし指定した BGM が再生中であれば何もしません
    /// </summary>
    /// <param name="clip">再生したい BGM</param>
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

    /// <summary>
    /// BGM を切り替えます
    /// 常に最初からの再生になります
    /// </summary>
    /// <param name="clip">再生したい BGM</param>
    public static void PlayBGM(AudioClip clip)
    {
        var audioPlayer = Instance.bgmAudioPlayer;

        audioPlayer.clip = clip;
        audioPlayer.Play();
    }

    /// <summary>
    /// BGM を止めます
    /// </summary>
    public static void StopBGM()
    {
        var audioPlayer = Instance.bgmAudioPlayer;

        audioPlayer.Stop();
        audioPlayer.clip = null;
    }

    /// <summary>
    /// 効果音を鳴らします
    /// PlayBGM とはループ再生を行わない点で異なります。
    /// </summary>
    /// <param name="clip"></param>
    public static void PlaySE(AudioClip clip)
    {
        var audioPlayer = Instance.seAudioPlayer;

        audioPlayer.clip = clip;
        audioPlayer.Play();
    }
}
