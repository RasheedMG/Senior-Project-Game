using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDestroy : MonoBehaviour
{
    //[SerializeField] private string _soundName;
    [SerializeField] private AudioSource bulletAudioSource;

    private void OnDestroy()
    {
        bulletAudioSource.Play();
        //AudioSystem.Instance.PlayEffectByName(_soundName);
    }
}