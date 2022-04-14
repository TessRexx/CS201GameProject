using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class SoundScript
{
    public AudioClip clip;
    public string name;
    public bool loop;
    [Range(0f, 1f)] public float volume;
    public AudioMixerGroup audioMixer;

    [HideInInspector] public AudioSource source;
}
