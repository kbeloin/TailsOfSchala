using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnvironmentManager : Singleton<EnvironmentManager>
{

    private Animator animator;
    private Light2D globalLight;
    //public GameObject rainSystem;
    //public GameObject cloudSystem;
    private bool lightningIsQueued;

    public bool queueLightning = false;
    public bool rainStorm = false;
    public bool cloudy = false;
    public bool sunny = true;

    protected EnvironmentManager() { }

    void Start()
    {
        animator = GetComponent<Animator>();

        // Global light has to start as disabled and be enabled after singleton or there will be a 
        // "multiple global lights" crash on scene change.
        globalLight = GetComponent<Light2D>();
        globalLight.enabled = true;
    }

    void Update()
    {
        //Check for changes in weather status.  Should be refactored into a switch.
        if (rainStorm == true && sunny == false)
        {
            animator.SetBool("IsRaining", true);

            if (!lightningIsQueued)
                StartCoroutine(Lightning());
        }

        else if (sunny == true && rainStorm == false)
            animator.SetBool("IsRaining", false);
    }

    IEnumerator Lightning()
    {
        lightningIsQueued = true;
        UnityEngine.Debug.Log("lightning queued");
        int seconds = UnityEngine.Random.Range(7, 12);
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("Lightning");
        lightningIsQueued = false;
    }
}
