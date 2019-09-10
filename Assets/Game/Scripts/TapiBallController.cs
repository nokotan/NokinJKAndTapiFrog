using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiBallController : MonoBehaviour
{
    [SerializeField] Vector3[] targetLocalPoints;
    [SerializeField] float moveSpeed = 0.1f;

    [SerializeField] Animator animator;
    [SerializeField] float waitTimeForAnimation = 1.0f;

    IEnumerator MoveRoutine()
    {
        var InitialPosition = transform.position;
        
        foreach (var nextLocalPosition in targetLocalPoints)
        {
            var nextRotatedPosition = transform.rotation * nextLocalPosition;
            var nextPosition = InitialPosition + nextRotatedPosition;

            while (true)
            {
                var moveDelta = nextPosition - transform.position;
                var moveDirection = moveDelta.normalized;
                var leftDintance = moveDelta.magnitude;

                if (leftDintance <= moveSpeed)
                {
                    transform.position = nextPosition;
                    break;
                }
                else
                {
                    transform.position += moveDirection * moveSpeed;
                }

                yield return null;
            }

            animator.SetTrigger("StartBounce");
            yield return new WaitForSeconds(waitTimeForAnimation);
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
