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

        if (EnvironmentManager.GetInstance() != null)
        {
            if (EnvironmentManager.GetInstance().rainStorm)
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
        if(EnvironmentManager.GetInstance().rainStorm)
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
