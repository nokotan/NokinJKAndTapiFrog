using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetSystem : SingletonMonoBehaviour<GameResetSystem>
{
    protected override void OnAwake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.D))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
