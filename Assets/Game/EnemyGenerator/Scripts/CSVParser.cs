using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVParser : MonoBehaviour
{
    int SkippedCommandsNum;

    IEnumerator EnemyInstantiateRoutine(EnemyGenerator generator)
    {
        var config = ConfigSystem.Instance;
        var stageList = config.EnemyGenerating.Stages;
        var selectedStage = stageList[StageSelectControl.selectedStage - 1];

        var reader = new StreamReader($"{Application.streamingAssetsPath}/{selectedStage}");

        Debug.Log($"Loading File {selectedStage}...");

        for (int i = 0; i < SkippedCommandsNum && reader.Peek() > -1; i++)
        {
            reader.ReadLine(); // 飛ばす
        }

        for (int i = 0; reader.Peek() > -1; i++)
        {
            // 1行ずつ順番に処理していく

            // テキストファイルから1行読み取り、空白を取り除く
            var line = reader.ReadLine().Replace(" ", "");
            // ',' で分割する。
            // 例えば "adda,pin,6" という文字列を、[ "adda", "pin", "6" ] といった文字列の配列に変換し、delimited に保存する
            var delimited = line.Split(',');

            // ここで、配列 delimited の0番目にはコマンド名が保存されている
            var commandName = delimited[0];
            
            if (commandName == "cpnt")
            {
                SkippedCommandsNum = i;
            }

            var commandRoutine = generator.ExecuteCommand(line, this);

            if (commandRoutine != null)
            {
                //yield return commandRoutine;
                yield return commandRoutine(this);
            }
        }
    }

    public void StartEnemyGenerating()
    {
        var enemyGeneratorObject = GameObject.FindWithTag("EnemyGenerator");
        var enemyGenerator = enemyGeneratorObject.GetComponent<EnemyGenerator>();

        StartCoroutine(EnemyInstantiateRoutine(enemyGenerator));
    }

    public void StopEnemyGenerating()
    {
        StopAllCoroutines();
    }

    public void RestartEnemyGenerating()
    {
        StopEnemyGenerating();
        StartEnemyGenerating();
    }

    // Start is called before the first frame update
    void Start()
    {
        // StartEnemyGenerating();
    }
}