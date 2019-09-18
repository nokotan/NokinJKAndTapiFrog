using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiokaSystem : MonoBehaviour
{
    float enemyAttackInterval;
    float enemyAttackTimer;
    int randomNumber;

    float speed = 1.0f;

    float x1;
    float y1;
    float x2;
    float y2;
    float x3;
    float y3;

    // Start is called before the first frame update
    void Start()
    {
        enemyAttackInterval = Random.Range(5.0f, 10.0f);
    }

    IEnumerator Move()
    {
        //ピンセットの座標変更
        randomNumber = UnityEngine.Random.Range(1, 5);
        if (randomNumber == 1)
        {
            x1 = -2.0f;
            y1 = -1.0f;
            x2 = -1.0f;
            y2 = -2.0f;
            x3 = 0.0f;
            y3 = -1.0f;
        }
        if (randomNumber == 2)
        {
            x1 = -1.0f;
            y1 = -2.0f;
            x2 = 0.0f;
            y2 = -1.0f;
            x3 = -1.0f;
            y3 = 0.0f;
        }
        if (randomNumber == 3)
        {
            x1 = 0.0f;
            y1 = -1.0f;
            x2 = -1.0f;
            y2 = -0.0f;
            x3 = -2.0f;
            y3 = -1.0f;
        }
        if (randomNumber == 4)
        {
            x1 = -1.0f;
            y1 = 0.0f;
            x2 = -2.0f;
            y2 = -1.0f;
            x3 = -1.0f;
            y3 = -2.0f;
        }


        //タピオカの初期位置設定
        Vector3 direction0 = new Vector3(x1, y1, 0f);
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction0, speed);
            yield return null;
        }
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);
        //タピオカの移動地点
        Vector3 direction1 = new Vector3(x2, y2, 0f);
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction1, speed);
            yield return null;
        }
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);
        //タピオカの最終移動地点
        Vector3 direction2 = new Vector3(x3, y3, 0f);
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction2, speed);
            yield return null;
        }
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);
        //撤退動作　マカロンが画面外に消える
        Vector3 direction3 = new Vector3(100f, 100f, 0f);
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction3, speed);
            yield return null;
        }
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        enemyAttackTimer += Time.deltaTime;

        if (enemyAttackTimer > enemyAttackInterval)
        {
            //transform.position = Vector3.MoveTowards(transform.position, direction, speed);

            StartCoroutine(Move());


            enemyAttackTimer = 0;
            enemyAttackInterval = Random.Range(5.0f, 10.0f);
        }
    }
}
