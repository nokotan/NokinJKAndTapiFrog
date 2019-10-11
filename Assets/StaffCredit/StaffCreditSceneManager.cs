using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaffCreditSceneManager : MonoBehaviour
{
    [SerializeField] AudioClip mainBGM;
    [SerializeField] AudioClip systemSE;

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
            SceneManager.LoadScene("Title");
            CrossSceneAudioPlayer.PlaySE(systemSE);
        }
    }
}
