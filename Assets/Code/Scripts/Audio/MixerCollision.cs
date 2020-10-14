using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixerCollision : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixerSnapshot[] audioMixerSnapshots;
    public float[] weights;
    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioMixer.TransitionToSnapshots(audioMixerSnapshots, weights, duration);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float[] reverseWeights = new float[2] { weights[1], weights[0] };

            audioMixer.TransitionToSnapshots(audioMixerSnapshots, reverseWeights, duration);
        }
    }
}