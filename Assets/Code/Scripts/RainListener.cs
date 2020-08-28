using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainListener : MonoBehaviour
{

    private ParticleSystem rainParticles;

    // Start is called before the first frame update
    void Start()
    {

        rainParticles = GetComponent<ParticleSystem>();

        if (EnvironmentManager.Instance != null)
        {
            if (EnvironmentManager.Instance.rainStorm)
            {
                rainParticles.Play();
            }
            else
            {
                rainParticles.Clear();
                rainParticles.Pause();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(EnvironmentManager.Instance.rainStorm)
        {
            rainParticles.Play();
        }
        else
        {
            rainParticles.Clear();
            rainParticles.Pause();
        }
    }
}
