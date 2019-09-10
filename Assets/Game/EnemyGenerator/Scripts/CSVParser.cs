using System.IO;
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
    CommandTable commandTable;

    IEnumerator EnemyInstantiateRoutine()
    {
        var reader = new StringReader(Encoding.UTF8.GetString(textAsset.bytes));

        while (reader.Peek() > -1)
        {
            var line = reader.ReadLine().Trim(' ');
            var delimited = line.Split(',');
            var commandName = delimited[0];
            var args = delimited.Skip(1);

            var commandObj = commandTable.Find(commandName);
            yield return commandObj?.Task.DoCommand(args.ToArray());
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