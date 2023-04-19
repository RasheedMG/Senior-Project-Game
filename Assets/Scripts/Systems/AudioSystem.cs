using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Audio;

public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private AudioSource musicSource, environmentSource, effectsSource;
    [SerializeField] private Sound[] musics, environments, effects;

    [SerializeField] private AudioMixerGroup audioMixerGroup;

    private enum SoundType
    {
        Music,
        Environment,
        Effect
    }

    private readonly Dictionary<SoundType, Sound[]> _soundArray = new Dictionary<SoundType, Sound[]>();

    private void Start()
    {
        _soundArray.Add(SoundType.Music, musics);
        _soundArray.Add(SoundType.Environment, environments);
        _soundArray.Add(SoundType.Effect, effects);
    }

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += StopAllAudio;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= StopAllAudio;
    }

    public void PlaySoundAtPoint(string name, Vector3 position, float volume = 1) => PlaySoundAtPoint(FindClip(name, SoundType.Effect), position, volume);

    public void PlaySoundAtPoint(AudioClip clip, Vector3 position, float volume = 1)
    {
        // Create a new game object at the specified position
        GameObject audioObject = new GameObject("TempAudio");
        audioObject.transform.position = position;

        // Add an AudioSource component to the game object
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Set the audio properties
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;

        // Play the sound
        audioSource.Play();

        // Destroy the game object after the sound has finished playing
        Destroy(audioObject, clip.length);
    }

    public void PlayMusic(string name)
    {
        AudioClip clip = FindClip(name, SoundType.Music);
        PlayMusic(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayEnvironment(string name)
    {
        AudioClip clip = FindClip(name, SoundType.Environment);
        PlayEnvironment(clip);
    }

    public void PlayEnvironment(AudioClip clip)
    {
        environmentSource.clip = clip;
        environmentSource.Play();
    }

    public void PlayEffect(string name, float vol = 1)
    {
        AudioClip clip = FindClip(name, SoundType.Effect);
        PlayEffect(clip, vol);
    }

    public void PlaySound(AudioClip clip, Vector3 pos, float vol = 1)
    {
        effectsSource.transform.position = pos;
        PlayEffect(clip, vol);
    }


    public void PlayEffect(AudioClip clip, float vol = 1)
    {
        effectsSource.PlayOneShot(clip, vol);
    }

    private AudioClip FindClip(string name, SoundType type)
    {
        Sound sound = Array.Find(_soundArray[type], sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound with name \"{name}\" could not be found in Audio System's array of {type}");
            return null;
        }

        if (sound.clipsPool.Length > 1)
            return sound.clipsPool[UnityEngine.Random.Range(0, sound.clipsPool.Length)];
        else
            return sound.clipsPool[0];
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopEnvironment()
    {
        environmentSource.Stop();
    }

    public void StopEffects()
    {
        effectsSource.Stop();
    }

    public void StopAllAudio()
    {
        musicSource.Stop();
        environmentSource.Stop();
        effectsSource.Stop();
    }

    // Need Scene parameter to subscribe to sceneUnloaded Event
    public void StopAllAudio(Scene s)
    {
        musicSource.Stop();
        environmentSource.Stop();
        effectsSource.Stop();
    }
}
