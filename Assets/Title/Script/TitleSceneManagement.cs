using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 108

public class TitleSceneManagement : SceneManagement
{
    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Submit"))
        {
            ChangeScene();
            GetComponent<AudioSource>().Play();
        }
    }
}
