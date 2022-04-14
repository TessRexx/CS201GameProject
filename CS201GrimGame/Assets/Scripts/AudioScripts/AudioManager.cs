using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundScript[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        // Check if audio manager already exists in scene, destroy if it does to avoid duplicate
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(SoundScript currentSound in sounds)
        {
            currentSound.source = gameObject.AddComponent<AudioSource>();
            currentSound.source.clip = currentSound.clip;
            currentSound.source.loop = currentSound.loop;
            currentSound.source.outputAudioMixerGroup = currentSound.audioMixer;
        }
    }

    private void Start()
    {
        PlaySound("ThemeSong");
    }

    public void PlaySound(string name)
    {
        SoundScript currentSound = Array.Find(sounds, sound => sound.name == name);
        currentSound.source.Play();
    }
}
