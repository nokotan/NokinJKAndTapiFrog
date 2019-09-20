using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehaviour <T> : MonoBehaviour where T : SingletonMonoBehaviour <T>
{
    private static T instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("複数のインスタンスがあるみたいです");
        }

        instance = (T)this;

        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }

        Destroyed();
    }

    protected virtual void Destroyed()
    {

    }

    public static T Instance
    {
        get
        {      
#if DEBUG                    
            var gameObjects = FindObjectsOfType<T>();

            if (gameObjects.Any(component => component != instance))
            {
                Debug.LogWarning("シングルトンコンポーネントがシーン中に意図せず複数含まれています。");
            }        
#endif
            return instance;
        }
    }
}
