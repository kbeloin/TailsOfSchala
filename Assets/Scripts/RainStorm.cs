using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class RainStorm : MonoBehaviour
{

    public Animator animator;
    public bool queueLightning = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Lightning());
    }

    // Update is called once per frame
    void Update()
    {
        if (queueLightning)
        {
            queueLightning = false;
            StartCoroutine(Lightning());
        }
    }

    IEnumerator Lightning()
    {
        UnityEngine.Debug.Log("lightning queued");
        int seconds = UnityEngine.Random.Range(7, 12);
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("Lightning");
        queueLightning = true;
    }
}
