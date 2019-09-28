using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiBallController : MonoBehaviour
{
    [SerializeField] Vector3[] targetLocalPoints;
    [SerializeField] float moveSpeed = 12f;

    [SerializeField] Animator animator;
    [SerializeField] float waitTimeForAnimation = 1.0f;

    IEnumerator MoveRoutine()
    {
        var InitialPosition = transform.position;
        int count=0;

        foreach (var nextLocalPosition in targetLocalPoints)
        {
            var nextRotatedPosition = transform.rotation * nextLocalPosition;
            var nextPosition = InitialPosition + nextRotatedPosition;

            while (true)
            {
                var timeScaledMoveSpeed = Time.deltaTime * moveSpeed;
                var moveDelta = nextPosition - transform.position;
                var moveDirection = moveDelta.normalized;
                var leftDintance = moveDelta.magnitude;

                if (leftDintance <= timeScaledMoveSpeed)
                {
                    transform.position = nextPosition;
                    count++;
                    break;
                }
                else
                {
                    transform.position += moveDirection * timeScaledMoveSpeed;
                }

                yield return null;
            }
            if (count == 1)
            {
                // GetComponent<AudioSource>().Play();
                CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
            }
            else if (count == 2)
            {
                animator.SetTrigger("StartBounce");
            }
            yield return new WaitForSeconds(waitTimeForAnimation);
        }

        Destroy(gameObject);
    }

    public IEnumerator StartMoveRoutine()
    {
        return new CustomCoroutine(this, MoveRoutine());
    }

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(StartMoveRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // 無敵モードでタピオカボールを途中で消すとEnemyGereratorの動作が停止してしまうので終点につくまで消さないようにしている
            Destroy(gameObject);
        }
    }
}
