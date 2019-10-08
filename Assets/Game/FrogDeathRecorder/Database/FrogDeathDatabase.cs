using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDeathDatabase : MonoBehaviour
{
    public virtual void AppendEntry(string entry)
    {

    }

    public virtual void ClearAllEntries()
    {

    }

    public virtual int GetEntriesCount()
    {
        return 0;
    }

    public virtual string GetEntry(int index)
    {
        return null;
    }
}
