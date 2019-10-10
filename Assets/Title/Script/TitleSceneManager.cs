using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンのシーン管理を行います
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] AudioClip mainBGM;
    float elapsedTime;

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
            SceneManager.LoadScene("tutorial");

            // GetComponent<AudioSource>().Play();
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime > 30.0f)
        {
            SceneManager.LoadScene("DemoPlay");
        }
    }
}
