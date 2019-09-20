using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RuntimeInstantiator/CreateTable", fileName = "InstantiateOnOlayerLaunch/InstantiateTable")]
public class RuntimeInstantiator : ScriptableObject
{
    [SerializeField]
    GameObject[] prefabs;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnPlayerLaunch()
    {
        var instantiator = Resources.Load("InstantiateTable") as RuntimeInstantiator;

        foreach (var prefab in instantiator.prefabs)
        {
            DontDestroyOnLoad(Instantiate(prefab));
        }
    }
}
