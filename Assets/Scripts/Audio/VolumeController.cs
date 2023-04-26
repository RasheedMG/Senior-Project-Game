using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;
using System.Collections;

public class VolumeController : Singleton<VolumeController>
{
    [SerializeField] private AudioMixer audioMixer;
    
    private Dictionary<string, float> Volumes/* { get; private set; }*/ = new Dictionary<string, float>()
    {
        { "masterVolume", 50f },
        { "musicVolume", 100f },
        { "environmentVolume", 100f },
        { "effectsVolume", 100f }
    };

    private void Start()
    {
        LoadSavedPrefs();
    }

    public void SetVolume(float volume, string audioChannel)
    {
        audioMixer.SetFloat(audioChannel, volume - 80f);
        Volumes[audioChannel] = volume - 80;
        SavePref(volume, audioChannel);
    }

    public float GetVolume(string audioChannel)
    {
        return Volumes[audioChannel];
    }

    private void SavePref(float volume, string audioChannel)
    {
        PlayerPrefs.SetFloat(audioChannel, volume);
    }

    private void LoadSavedPrefs()
    {
        foreach (string channel in Volumes.Keys.ToList())
        {
            float volume = PlayerPrefs.GetFloat(channel, 80f) - 80;
            Volumes[channel] = volume;
            audioMixer.SetFloat(channel, volume);
        }
    }
}