using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRecorderBase : MonoBehaviour
{
    public virtual string GetRecorderName()
    {
        return null;
    }

    public virtual string GetRecordEntries()
    {
        return null;
    }

    public virtual void RestoreObjectsFromRecordEntries(string serializedData)
    {

    }
}
