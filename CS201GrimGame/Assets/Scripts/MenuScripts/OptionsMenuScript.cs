// THIS SCRIPT CONTROLS MUSIC AND SOUND EFFECTS VOLUME FOR UNITY MIXERS
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenuScript : MonoBehaviour
{
    // References
    public AudioMixer musicMixer, effectsMixer;

    // Set Music Volume Method
    public void SetMusicVolume(float musicVolume)
    {
        musicMixer.SetFloat("MusicVolume", musicVolume);
    }

    // Set Sound Effect Volume Method
    public void SetEffectsVolume(float effectsVolume)
    {
        musicMixer.SetFloat("EffectsVolume", effectsVolume);
    }
}
