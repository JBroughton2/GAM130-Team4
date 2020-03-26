using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer masterMixer;

    public void SetVolume (float volume)
    {
       masterMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume (float volume)
    {
        masterMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume (float volume)
    {
        masterMixer.SetFloat("SFXVolume", volume);
    }
}
