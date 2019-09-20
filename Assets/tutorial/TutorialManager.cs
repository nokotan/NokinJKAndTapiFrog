using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    SpriteRenderer TutorialSpriteRenderer;
    public Sprite tutorial1;
    public Sprite tutorial2;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        TutorialSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        TutorialSpriteRenderer.sprite = tutorial1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
            if (count == 0)
            {
                TutorialSpriteRenderer.sprite = tutorial2;
                count++;
            }
            else
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
