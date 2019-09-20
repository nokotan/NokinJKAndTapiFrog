using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    public void ChangeScene()
    {
        ChangeScene(SceneName);
    }

    public virtual void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    protected void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.D))
        {
            ChangeScene("Title");
        }
    }
}

