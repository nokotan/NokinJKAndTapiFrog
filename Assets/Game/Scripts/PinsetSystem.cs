using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsetSystem : MonoBehaviour
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
        randomNumber = UnityEngine.Random.Range(1, 4);
        if (randomNumber == 1)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 12.5f;
            x3 = -5.5f;
            y3 = 9.5f;
        }
        if (randomNumber == 2)
        {
            x1 = -4.5f;
            y1 = 13.5f;
            x2 = -4.5f;
            y2 = 12.5f;
            x3 = -4.5f;
            y3 = 9.5f;
        }
        if (randomNumber == 3)
        {
            x1 = -3.5f;
            y1 = 13.5f;
            x2 = -3.5f;
            y2 = 12.5f;
            x3 = -3.5f;
            y3 = 9.5f;
        }
        if (randomNumber == 4)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 5)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 6)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 7)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 8)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 9)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 10)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 11)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }
        if (randomNumber == 12)
        {
            x1 = -5.5f;
            y1 = 13.5f;
            x2 = -5.5f;
            y2 = 11.5f;
            x3 = -5.5f;
            y3 = -0.5f;
        }

        //ピンセットの初期位置設定

        Vector3 direction0 = new Vector3(x1, y1, 0f);
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction0, speed);
            yield return null;
        }

        //５～8秒の待ち
        yield return new WaitForSeconds(Random.Range(5.0f, 8.0f));
        //初期動作　ピンセットが画面外から画面内に。
        Vector3 direction1 = new Vector3(x2,y2,0f);
        for (int i = 0; i<5;i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction1, speed);
            yield return null;
        }
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);
        //攻撃動作　ピンセットがプレイヤーに接近する
        speed = 4.0f;
        Vector3 direction2 = new Vector3(x3,y3,0f);
        for (int i=0; i<5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction2, speed);
            yield return null;
        }
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);
        //撤退動作　ピンセットが初期位置に戻る
        speed = 4.0f;
        Vector3 direction3 = new Vector3(x1, y1, 0f);
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

        if(enemyAttackTimer > enemyAttackInterval)
        {
            //transform.position = Vector3.MoveTowards(transform.position, direction, speed);

            StartCoroutine(Move());


            enemyAttackTimer = 0;
            enemyAttackInterval = Random.Range(5.0f, 10.0f);
        }

    }
}
