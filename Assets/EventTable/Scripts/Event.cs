using System;
using UnityEngine;

[Serializable]
public class Event
{
    [SerializeField] string name;
    Action eventDelegate;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public void AddEventHandler(Action action)
    {
        eventDelegate += action;
    }

    public void RemoveEventHandler(Action action)
    {
        eventDelegate -= action;
    }

    public void Invoke()
    {
        eventDelegate.Invoke();
    }
}
