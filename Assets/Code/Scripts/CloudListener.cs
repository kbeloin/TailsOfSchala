using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudListener : MonoBehaviour {

    private ParticleSystem cloudParticles;

    // Start is called before the first frame update
    void Start()
    {

        cloudParticles = GetComponent<ParticleSystem>();

        if (EnvironmentManager.Instance != null)
        {
            if (EnvironmentManager.Instance.cloudy)
            {
                cloudParticles.Play();
            }
            else
            {
                cloudParticles.Clear();
                cloudParticles.Pause();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (EnvironmentManager.Instance.cloudy)
        {
            cloudParticles.Play();
        }
        else
        {
            cloudParticles.Clear();
            cloudParticles.Pause();
        }
    }
}
