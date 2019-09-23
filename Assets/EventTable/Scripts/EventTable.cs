using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventTable/CreateEventTable")]
public class EventTable : ScriptableObject
{
    [SerializeField]
    Event[] Events;

    public Event Find(string name)
    {
        return Events.FirstOrDefault(e => e.Name == name);
    }
}
