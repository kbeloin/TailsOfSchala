using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clavichord : MonoBehaviour
{
    public bool playerInRange;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/C4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Db4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/D4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Eb4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/E4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/F4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Gb4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/G4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Ab4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/A4"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/Bb4"));
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/B4"));
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            source.PlayOneShot ((AudioClip)Resources.Load ("AncientClavichord/C5"));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            GameManager.Instance.ShowTooltipWithTimeout("Play with the number row!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
