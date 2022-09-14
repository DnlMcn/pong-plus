using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        // Prevents the existance of more than one Audio Manager
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // Allows the Audio Manager to persist between scenes
        DontDestroyOnLoad(gameObject);

        // Automatically creates an audio source for each sound listed in the array
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.name == null)
        {
            Debug.LogWarning("Sound " + name + " was not found.");
            return;
        }
        s.source.Play();
    }
}
