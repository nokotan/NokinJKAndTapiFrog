using System.Linq;
using System.Collections;
using UnityEngine;

public class CommandTask : ScriptableObject
{
    public virtual IEnumerator DoCommand(string[] args)
    {
        yield break;
    }
}