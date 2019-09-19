using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RuntimeInstantiator/CreateTable")]
public class RuntimeInstantiator : ScriptableObject
{
    [SerializeField]
    GameObject[] prefabs;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnPlayerLaunch()
    {
        foreach (var instantiator in Resources.FindObjectsOfTypeAll<RuntimeInstantiator>())
        {
            foreach(var prefab in instantiator.prefabs)
            {
                GameObject.Instantiate(prefab);
            }
        }      
    }
}
