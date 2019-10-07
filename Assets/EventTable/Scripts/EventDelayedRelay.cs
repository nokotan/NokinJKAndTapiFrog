using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDelayedRelay : MonoBehaviour
{
    [SerializeField] EventTable eventTable;
    [SerializeField] string eventName;
    [SerializeField] float delayedTime = 2.0f;

    IEnumerator DelayRoutine(Event e)
    {
        yield return new WaitForSeconds(delayedTime);
        e?.Invoke();
    }

    public void Invoke()
    {
        if (enabled)
            StartCoroutine(DelayRoutine(eventTable.Find(eventName)));
    }

    // just for enabling "Enable Button" in inspector...
    void Update()
    {

    }
}
