using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;
    public void SetMusicVolume(float musicVolume)
    {
        musicMixer.SetFloat("MusicVolume", musicVolume);
    }

    public void SetEffectsVolume(float effectsVolume)
    {
        musicMixer.SetFloat("EffectsVolume", effectsVolume);
    }
}
