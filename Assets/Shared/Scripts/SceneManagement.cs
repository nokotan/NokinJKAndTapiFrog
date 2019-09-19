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
        SceneManager.LoadScene(SceneName);
    }

    public virtual void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    protected void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.C))
        {
            ChangeScene("Title");
        }
    }
}

