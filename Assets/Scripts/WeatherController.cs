using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WeatherController : MonoBehaviour
{

    private Animator animator;
    private Light2D globalLight;
    public GameObject rainSystem;
    public GameObject cloudSystem;
    private bool lightningIsQueued;

    public bool queueLightning = false;
    public bool rainStorm = false;
    public bool clouds = false;
    public bool sunny = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (clouds == true)
            cloudSystem.SetActive(true);
        else
            cloudSystem.SetActive(false);

        if (rainStorm == true)
        {
            rainSystem.SetActive(true);
            animator.SetBool("IsRaining", true);
            StartCoroutine(Lightning());
        }
        else if (sunny == true)
        {
            rainSystem.SetActive(false);
            animator.SetBool("IsRaining", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rainStorm == true && sunny == false)
        {
            rainSystem.SetActive(true);
            animator.SetBool("IsRaining", true);

            if (!lightningIsQueued)
            {
                StartCoroutine(Lightning());
            } 
        }
        else if (sunny == true && rainStorm == false)
        {
            rainSystem.SetActive(false);
            animator.SetBool("IsRaining", false);
        }

        if (clouds)
            cloudSystem.SetActive(true);
        else
            cloudSystem.SetActive(false);
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
