using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    GameObject aux = new GameObject();
                    _instance = aux.AddComponent<T>();
                }
            }
            return _instance;
        }        
    }

    public virtual void Awake()
    {
        if (transform.parent != null)
            transform.parent = null;

        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this)
                Destroy(gameObject);
        }

        
    }
}
