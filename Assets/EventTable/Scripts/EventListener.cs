using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] EventTable eventTable;
    [SerializeField] string eventName;

    [SerializeField] UnityEvent onEventReceived;

    protected virtual void OnEventReceived()
    {
        if (enabled)
            onEventReceived.Invoke();
    }

    void Awake()
    {
        eventTable.Find(eventName)?.AddEventHandler(OnEventReceived);
    }

    void OnDestroy()
    {
        eventTable.Find(eventName)?.RemoveEventHandler(OnEventReceived);
    }

    // just for enabling "Enable Button" in inspector...
    void Update()
    {
        
    }
}
