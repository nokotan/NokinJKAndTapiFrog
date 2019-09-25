using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCoroutine : IEnumerator
{
    MonoBehaviour coroutineExecutor;
    IEnumerator targetCoroutine;

    public object Current => !HasGameObjectDestroyed ? targetCoroutine.Current : null;

    bool HasGameObjectDestroyed => coroutineExecutor == null;

    public CustomCoroutine(MonoBehaviour executor, IEnumerator coroutine)
    {
        coroutineExecutor = executor;
        targetCoroutine = coroutine;
    }

    public bool MoveNext() => !HasGameObjectDestroyed ? targetCoroutine.MoveNext() : false;

    public void Reset()
    {

    }
}
