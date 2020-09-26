using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clavichord : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/C3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Dd3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/D3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Eb3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/E3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/F3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Gb3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/G3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Ab3"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/A3"));
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Bb3"));
        }

        if (Input.GetKeyDown(KeyCode.Plus))
        {
            audio.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/B4"));
        }

    }
}
