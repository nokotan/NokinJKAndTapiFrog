using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiBallAddTask : MonoBehaviour
{
    // タピオカボールのプレハブ
    [SerializeField] GameObject prefab;
    // 初期位置の配列。要素番号が敵の出現位置の番号と対応させる
    [SerializeField] Transform[] initialPositions;

    public IEnumerator DoCommand(string[] args)
    {
        int positionIndex = Convert.ToInt32(args[0]) - 1;

        var instantiatedObject = GameObject.Instantiate(prefab, initialPositions[positionIndex].position, initialPositions[positionIndex].rotation);
        return instantiatedObject.GetComponent<TapiBallController>().StartMoveRoutine();
    }
}
