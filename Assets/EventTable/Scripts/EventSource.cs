using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSource : MonoBehaviour
{
    [SerializeField] EventTable eventTable;
    [SerializeField] string eventName;

    public void Invoke()
    {
        eventTable.Find(eventName)?.Invoke();
    }
}
