using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    Behaviour[] ObservedComponents;

    void Start()
    {
        SetEnabled(true);    
    }

    public void SetEnabled(bool enable)
    {
        foreach (var item in ObservedComponents)
        {
            item.enabled = enable;
        }
    }
}
