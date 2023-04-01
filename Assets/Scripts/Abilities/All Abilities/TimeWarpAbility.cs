using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimeWarpAbility : Ability
{
    public float TimeSlowMultiplier;

    public override void Activate(GameObject parent)
    {
        Time.timeScale *= (1 / TimeSlowMultiplier);
    }

    public override void Deactivate(GameObject parent)
    {
        Time.timeScale *= TimeSlowMultiplier;
    }
}