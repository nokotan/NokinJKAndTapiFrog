using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovementU : MonoBehaviour
{
    [SerializeField] protected float moveRoutineInterval = 5.0f;
    [SerializeField] protected float moveActionTime = 1.0f;
    [SerializeField] Vector2 moveDistance = new Vector2(0.0f,-1.0f);

    IEnumerator StartMoveAction(Vector3 moveDirection)
    {
        var elapsedTime = 0.0f;
        var originalPosition = transform.position;
        var targetPosition = transform.position - moveDirection;

        do
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveActionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        } while (elapsedTime < moveActionTime);
    }

    IEnumerator StartMoveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveRoutineInterval);
            yield return StartMoveAction(moveDistance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartMoveRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
