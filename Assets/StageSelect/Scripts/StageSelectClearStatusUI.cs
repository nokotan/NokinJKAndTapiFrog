using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージのクリア進捗を示す画像の管理を行います
/// </summary>
public class StageSelectClearStatusUI : MonoBehaviour
{
    /// <summary>
    /// ステージ番号
    /// </summary>
    [SerializeField] int StageIndex;
    SpriteRenderer spriteRenderer;

    [Header("Animation Settings")]
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] bool AnimationTest;

    IEnumerator AnimationRoutine()
    {
        Vector2 startScale = new Vector2(2.0f, 2.0f);
        Vector2 targetScale = new Vector2(1.0f, 1.0f);

        Color startColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Color targetColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        float totalAnimationTime = 2.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime <= totalAnimationTime)
        {
            transform.localScale = Vector2.Lerp(startScale, targetScale, animationCurve.Evaluate(elapsedTime / totalAnimationTime)); 
            spriteRenderer.color = Color.Lerp(startColor, targetColor, animationCurve.Evaluate(elapsedTime / totalAnimationTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        spriteRenderer.color = targetColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = StageSelectManager.Instance.clearedStageProgress[StageIndex - 1];

        if (StageIndex == StageSelectManager.Instance.previousClearedStageIndex)
        {
            StartCoroutine(AnimationRoutine());
        }

#if DEBUG
        if (AnimationTest)
        {
            spriteRenderer.enabled = true;
            StartCoroutine(AnimationRoutine());
        }
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
