using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSceneAudioPlayerProxy : MonoBehaviour
{
    public void PlayOneShot(AudioClip clip)
    {
        CrossSceneAudioPlayer.PlaySE(clip);
    }
}
