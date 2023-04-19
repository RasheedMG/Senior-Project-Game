using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class TimeWarpAbility : Ability
{
    public float TimeSlowMultiplier;
    [SerializeField] AudioMixer mainMixer;

    public override void Activate(GameObject parent)
    {
        IsActive = true;
        
        Time.timeScale *= TimeSlowMultiplier;

        mainMixer.SetFloat("pitch", TimeSlowMultiplier);
    }

    public override void Deactivate(GameObject parent)
    {
        float inverseTimeSlowMultiplier = (1 / TimeSlowMultiplier);

        Time.timeScale *= inverseTimeSlowMultiplier;
        
        mainMixer.SetFloat("pitch", 1f);

        IsActive = false;
    }
}