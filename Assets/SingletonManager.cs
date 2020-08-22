using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{

    public EnvironmentManager[] singletonPrefabs;
    private EnvironmentManager envManager;

    void Start()
    {
        foreach (EnvironmentManager singleton in singletonPrefabs)
        {
            if (EnvironmentManager.instance)
            {
                Destroy(singleton.gameObject);
                return;
            }

            envManager = Instantiate(singleton);
            EnvironmentManager.instance = envManager;
            GameObject.DontDestroyOnLoad(envManager.gameObject);
        }
    }
}
