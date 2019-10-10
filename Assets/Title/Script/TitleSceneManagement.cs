using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 108

public class TitleSceneManagement : SceneManagement
{
    [SerializeField] AudioClip mainBGM;

    // Start is called before the first frame update
    void Start()
    {
        CrossSceneAudioPlayer.ChangeBGM(mainBGM);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            ChangeScene();
            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
        }
    }
}
