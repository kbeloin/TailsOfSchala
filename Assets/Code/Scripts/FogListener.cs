using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogListener : MonoBehaviour {

    private ParticleSystem fogParticles;

    // Start is called before the first frame update
    void Start()
    {

        fogParticles = GetComponent<ParticleSystem>();

        if (EnvironmentManager.Instance != null)
        {
            if (EnvironmentManager.Instance.foggy)
            {
                fogParticles.Play();
            }
            else
            {
                fogParticles.Clear();
                fogParticles.Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (EnvironmentManager.Instance.foggy)
        {
            fogParticles.Play();
        }
        else
        {
            fogParticles.Clear();
            fogParticles.Stop();
        }
    }
}
