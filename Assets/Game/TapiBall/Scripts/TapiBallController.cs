using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiBallController : MonoBehaviour
{
    [SerializeField] Vector3[] targetLocalPoints;
    [SerializeField] float moveSpeed = 0.2f;

    [SerializeField] Animator animator;
    [SerializeField] float waitTimeForAnimation = 1.0f;

    public IEnumerator MoveRoutine()
    {
        var InitialPosition = transform.position;
        int count=0;

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
                    count++;
                    break;
                }
                else
                {
                    transform.position += moveDirection * moveSpeed;
                }

                yield return null;
            }
            if (count == 1)
            {
                GetComponent<AudioSource>().Play();
            }
            else if (count == 2)
            {
                animator.SetTrigger("StartBounce");
            }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
