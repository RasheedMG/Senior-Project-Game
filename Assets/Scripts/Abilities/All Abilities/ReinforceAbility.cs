using System.Collections;
using System.Collections.Generic;
using LlamAcademy.Guns.Demo;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class ReinforceAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        IsActive = true;

        Player player = parent.GetComponentInChildren<Player>();
        
        player.PlayerArmourCurrent += 10f;
    }

    public override void Deactivate(GameObject parent)
    {
        Player player = parent.GetComponentInChildren<Player>();
        
        player.PlayerArmourCurrent -= 10f;

        IsActive = false;
    }
}