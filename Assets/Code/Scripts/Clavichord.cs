using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clavichord : MonoBehaviour
{    
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/C3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Dd3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/D3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Eb3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/E3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/F3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Gb3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/G3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Ab3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/A3"));
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Bb3"));
        }

        if (Input.GetKeyDown(KeyCode.Plus))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/B4"));
        }

    }
}
