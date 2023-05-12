using System.Collections;
using System.Collections.Generic;
using LlamAcademy.Guns.Demo;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class DoubleDamageAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        IsActive = true;

        WeaponModifierLoader weaponModifier = parent.GetComponentInParent<WeaponModifierLoader>();
        
        weaponModifier.UpdateDamageModifier(2f);
    }

    public override void Deactivate(GameObject parent)
    {
        WeaponModifierLoader weaponModifier = parent.GetComponentInParent<WeaponModifierLoader>();
        
        weaponModifier.UpdateDamageModifier(0.5f);

        IsActive = false;
    }
}