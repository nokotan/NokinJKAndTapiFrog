﻿using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVParser : MonoBehaviour
{
    [SerializeField]
    TextAsset textAsset;

    [SerializeField]
    WaitTask waitTask;

    [SerializeField]
    EnemyActionTask enemyActionTask;

    IEnumerator EnemyInstantiateRoutine()
    {
        var reader = new StringReader(Encoding.UTF8.GetString(textAsset.bytes));

        while (reader.Peek() > -1)
        {
            // 1行ずつ順番に処理していく

            // テキストファイルから1行読み取り、空白を取り除く
            var line = reader.ReadLine().Trim(' ');
            // ',' で分割する。
            // 例えば "adda,pin,6" という文字列を、[ "adda", "pin", "6" ] といった文字列の配列に変換し、delimited に保存する
            var delimited = line.Split(',');

            // ここで、配列 delimited の0番目にはコマンド名が保存されている
            var commandName = delimited[0];
            // delimited の1番目の後にはコマンドに対する引数が保存されている
            // なので Skip (Linq拡張) を使って、配列 [ "adda", "pin", "6" ] から部分配列 [ "pin", "6" ] を作り、それを args に保存する
            // ところで Skip 関数は先頭から n 個の要素を飛ばした部分配列を作る関数である
            var args = delimited.Skip(1).ToArray();

            // コマンドごとに異なる処理をしていく
            if (commandName == "wait")
            {
                // ここに一定時間待つ処理を具体的に書いてしまってもいいが、
                // それだと CSVParser の責任が大きくなりすぎるのであえて別のファイルで書く
                // (QGJ程度の短期制作であれば直に書いたほうが楽だが、長期制作であれば分けておくことで
                // 何か変更をかけるときに1つの肥大化したファイルを永遠と探さなくて済む)
                yield return waitTask.DoCommand(args);
            }
            else if (commandName == "adda")
            {
                yield return enemyActionTask.DoCommand(args);
            }
            else if (commandName == "adds")
            {
                yield return new WaitForSeconds(1.0f);
                yield return enemyActionTask.DoCommand(args);
            }
        }
    }

    public void StartEnemyGenerating()
    {
        StartCoroutine(EnemyInstantiateRoutine());
    }

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyGenerating();
    }
}