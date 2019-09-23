using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] EventTable eventTable;
    [SerializeField] string eventName;

    [SerializeField] UnityEvent onEventReceived;

    void OnEventReceived()
    {
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
}
