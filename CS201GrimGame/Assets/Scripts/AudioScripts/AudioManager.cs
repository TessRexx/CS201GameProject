// THIS SCRIPT IS USED TO MANAGE AUDIO DETAILS IN THE MANAGER
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // References & Variables
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

        // For each sound added
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
        // Play background music on loop
        PlaySound("ThemeSong");
    }

    // Play Sound Method
    public void PlaySound(string name)
    {
        SoundScript currentSound = Array.Find(sounds, sound => sound.name == name);
        currentSound.source.Play();
    }
}
