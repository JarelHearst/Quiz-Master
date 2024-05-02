using System;
using UnityEngine;
[System.Serializable]
public struct SoundParameters
{
    [Range(0, 1)]
    public float Volume;
    [Range(-3, 3)]
    public float Pitch;
    public bool isLooping;
}
[System.Serializable]
public class Sound
{
    [SerializeField] string name;
    [SerializeField] AudioClip clip;
    [SerializeField] SoundParameters parameters;
    [HideInInspector] public AudioSource Source;

    public string GetName()
    {
        return name;
    }

    public AudioClip ReturnAudioClip()
    {
        return clip;
    }

    public SoundParameters GetParameters()
    {
        return parameters;
    }

    public void Play()
    {
        Source.clip = clip;
        Source.pitch = parameters.Pitch;
        Source.loop = parameters.isLooping;
        Source.Play();

    }
    public void Stop()
    {
        Source.Stop();
    }
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] Sound[] sounds;
    [SerializeField] AudioSource sourcePrefab;
    [SerializeField] string startUpTrack;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitSounds();

        if (string.IsNullOrEmpty(startUpTrack) != true)
        {
            PlaySound(startUpTrack);
        }
    }

    void InitSounds()
    {
        foreach (var sound in sounds)
        {
            AudioSource source = (AudioSource)Instantiate(sourcePrefab, gameObject.transform);
            source.name = sound.GetName();
            sound.Source = source;
        }
    }
    public void PlaySound(string name)
    {
        var sound = GetSound(name);
        if (sound != null)
        {
            sound.Play();
        }
        else
        {
            //Debug.LogWarningFormat("Sound by the name {0} is not found" + name + " is not found!");
        }
    }
    public void StopSound(string name)
    {
        var sound = GetSound(name);
        if (sound != null)
        {
            sound.Stop();
        }
        else
        {
            Debug.LogWarningFormat("Sound by the name {0} is not found" + name + " is not found!");
        }
    }

    Sound GetSound(string name)
    {
        foreach (var sound in sounds)
        {
            if (sound.GetName() == name)
            {
                return sound;
            }
        }
        return null;
    }
}
