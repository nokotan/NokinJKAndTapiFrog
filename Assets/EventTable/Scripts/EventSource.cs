using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSource : MonoBehaviour
{
    [SerializeField] EventTable eventTable;
    [SerializeField] string eventName;

    public void Invoke()
    {
        if (enabled)
            eventTable.Find(eventName)?.Invoke();
    }

    // just for enabling "Enable Button" in inspector...
    void Update()
    {

    }
}
