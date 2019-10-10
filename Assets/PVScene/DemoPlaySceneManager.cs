using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoPlaySceneManager : MonoBehaviour
{
    [SerializeField] AudioClip systemSE;
    float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Title");

            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(systemSE);
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime > 15.0f)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
