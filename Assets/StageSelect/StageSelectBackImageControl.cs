using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBackImageControl : MonoBehaviour
{
    [SerializeField] Sprite[] backImages = new Sprite[8];
    [SerializeField] int currentIndex = 0;

    public void RandomMove()
    {
        if (Random.Range(0, 2) == 0)
        {
            currentIndex = (currentIndex + 1) % backImages.Length;
        }
        else
        {
            currentIndex = (currentIndex + backImages.Length - 1) % backImages.Length;
        }

        GetComponent<SpriteRenderer>().sprite = backImages[currentIndex];
    }
}
