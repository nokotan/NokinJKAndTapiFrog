﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PinsetController : MonoBehaviour
{
    float speed = 1.0f;
    public float x1;
    public float y1;
    public float x2;
    public float y2;
    public float x3;
    public float y3;

    public static bool shake = false;

    [SerializeField] AudioClip PinsetReadySound;


    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Move());
        // 任意のオブジェクトを取得する
        GameObject shakeprogram;
        shakeprogram = GameObject.Find("Main Camera");
    }


    public IEnumerator Move()
    {
        //一撃目
        shake = false;
        //ピンセットの初期位置設定
        // Vector3 direction0 = new Vector3(-4f, 22f, 0f);

        Vector3 direction0 = new Vector3(x1, y1, 0f);
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction0, speed);
            yield return null;
        }

        //2秒の待ち
        // yield return new WaitForSeconds(2.0f);
        
        //初期動作　ピンセットが画面外から画面内に。
        //Vector3 direction1 = new Vector3(-4f, 21f, 0f);
        Vector3 direction1 = new Vector3(x2, y2, 0f);

        for (int i = 0; i < 5; i++)
        {
            if (i == 1)
            {
                // GetComponent<AudioSource>().Play();
                CrossSceneAudioPlayer.PlaySE(PinsetReadySound);
                GetComponent<Animator>().SetTrigger("StartShining");
            }

            transform.position = Vector3.MoveTowards(transform.position, direction1, speed);
            yield return null;
        }
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);


        //shakeprogram.GetComponent<Shaker>().Shake();


        //攻撃動作　ピンセットがプレイヤーに接近する
        speed = 4.0f;
        //Vector3 direction2 = new Vector3(-4f, 10f, 0f);
        Vector3 direction2 = new Vector3(x3, y3, 0f);

        for (int i = 0; i < 5; i++)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, direction2, speed);
            if (i == 1)
            {
                // GetComponent<AudioSource>().Play();
                CrossSceneAudioPlayer.PlaySE(GetComponent<AudioSource>().clip);
            }
            yield return null;
        }

        //揺らす
        shake = true;
        //0.2秒の待ち
        yield return new WaitForSeconds(0.2f);
        //揺らすのやめ
        shake = false;
        //１秒の待ち
        yield return new WaitForSeconds(1.0f);

        

        //撤退動作　ピンセットが初期位置に戻る
        speed = 4.0f;
        //Vector3 direction3 = new Vector3(-4f, 22f, 0f);
        Vector3 direction3 = new Vector3(x1, y1, 0f);
        for (int i = 0; i < 5; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction3, speed);
            yield return null;
        }
        //3秒の待ち
        yield return new WaitForSeconds(3.0f);
    }

    
    // Update is called once per frame
    void Update()
    {
        //shakeprogram.GetComponent<Shaker>().Shake();
    }
}
