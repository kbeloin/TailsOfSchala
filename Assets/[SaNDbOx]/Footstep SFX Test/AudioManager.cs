using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake() {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
        
    }

    // Update is called once per frame
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}

// From Brackey's "Intro to Audio" video: https://youtu.be/6OT43pvUyfY?t=240
// 4:01 starts the setup
// 10:01 shows how to incorporate it (uses an OnCollisionEnter to check collision with tagged game objects)
// i.e. Tag the road as "Dirt" to call [Dirt Foots] audio. Tage the grass as "Grass" to play the [Grass Foots] audio clip...
