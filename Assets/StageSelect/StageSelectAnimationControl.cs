using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectAnimationControl : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] float animationDuration = 0.5f;

    public int selectedStageMax
    {
        get
        {
            return transform.childCount;
        }
    }

    public bool isInAnimation { get; private set; } = false;

    IEnumerator AnimationRoutine(int focusingStageIdx)
    {
        isInAnimation = true;

        var focusingChildIdx = focusingStageIdx - 1;
        var initialPosition = transform.position;
        var targetPosition = -transform.GetChild(focusingChildIdx).localPosition;

        var elapsedTime = 0.0f;

        while (elapsedTime <= animationDuration)
        {
            var t = animationCurve.Evaluate(elapsedTime / animationDuration);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            yield return null;
            elapsedTime += Time.deltaTime;
        }

        transform.position = targetPosition;
        isInAnimation = false;
    }

    public void SetFocus(int focusingStageIdx)
    {
        StartCoroutine(AnimationRoutine(focusingStageIdx));
    }
}
