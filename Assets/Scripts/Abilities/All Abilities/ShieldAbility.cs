using System.Collections;
using System.Collections.Generic;
using LlamAcademy.Guns.Demo;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class ShieldAbility : Ability
{
    private float originalDelay;

    [SerializeField] private float regenerationRateMultiplier;
    
    public override void Activate(GameObject parent)
    {
        IsActive = true;

        Player player = parent.GetComponentInChildren<Player>();
        
        originalDelay = player.shieldRegenerationDelay;

        player.MaximizeShield();
        
        player.shieldRegenerationRate *= regenerationRateMultiplier;
        player.shieldRegenerationDelay = 0f;
    }

    public override void Deactivate(GameObject parent)
    {
        Player player = parent.GetComponentInChildren<Player>();
        
        player.shieldRegenerationDelay = originalDelay;
        player.shieldRegenerationRate /= regenerationRateMultiplier;

        IsActive = false;
    }
}